using System.ComponentModel;
using DBSizer.Data;
using DBSizer.WPF.UI.Annotations;
using DBSizer.WPF.UI.ViewInterfaces;

namespace DBSizer.WPF.UI.ViewModels
{
    /// <summary>
    ///     Wrapper for IDBInfo to show on WPF view
    /// </summary>
    public class DBInfoListItem : INotifyPropertyChanged
    {
        private readonly IRefreshChartBinding _chart;
        private bool _isChecked;

        public DBInfoListItem(IDBInfo item, IRefreshChartBinding chart)
        {
            Item = item;
            _isChecked = false;
            _chart = chart;
        }

        public double LogSize
        {
            get { return Item.LogSizeMB; }
        }

        public double DataSize
        {
            get { return Item.DataSizeMB; }
        }

        public IDBInfo Item { get; private set; }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                _chart.RefreshChartBinding();
                OnPropertyChanged("IsChecked");
            }
        }

        public string ShortName
        {
            get { return Item.Name; }
        }

        public string DisplayName
        {
            get { return Item.ToString(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}