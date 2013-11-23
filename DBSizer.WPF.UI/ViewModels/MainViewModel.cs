using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using DBSizer.Data;
using DBSizer.WPF.UI.ViewInterfaces;

namespace DBSizer.WPF.UI.ViewModels
{
    public class MainViewModel : ViewModelBase, IRefreshChartBinding
    {
        internal const int COLUMN_WIDTH = 50;
        internal const int DEFAULT_NUM_OF_DB_TO_SHOW = 7;
        internal int EmptyChartWidth = 200;
        private readonly IDBInfoBuilder _dbInfoBuilder;

        private readonly IMainView _mainView;
        private readonly ISqlQueryExecutor _sqlExecutor;

        public MainViewModel()
        {
        }

        public MainViewModel(ISqlQueryExecutor sqlExecutor, IMainView mainView,
                             IWindowsIdentityProvider windowsIdentityProvider, IDBInfoBuilder dbInfoBuilder)
        {
            _sqlExecutor = sqlExecutor;
            _mainView = mainView;
            _dbInfoBuilder = dbInfoBuilder;
            AllDataBases = new ObservableCollection<DBInfoListItem>();
            Connect = new RelayCommand(ConnectClicked);
            Analyse = new RelayCommand(AnalyseClicked, CanClickAnalyse);
            ShowAboutWindow = new RelayCommand(AboutClicked);
            SqlConnectionSettingsViewModel = new SqlConnectionSettingsViewModel(windowsIdentityProvider);
            HelpText = INIT_TEXT;
        }

        internal string INIT_TEXT
        {
            get { return "Click Connect to load list of databases"; }
        }

        internal string AFTER_INIT_TEXT
        {
            get { return "Check databases to see them on chart"; }
        }

        private bool CanClickAnalyse()
        {
            return AllDataBases.Count > 0;
        }

        public ICommand Connect { get; private set; }
        public RelayCommand Analyse { get; private set; }
        public ICommand ShowAboutWindow { get; private set; }
        public ObservableCollection<DBInfoListItem> AllDataBases { get; private set; }
        public IConnectionSettings SqlConnectionSettingsViewModel { get; private set; }

        public List<DBInfoListItem> DataBasesForChart
        {
            get
            {
                if (AllDataBases != null)
                {
                    return new List<DBInfoListItem>(AllDataBases.Where(x => x.IsChecked));
                }
                return new List<DBInfoListItem>();
            }
        }

        public int ChartWidth
        {
            get
            {
                if (DataBasesForChart.Count == 0)
                {
                    return 0;
                }
                return DataBasesForChart.Count*COLUMN_WIDTH;
            }
        }

        public string HelpText { get; private set; }

        public void RefreshChartBinding()
        {
            OnPropertyChanged("DataBasesForChart");
            OnPropertyChanged("ChartWidth");
        }

        private void AboutClicked()
        {
            _mainView.ShowAboutWindow();
        }

        private void AnalyseClicked()
        {
            DBInfoListItem item = _mainView.SelectedItem;
            if (item == null)
            {
                _mainView.Dialogs.Info("Please select database to analyse");
                return;
            }

            IDatabaseDetailsWindow detailsWindow = _mainView.CreateDetailsWindow();
            using (var viewModel = new DatabaseDetailsViewModel(_sqlExecutor, item.Item.ConnString, item.Item.Name, detailsWindow))
            {
                detailsWindow.DataContext = viewModel;
                detailsWindow.ShowDialog();
            }
        }

        private void ConnectClicked()
        {
            AllDataBases.Clear();
            Analyse.OnCanExecuteChanged();

            // connection check
            var masterDBConnString = ConnectionStringBuilder.MasterDBConnectionStringCreate(SqlConnectionSettingsViewModel);
            if (!_sqlExecutor.ConnectionIsValid(masterDBConnString))
            {
                HelpText = INIT_TEXT;
                OnPropertyChanged("HelpText");
                OnPropertyChanged("DataBasesForChart");
                _mainView.Dialogs.Error(@"Can't connect to server. Check connection settings, and make sure you have rights to connect that server.");
                return;
            }

            // databases info load
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (string dbName in _sqlExecutor.LoadDatabaseList(masterDBConnString))
                {
                    var dbInfo = _dbInfoBuilder.Create(ConnectionStringBuilder.ConnectionStringCreate(SqlConnectionSettingsViewModel, dbName), dbName);
                    Dispatcher.Invoke(new Action(() => AllDataBases.Add(new DBInfoListItem(dbInfo, this))));
                }
                Dispatcher.Invoke(new Action(CheckBiggestDBs));                
                HelpText = AFTER_INIT_TEXT;
                OnPropertyChanged("HelpText");
                RefreshChartBinding();
                Dispatcher.Invoke(new Action(() => Analyse.OnCanExecuteChanged()));
            });
        }

        private void CheckBiggestDBs()
        {
            var biggestDbs = AllDataBases.OrderByDescending(x => x.Item.TotalSizeMB).Take(DEFAULT_NUM_OF_DB_TO_SHOW);
            foreach (var db in biggestDbs)
            {
                db.IsChecked = true;
            }
        }
    }
}