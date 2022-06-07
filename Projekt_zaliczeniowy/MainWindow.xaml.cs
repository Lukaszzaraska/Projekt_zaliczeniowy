
using System.Windows;
using System.Windows.Controls;
using static Projekt_zaliczeniowy.Models_api;
using static Projekt_zaliczeniowy.ApiControl;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Projekt_zaliczeniowy.View;

namespace Projekt_zaliczeniowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Main.Content = new ViewDefault();
            
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            Main.Content = new ViewDefault();
        }

        private void History_Display(object sender, RoutedEventArgs e)
        {
            Main.Content = new DataHistory();
        }
    }
}
