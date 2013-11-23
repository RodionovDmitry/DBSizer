using System.Windows;

namespace DBSizer.WPF.UI.ViewInterfaces
{
    public interface IDatabaseDetailsWindow
    {
        event RoutedEventHandler Loaded;
        bool? ShowDialog();
        object DataContext { get; set; }
    }
}