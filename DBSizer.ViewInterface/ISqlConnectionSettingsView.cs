using System;
using DBSizer.Data;

namespace DBSizer.ViewInterface
{
    public interface ISqlConnectionSettingsView : IConnectionSettings
    {
        new SqlAuthMode AuthMode { get; set; }
        new string UserName { get;  set; }

        event EventHandler AuthModeChanged;

        void DisableUserNameAndPassword();
        void EnableUserNameAndPassword();
    }
}