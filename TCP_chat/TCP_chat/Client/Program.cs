using System;
using System.Windows;

namespace TCP_chat.Client
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var mainWindow = new MainWindow();
            var networkClient = new NetworkClient("UserName");

            // Подписываемся на событие отправки сообщений из MainWindow и отправляем сообщение через клиента
            mainWindow.SendMessage += (sender, message) => networkClient.SendMessage(sender, message);

            // Подписываемся на событие отправки файлов из MainWindow и отправляем файл через клиента
            mainWindow.SendFile += (sender, filePath) => networkClient.SendFile(sender, filePath);

            // Подписываемся на событие получения нового сообщения из клиента и выводим его в главном окне
            networkClient.MessageReceived += (sender, message) => mainWindow.DisplayMessage(message);

            // Отображаем главное окно
            mainWindow.ShowDialog();
        }
    }
}
