using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TimeTracker.ViewModel
{
    class CommandHandler : ICommand
    {
        private bool _canExecute;
        private Action _action;
        public event EventHandler CanExecuteChanged;

        public CommandHandler(Action action, bool canExecute)
        {
            _canExecute = canExecute;
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
