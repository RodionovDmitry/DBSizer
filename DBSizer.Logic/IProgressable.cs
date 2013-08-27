namespace DBSizer.Data
{
    /// <summary>
    /// Sometihng, that able to report progress
    /// </summary>
    public interface IProgressable
    {
        void SetMaximumProgress(int max);
        void IncProgress();
    }
}