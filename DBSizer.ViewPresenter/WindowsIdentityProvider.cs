using System.Security.Principal;

namespace DBSizer.ViewPresenter
{
    public interface IWindowsIdentityProvider
    {
        string CurrentUserName { get; }
    }


    public class WindowsIdentityProvider : IWindowsIdentityProvider
    {
        public string CurrentUserName
        {
            get
            {
                var identity = WindowsIdentity.GetCurrent();
                if (identity != null)
                    return identity.Name;
                return string.Empty;
            }
        }
    }
}