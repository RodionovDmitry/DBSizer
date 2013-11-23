using System.Collections;
using System.Windows;
using DBSizer.WPF.UI.Helpers;
using DBSizer.WPF.UI.ViewModels;

namespace DBSizer.WPF.UI.ViewInterfaces
{
    public interface IMainView
    {
        ISimpleDialogs Dialogs { get; }
        DBInfoListItem SelectedItem { get; }

        IDatabaseDetailsWindow CreateDetailsWindow();
        void ShowAboutWindow();
    }
}