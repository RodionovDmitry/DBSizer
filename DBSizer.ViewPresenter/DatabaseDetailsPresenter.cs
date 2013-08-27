using System;
using System.Collections.Generic;
using System.Linq;
using DBSizer.Data;
using DBSizer.ViewInterface;

namespace DBSizer.ViewPresenter
{
    public class DatabaseDetailsPresenter
    {
        private readonly string _databaseConnectionString;
        private readonly ISqlQueryExecutor _queryExecutor;
        private readonly IDatabaseDetailsView _view;
        private List<TableInfo> _tables;

        public DatabaseDetailsPresenter(IDatabaseDetailsView view, ISqlQueryExecutor queryExecutor,
                                        string databaseConnectionString, string databaseName)
        {
            _view = view;
            _queryExecutor = queryExecutor;
            _databaseConnectionString = databaseConnectionString;

            _view.Shown += view_RefreshClicked;
            _view.RefreshClicked += view_RefreshClicked;
            _view.SelectedDataToDisplayChanged += view_SelectedDataToDisplayChanged;
            _view.SetCaption(string.Format("Database {0} details", databaseName));
        }


        private IComparer<TableInfo> GetComparer()
        {
            if (_view.SelectedDataToDisplay == DataToDisplay.DataSize)
            {
                return new DataSizeComparer();
            }
            if (_view.SelectedDataToDisplay == DataToDisplay.IndexSize)
            {
                return new IndexSizeComparer();
            }
            if (_view.SelectedDataToDisplay == DataToDisplay.RowCount)
            {
                return new RowCountComparer();
            }

            throw new ArgumentException("no Comparer for " + _view.SelectedDataToDisplay);
        }

        private void view_SelectedDataToDisplayChanged(object sender, EventArgs e)
        {
            if (_tables == null)
            {
                return;
            }
            _tables.Sort(GetComparer());
            _view.SetChartDataSource(
                _tables
                    .Take(_view.NumTopValues)
                    .Select(x => new TableInfoViewItem(x, _view.SelectedDataToDisplay))
                    .ToList());
        }


        private void view_RefreshClicked(object sender, EventArgs e)
        {
            _view.ShowProgressBar();
            _tables = _queryExecutor.LoadTableList(_databaseConnectionString, _view);
            _view.HideProgressBar();
            view_SelectedDataToDisplayChanged(sender, e);
        }
    }
}