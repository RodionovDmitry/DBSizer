using System;
using DBSizer.Data;
using DBSizer.ViewInterface;

namespace DBSizer.ViewPresenter
{
    public class SqlConnectionSettingsViewPresenter
    {
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
    }
}