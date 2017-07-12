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
        private Action<object> _action;
        private Action _actionNoPar;
        public event EventHandler CanExecuteChanged;

        public CommandHandler(Action<object> action, bool canExecute)
        {
            _canExecute = canExecute;
            _action = action;
        }

        public CommandHandler(Action action, bool canExecute)
        {
            _canExecute = canExecute;
            _actionNoPar = action;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public bool CanExecute()
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        public void Execute()
        {
            _actionNoPar();
        }
    }
}
