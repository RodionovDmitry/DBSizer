namespace DBSizer.WPF.UI.Helpers
{
    public interface ISimpleDialogs
    {
        bool Confirm(string text);
        void Info(string text);
        void Error(string text);
    }
}