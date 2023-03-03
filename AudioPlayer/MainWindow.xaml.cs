using AudioPlayer.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace AudioPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void FullScreenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }



        private void PlayMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PlayBtnIcon.Kind == MaterialDesignThemes.Wpf.PackIconKind.Pause)
            {
                PlayBtnIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Play;
            }
            else
            {
                PlayBtnIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Pause;
            }
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        public List

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            dialog.Title = "Выберите папку с музыкой";

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                // Список расширений файлов, которые мы хотим прочитать
                var fileExtensions = new List<string> { ".mp3", ".wav", ".flac" };

                // Чтение файлов из выбранной папки с заданными расширениями
                foreach (string file in Directory.GetFiles(dialog.FileName))
                {
                    if (fileExtensions.Contains(Path.GetExtension(file)))
                    {

                        audio.all.Add(new audio(Path.GetFullPath(file)));


                    }
                }
            }
        }
    }
}

