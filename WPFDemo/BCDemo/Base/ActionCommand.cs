using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BCDemo.Base
{
    public class ActionCommand : ICommand
    {
        private Predicate<FrameworkElement> _canExecute;
        private FrameworkElement _frameworkElement;
        private Action<object> _func;
        public ActionCommand(Predicate<FrameworkElement> canExecute, FrameworkElement element, Action<object> executeProc)
        {
            _canExecute = canExecute;
            _frameworkElement = element;
            _func = executeProc;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute(_frameworkElement);
        }

        public void Execute(object parameter)
        {
            _func(parameter);
        }
    }
}
