using System;
using System.Windows.Input;

namespace Vendor
{
    public class PassEventCommand : ICommand
    {
        private Action execute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public PassEventCommand(Action execute)
        {
            this.execute = execute;
        }

        public void Execute(object parameter)
        {
            execute.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
