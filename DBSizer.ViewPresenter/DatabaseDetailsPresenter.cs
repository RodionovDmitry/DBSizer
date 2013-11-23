using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DBSizer.Data;
using DBSizer.ViewInterface;

namespace DBSizer.ViewPresenter
{
    public class DatabaseDetailsPresenter : IDisposable
    {
        private readonly string _databaseConnectionString;
        private readonly ISqlQueryExecutor _queryExecutor;
        private readonly IDatabaseDetailsView _view;
        private List<TableInfo> _tables;
        private BackgroundWorker _loadDataWorker = new BackgroundWorker();

        public DatabaseDetailsPresenter(IDatabaseDetailsView view, ISqlQueryExecutor queryExecutor,
                                        string databaseConnectionString, string databaseName)
        {
            _view = view;
            _queryExecutor = queryExecutor;
            _databaseConnectionString = databaseConnectionString;

            _view.Shown += view_RefreshClicked;
            _view.RefreshClicked += view_RefreshClicked;
            _view.SelectedCharacteristicChanged += view_SelectedDataToDisplayChanged;
            _view.SetCaption(string.Format("Database {0} details", databaseName));

            _loadDataWorker.DoWork += loadDataWorker_DoWork;
            _loadDataWorker.WorkerReportsProgress = true;
            _loadDataWorker.ProgressChanged += loadDataWorker_ProgressChanged;
            _loadDataWorker.RunWorkerCompleted += loadDataWorker_RunWorkerCompleted;
            _queryExecutor.TableLoadProgressChanged += queryExecutor_TableLoadProgressChanged;
        }

        void queryExecutor_TableLoadProgressChanged(object sender, ProgressEventArgs args)
        {
            _loadDataWorker.ReportProgress(args.ProgressValue);
        }

        void loadDataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _tables = e.Result as List<TableInfo>;
            _view.HideProgressBar();
            view_SelectedDataToDisplayChanged(sender, e);
        }

        void loadDataWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _view.SetProgress(e.ProgressPercentage);
        }

        void loadDataWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = _queryExecutor.LoadTableList(_databaseConnectionString);
        }

        private IComparer<TableInfo> GetComparer()
        {
            if (_view.SelectedCharacteristic == Characteristic.DataSize)
            {
                return new DataSizeComparer();
            }
            if (_view.SelectedCharacteristic == Characteristic.IndexSize)
            {
                return new IndexSizeComparer();
            }
            if (_view.SelectedCharacteristic == Characteristic.RowCount)
            {
                return new RowCountComparer();
            }

            throw new ArgumentException("no Comparer for " + _view.SelectedCharacteristic);
        }

        private void view_SelectedDataToDisplayChanged(object sender, EventArgs e)
        {
            if (_tables == null)
            {
                return;
            }
            _tables.Sort(GetComparer());
            _tables.Reverse();
            _view.SetChartDataSource(
                _tables
                    .Take(_view.NumTopValues)
                    .Select(x => new TableInfoViewItem(x, _view.SelectedCharacteristic))
                    .ToList());
        }


        private void view_RefreshClicked(object sender, EventArgs e)
        {
            _view.ShowProgressBar();
            _loadDataWorker.RunWorkerAsync();            
        }

        public void Dispose()
        {
            _queryExecutor.TableLoadProgressChanged -= queryExecutor_TableLoadProgressChanged;
            _view.Shown -= view_RefreshClicked;
            _view.RefreshClicked -= view_RefreshClicked;
            _view.SelectedCharacteristicChanged -= view_SelectedDataToDisplayChanged;
            _loadDataWorker.DoWork -= loadDataWorker_DoWork;
            _loadDataWorker.ProgressChanged -= loadDataWorker_ProgressChanged;
            _loadDataWorker.RunWorkerCompleted -= loadDataWorker_RunWorkerCompleted;
        }
    }
}