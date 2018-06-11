using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HRMS_MVVM.commands
{
    class DelegateCommand:ICommand
    {
        readonly Action<Object> _execute;
        readonly Func<Object,bool> _canExecute;

        public DelegateCommand(Action<Object> execute) : this(execute, null) { }
        public DelegateCommand(Action<Object> execute,Func<Object,bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute is null!");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            if (_execute == null)
            {
                return;
            }

            _execute(parameter);
        }
    }
}
