using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_TinyEd.ViewModels.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action executeAction;
        private Func<bool> canExecuteFunc;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action executeAction, Func<bool> canExecuteFunc)
        {
            this.executeAction = executeAction;
            this.canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteFunc?.Invoke() ?? true;
        }

        public void Execute(object parameter)
        {
            executeAction?.Invoke();
        }
    }
}
