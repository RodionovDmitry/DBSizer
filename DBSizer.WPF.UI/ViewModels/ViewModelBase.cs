using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;
using DBSizer.WPF.UI.Annotations;

namespace DBSizer.WPF.UI.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly Dispatcher _dispatcher;
        protected Dispatcher Dispatcher
        {
            get { return _dispatcher; }
        } 
        protected ViewModelBase()
        {
            if (Application.Current != null)
            {
                _dispatcher = Application.Current.Dispatcher;
            }
            else
            {
                //this is useful for unit tests where there is no application running 
                _dispatcher = Dispatcher.CurrentDispatcher;
            }
        }
    }
}