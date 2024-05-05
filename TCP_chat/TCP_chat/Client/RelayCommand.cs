using System;
using System.Windows.Input;

namespace TCP_chat.Client
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        private Action<object> sendMessageExecute;
        private Func<object, bool> canSendMessageExecute;
        private Action<object> toggleThemeExecute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action execute, Func<object, bool> canSendMessageExecute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> sendMessageExecute, Func<object, bool> canSendMessageExecute)
        {
            this.sendMessageExecute = sendMessageExecute;
            this.canSendMessageExecute = canSendMessageExecute;
        }

        public RelayCommand(Action<object> toggleThemeExecute)
        {
            this.toggleThemeExecute = toggleThemeExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
