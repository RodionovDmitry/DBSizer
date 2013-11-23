using System.Collections;
using System.Windows;
using DBSizer.Data;
using DBSizer.WPF.UI.Helpers;
using DBSizer.WPF.UI.ViewInterfaces;
using DBSizer.WPF.UI.ViewModels;

namespace DBSizer.WPF.UI.Views
{
    public partial class MainWindow : Window, IMainView
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(new SqlQueryExecutor(), (IMainView)this, 
                new WindowsIdentityProvider(), new DBInfoBuilder());
        }

        public ISimpleDialogs Dialogs
        {
            get
            {
                return new WPFDialogs();
            }
        }

        public DBInfoListItem SelectedItem
        {
            get { return ListOfAllDatabases.SelectedItem as DBInfoListItem; }
        }

        public IDatabaseDetailsWindow CreateDetailsWindow()
        {
            return new DatabaseDetailsWindow();
        }

        public void ShowAboutWindow()
        {
            var window = new AboutWindow();
            window.ShowDialog();
        }
    }
}
