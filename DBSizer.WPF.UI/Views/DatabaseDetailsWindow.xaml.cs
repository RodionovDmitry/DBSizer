using System.Windows;
using DBSizer.WPF.UI.ViewInterfaces;
using DBSizer.WPF.UI.ViewModels;

namespace DBSizer.WPF.UI.Views
{
    /// <summary>
    /// Interaction logic for DatabaseDetailsWindow.xaml
    /// </summary>
    public partial class DatabaseDetailsWindow : Window, IDatabaseDetailsWindow
    {
        public DatabaseDetailsWindow()
        {
            InitializeComponent();
        }
    }
}
