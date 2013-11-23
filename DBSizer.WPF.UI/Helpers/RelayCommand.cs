using System;
using System.Windows.Input;

namespace DBSizer.WPF.UI
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private Func<bool> _canExecute;
        public RelayCommand(Action execute)
        {
            _execute = execute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public void Execute(object parameter)
        {
            _execute();
        }

        public virtual bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;
            else
            {
                return _canExecute();
            }
        }

        public void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        public event EventHandler CanExecuteChanged;
    }
}