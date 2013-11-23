using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using DBSizer.Data;
using DBSizer.WPF.UI.ViewInterfaces;

namespace DBSizer.WPF.UI.ViewModels
{
    public class DatabaseDetailsViewModel : ViewModelBase, IDisposable
    {
        private readonly string _databaseConnectionString;
        private readonly ISqlQueryExecutor _queryExecutor;
        private Characteristic _characteristicToDisplay;
        private int? _numValues;
        /// <summary>
        /// All table infos for the database
        /// </summary>
        private List<TableInfo> _tables;

        private const int DEFAULT_NUM_VALUES_TO_SHOW = 5;

        public DatabaseDetailsViewModel(ISqlQueryExecutor queryExecutor,
                                        string databaseConnectionString, string databaseName, IDatabaseDetailsWindow view)
        {
            _queryExecutor = queryExecutor;
            _databaseConnectionString = databaseConnectionString;
            WindowCaption = string.Format("Database {0} tables details", databaseName);
            _numValues = DEFAULT_NUM_VALUES_TO_SHOW;
            _characteristicToDisplay = Characteristic.DataSize;
            ItemsToShow = new ObservableCollection<TableInfoViewItem>();
            Refresh = new RelayCommand(RefreshClicked);
            ProgressVisible = false;
            ProgressValue = 0;

            view.Loaded += (sender, args) => RefreshClicked();

            _queryExecutor.TableLoadProgressChanged += queryExecutor_TableLoadProgressChanged;
        }

        public DatabaseDetailsViewModel()
        {
        }

        #region Commands
        public ICommand Refresh { get; private set; }
        #endregion

        #region Binding Data
        public string WindowCaption { get; private set; }
        public ObservableCollection<TableInfoViewItem> ItemsToShow { get; set; }
        public Characteristic CharacteristicToDisplay
        {
            get { return _characteristicToDisplay; }
            set
            {
                _characteristicToDisplay = value;
                OnPropertyChanged("CharacteristicToDisplay");
                RefreshBindingSourceForChart();
            }
        }
        public int? NumValues
        {
            get { return _numValues; }
            set
            {
                _numValues = value;
                RefreshBindingSourceForChart();
            }
        }

        public bool ProgressVisible { get; private set; }
        public double ProgressValue { get; private set; }
        #endregion

        private void queryExecutor_TableLoadProgressChanged(object sender, ProgressEventArgs args)
        {
            Dispatcher.Invoke(new Action(() => ProgressValue = args.ProgressValue));
            OnPropertyChanged("ProgressValue");
        }

        private void RefreshClicked()
        {
            ThreadPool.QueueUserWorkItem(delegate
                {
                    Dispatcher.Invoke(new Action(() => ProgressVisible = true));
                    OnPropertyChanged("ProgressVisible");
                    Dispatcher.Invoke(new Action(() => ProgressValue = 0));
                    OnPropertyChanged("ProgressValue");
                    _tables = _queryExecutor.LoadTableList(_databaseConnectionString);
                    Dispatcher.Invoke(new Action(() => ProgressVisible = false));
                    OnPropertyChanged("ProgressVisible");
                    Dispatcher.Invoke(new Action(() => RefreshBindingSourceForChart()));
                });
        }

        private void RefreshBindingSourceForChart()
        {
            // I need to show top N items sorted by Characteristic, so we use appropriate comparer for sorting
            _tables.Sort(GetComparer());
            _tables.Reverse();
            
            // and linq to select items needed
            List<TableInfoViewItem> items = _tables
                .Take(NumValues.Value)
                .Select(x => new TableInfoViewItem(x, _characteristicToDisplay))
                .ToList();

            ItemsToShow.Clear();
            foreach (TableInfoViewItem item in items)
            {
                ItemsToShow.Add(item);
            }
        }

        private IComparer<TableInfo> GetComparer()
        {
            switch (_characteristicToDisplay)
            {
                case Characteristic.DataSize:
                    return new DataSizeComparer();
                case Characteristic.IndexSize:
                    return new IndexSizeComparer();
                case Characteristic.RowCount:
                    return new RowCountComparer();
                default:
                    throw new ArgumentException("Unknown Characteristic");
            }
        }

        public void Dispose()
        {
            _queryExecutor.TableLoadProgressChanged -= queryExecutor_TableLoadProgressChanged;          
        }
    }
}