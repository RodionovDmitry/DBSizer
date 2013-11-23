using DBSizer.Data;

namespace DBSizer.WPF.UI.ViewModels
{
    public class SqlConnectionSettingsViewModel : ViewModelBase, IConnectionSettings
    {
        private readonly IWindowsIdentityProvider _windowsIdentityProvider;
        public SqlConnectionSettingsViewModel(IWindowsIdentityProvider windowsIdentityProvider)
        {
            _windowsIdentityProvider = windowsIdentityProvider;
            AuthenticationMode = (int)SqlAuthMode.Windows;
        }

        public string ServerName { get; set; }
        private SqlAuthMode _authenticationMode;
        public int AuthenticationMode
        {
            get { return (int) _authenticationMode; } 
            set
            {
                _authenticationMode = (SqlAuthMode)value;
                if (value == (int)SqlAuthMode.Windows)
                {
                    UserName = _windowsIdentityProvider.CurrentUserName;
                }
                OnPropertyChanged("UserNameAndPasswordEnabled");
                OnPropertyChanged("UserName");
            }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public SqlAuthMode AuthMode { get { return _authenticationMode; } }

        public bool UserNameAndPasswordEnabled
        {
            get { return _authenticationMode == SqlAuthMode.SqlServer; }
        }
    }
}