using System.Windows;

namespace DBSizer.WPF.UI.Helpers
{
    public class WPFDialogs : ISimpleDialogs
    {
        public bool Confirm(string text)
        {
            return MessageBox.Show(text, "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public void Info(string text)
        {
            MessageBox.Show(text, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void Error(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}