using System;
using System.ComponentModel;
using System.Windows.Input;

namespace TCP_chat.Client
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Message { get; set; }

        public ICommand SendMessageCommand { get; }
        public ICommand SendFileCommand { get; }

        public MainWindowViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage);
            SendFileCommand = new RelayCommand(SendFile);
        }

        private void SendMessage()
        {
            // Отправка сообщения
        }

        private void SendFile()
        {
            // Отправка файла
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
