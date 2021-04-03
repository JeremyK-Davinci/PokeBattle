using System;
using System.Collections.Generic;
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

namespace PokeBattle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Index : Window
    {
        public Index()
        {
            InitializeComponent();
        }

        private void MainLeftMouseDown(object sender, MouseButtonEventArgs e) => this.DragMove();

        private void OnStartPressed(object sender, RoutedEventArgs e)
        {
            PreGameWindow gw = new PreGameWindow();
            gw.Show();
            this.Close();
        }
    }
}
