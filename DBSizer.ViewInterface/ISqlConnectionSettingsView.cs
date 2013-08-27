using System;

namespace DBSizer.ViewInterface
{
    public interface ISqlConnectionSettingsView
    {
        string ServerName { get; }
        SqlAuthMode AuthMode { get; set; }
        string UserName { get; set; }
        string Password { get; }

        event EventHandler AuthModeChanged;

        void DisableUserNameAndPassword();
        void EnableUserNameAndPassword();
    }
}