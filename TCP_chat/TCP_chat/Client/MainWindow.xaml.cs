using System;
using System.Drawing;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using TCP_chat.Client;
using static System.Net.Mime.MediaTypeNames;

namespace TCP_chat.Client
{
    public partial class MainWindow : Window
    {
        // Добавляем свойство для хранения текущей темы
        private bool isDarkTheme = false;

        public MainWindow DataContext { get; }
        public RelayCommand SendMessageCommand { get; }
        public RelayCommand SendFileCommand { get; }
        public RelayCommand ToggleThemeCommand { get; }
        public string? MessageText { get; private set; }
        public Action<object, object> SendMessage { get; internal set; }
        public Action<object, object> SendFile { get; internal set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Инициализируем команды
            SendMessageCommand = new RelayCommand(SendMessageExecute, CanSendMessageExecute);
            SendFileCommand = new RelayCommand(SendFileExecute, CanSendFileExecute);
            ToggleThemeCommand = new RelayCommand(ToggleThemeExecute);
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        // Метод для отправки сообщения
        private void SendMessageExecute()
        {
            // Проверяем, что сообщение не пустое
            if (!string.IsNullOrEmpty(MessageText))
            {
                // Вызываем событие SendMessage и передаем сообщение
                SendMessage?.Invoke(this, MessageText);

                // Очищаем текстовое поле после отправки сообщения
                MessageText = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter a message before sending.");
            }
        }

        // Метод для отправки файла
        private void SendFileExecute()
        {
            // Открываем диалоговое окно для выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                // Получаем путь к выбранному файлу
                string filePath = openFileDialog.FileName;

                // Вызываем событие SendFile и передаем путь к файлу
                SendFile?.Invoke(this, filePath);

                MessageBox.Show($"File \"{Path.GetFileName(filePath)}\" has been sent.");
            }
        }

        // Метод для проверки возможности отправки сообщения
        private bool CanSendMessageExecute(object arg)
        {
            // Разрешаем отправку сообщения только если поле ввода не пустое
            return !string.IsNullOrEmpty(MessageText);
        }

        // Метод для проверки возможности отправки файла
        private bool CanSendFileExecute(object arg)
        {
            // В данном примере всегда разрешаем отправку файла
            return true;
        }

        // Метод для переключения темы
        private void ToggleThemeExecute(object parameter)
        {
            // Инвертируем текущую тему
            isDarkTheme = !isDarkTheme;

            // Обновляем цветовую схему
            UpdateColorScheme();

            // Обновляем анимацию
            UpdateAnimation();
        }

        // Метод для обновления цветовой схемы
        private void UpdateColorScheme()
        {
            if (isDarkTheme)
            {
                // Устанавливаем темную тему
                Application.Current.Resources["PrimaryColor"] = Colors.Gray;
                Application.Current.Resources["SecondaryColor"] = Colors.DarkGray;
                Application.Current.Resources["AccentColor"] = Colors.Orange;
                Application.Current.Resources["AccentDarkColor"] = Colors.DarkOrange;
            }
            else
            {
                // Устанавливаем светлую тему
                Application.Current.Resources["PrimaryColor"] = Colors.Blue;
                Application.Current.Resources["SecondaryColor"] = Colors.Pink;
                Application.Current.Resources["AccentColor"] = Colors.Yellow;
                Application.Current.Resources["AccentDarkColor"] = Colors.Orange;
            }
        }

        // Метод для обновления анимации
        private void UpdateAnimation()
        {
            // Получаем анимацию появления сообщения из ресурсов
            Storyboard messageAppearAnimation = (Storyboard)FindResource("MessageAppearAnimation");
            // Устанавливаем длительность анимации в зависимости от темы
            messageAppearAnimation.Duration = isDarkTheme ? TimeSpan.FromSeconds(0.3) : TimeSpan.FromSeconds(0.5);
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }

        internal void DisplayMessage(string message)
        {
            throw new NotImplementedException();
        }
    }
}
