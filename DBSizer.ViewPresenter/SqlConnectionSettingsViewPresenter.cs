using System;
using DBSizer.ViewInterface;

namespace DBSizer.ViewPresenter
{
    public class SqlConnectionSettingsViewPresenter
    {
        private const string CONN_SQL = "Data Source={0};Initial Catalog={1};User ID={2};Password = {3}";
        private const string CONN_WIN = "Data Source={0};Initial Catalog={1};integrated security=SSPI;";

        private readonly ISqlConnectionSettingsView _view;
        public SqlConnectionSettingsViewPresenter(ISqlConnectionSettingsView view, 
            IWindowsIdentityProvider windowsIdentityProvider)
        {
            _view = view;
            
            _view.AuthMode = SqlAuthMode.Windows;
            _view.UserName = windowsIdentityProvider.CurrentUserName;
            _view.DisableUserNameAndPassword();            
            _view.AuthModeChanged += view_AuthModeChanged;
        }

        void view_AuthModeChanged(object sender, EventArgs e)
        {
            if (_view.AuthMode == SqlAuthMode.SqlServer)
            {
                _view.EnableUserNameAndPassword(); 
            }
            else
            {
                _view.DisableUserNameAndPassword();
            }
        }

        public string MasterDBConnectionStringCreate()
        {
            return ConnectionStringCreate("master");
        }

        public string ConnectionStringCreate(string databaseName)
        {
            if (_view.AuthMode == SqlAuthMode.SqlServer)
            {
                return string.Format(CONN_SQL, _view.ServerName, databaseName, _view.UserName, _view.Password);
            }
            else
            {
                return string.Format(CONN_WIN, _view.ServerName, databaseName);
            }
        }
    }
}