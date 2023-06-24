using System;
using System.Windows.Input;
namespace Binance.MVVM
{
    class DelegateCommand : ICommand
    {
        private readonly Action<object> _action;
        private Action load5minOhlc;

        public DelegateCommand(Action<object>action)
        {
            _action = action;
        }

        public DelegateCommand(Action load5minOhlc)
        {
            this.load5minOhlc = load5minOhlc;
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }
        

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
