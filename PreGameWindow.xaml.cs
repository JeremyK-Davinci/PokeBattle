using PokeBattle.Pages;
using PokeBattle.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PokeBattle
{
    /// <summary>
    /// Interaction logic for PreGameWindow.xaml
    /// </summary>
    public partial class PreGameWindow : Window
    {
        public static PreGameWindow _Window;

        public PreGameWindow()
        {
            InitializeComponent();
            _Window = this;
        }

        private void MainLeftMouseDown(object sender, MouseButtonEventArgs e) => this.DragMove();
        private void CloseApp(object sender, MouseButtonEventArgs e) => this.Close();
        private void NavToggleChecked(object sender, RoutedEventArgs e) => OverlayObject.Visibility = Visibility.Visible;
        private void NavToggleUnchecked(object sender, RoutedEventArgs e) => OverlayObject.Visibility = Visibility.Hidden;
        private void OpenGamePage(object sender, MouseButtonEventArgs e)
        {
            if (Utility.ActivePage != null && Utility.ActivePage is GamePage) return;
            GamePage gamePage = new GamePage();
            Utility.ActivePage = gamePage;
            PageFrame.Content = gamePage;
        }
        private void OpenSettingsPage(object sender, MouseButtonEventArgs e)
        {
            if (Utility.ActivePage != null && Utility.ActivePage is SettingsPage) return;
            SettingsPage settingsPage = new SettingsPage();
            Utility.ActivePage = settingsPage;
            PageFrame.Content = settingsPage;
        }
        private void OpenInfoPage(object sender, MouseButtonEventArgs e)
        {
            if (Utility.ActivePage != null && Utility.ActivePage is InfoPage) return;
            InfoPage infoPage = new InfoPage();
            Utility.ActivePage = infoPage;
            PageFrame.Content = infoPage;
        }

        public void CloseCurrentPage()
        {
            Utility.ActivePage = null;
            PageFrame.Content = null;
        }
    }
}
