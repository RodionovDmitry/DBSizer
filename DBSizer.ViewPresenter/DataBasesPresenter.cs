using System;
using System.Collections.Generic;
using System.Linq;
using DBSizer.Data;
using DBSizer.ViewInterface;

namespace DBSizer.ViewPresenter
{
    public class DataBasesPresenter
    {
        private readonly ISqlQueryExecutor _sqlExecutor;
        private readonly IDataBasesView _view;
        private SqlConnectionSettingsViewPresenter _settingsPresenter;
        private readonly IDBInfoBuilder _dbInfoBuilder;
        private readonly IWindowsIdentityProvider _windowsIdentityProvider;
        private const int DEFAULT_NUM_OF_DB_TO_SHOW = 7;

        public DataBasesPresenter(IDataBasesView view, 
            ISqlQueryExecutor sqlExecutor, 
            IWindowsIdentityProvider windowsIdentityProvider,
            IDBInfoBuilder dbInfoBuilder)
        {
            _view = view;
            _sqlExecutor = sqlExecutor;
            _windowsIdentityProvider = windowsIdentityProvider;
            _dbInfoBuilder = dbInfoBuilder;
            _view.Shown += _view_Shown;
            _view.ConnectClicked += _view_ConnectClicked;
            _view.DataBaseCheckedChanged += _view_DataBaseCheckedChanged;
            _view.AnalyseClicked += _view_AnalyseClicked;
        }

        private void _view_AnalyseClicked(object sender, EventArgs e)
        {
            if (_view.SelectedDatabase != null)
            {
                using (IDatabaseDetailsView detailsView = _view.CreateDatabaseDetailsView())
                {
                    using (var presenter = new DatabaseDetailsPresenter(detailsView, _sqlExecutor,
                                                                        ConnectionStringBuilder.ConnectionStringCreate(_view.SettingsView, _view.SelectedDatabase.Name),
                                                                        _view.SelectedDatabase.Name))
                    {
                        detailsView.ShowModal();
                    }
                }
            }
        }

        private void _view_DataBaseCheckedChanged(object sender, EventArgs e)
        {
            _view.SetChartDataSource(_view.CheckedDatabases().ToList());
        }

        private void _view_ConnectClicked(object sender, EventArgs e)
        {
            if (!_sqlExecutor.ConnectionIsValid(ConnectionStringBuilder.MasterDBConnectionStringCreate(_view.SettingsView)))
            {
                _view.ShowError(@"Can't connect to server. Check connection settings, and make sure you have rights to connect that server.");
                return;
            }
            var databases = new List<IDBInfo>();
            foreach (string dbName in _sqlExecutor.LoadDatabaseList(ConnectionStringBuilder.MasterDBConnectionStringCreate(_view.SettingsView)))
            {
                var dbInfo = _dbInfoBuilder.Create(ConnectionStringBuilder.ConnectionStringCreate(_view.SettingsView, dbName), dbName);
                databases.Add(dbInfo);
            }
            _view.SetDbListDataSource(databases, databases.OrderByDescending(x => x.TotalSizeMB).Take(DEFAULT_NUM_OF_DB_TO_SHOW).ToList());
        }

        private void _view_Shown(object sender, EventArgs e)
        {
            _settingsPresenter = new SqlConnectionSettingsViewPresenter(_view.SettingsView, _windowsIdentityProvider);
        }
    }
}