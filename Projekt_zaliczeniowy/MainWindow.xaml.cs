using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using static Projekt_zaliczeniowy.Models;
using static Projekt_zaliczeniowy.ApiControl;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Projekt_zaliczeniowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set 
            {
                selectedItem = value;
                Onpropertychanged(nameof(SelectedItem));
                MessageBox.Show(SelectedItem);
            }
        }
        private ObservableCollection<string> observableCollectionCity;
        public ObservableCollection<string> ObservableCollectionCity
        {
            get { return observableCollectionCity; }
            set
            {
                observableCollectionCity = value;
                Onpropertychanged(nameof(ObservableCollectionCity));
            }
        }

        public MainWindow()
        {
            DataContext = this;
            ObservableCollectionCity=new ObservableCollection<string>(Miasta());
            

          
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void Onpropertychanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
