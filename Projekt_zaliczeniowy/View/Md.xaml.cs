using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Projekt_zaliczeniowy.ApiControl;

namespace Projekt_zaliczeniowy.View
{
    /// <summary>
    /// Logika interakcji dla klasy Md.xaml
    /// </summary>
    public partial class Md : Window, INotifyPropertyChanged
    {
        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {

                selectedItem = value;
                  //StacjeTable.ItemsSource = Stacje(selectedItem);
                //ObservableCollectionStation = new ObservableCollection<string>(Stacje(selectedItem));
                Onpropertychanged(nameof(SelectedItem));
                // MessageBox.Show(SelectedItem);
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

        private ObservableCollection<string> observableCollectionStation;
        public ObservableCollection<string> ObservableCollectionStation
        {
            get { return observableCollectionStation; }
            set
            {
                observableCollectionStation = value;
                Onpropertychanged(nameof(ObservableCollectionStation));
            }
        }
        public Md()
        {
            ObservableCollectionCity = new ObservableCollection<string>(Miasta());
            InitializeComponent();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void Onpropertychanged([CallerMemberName] string? propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void Back(object sender, RoutedEventArgs e)//air quality inedx
        {




        }
        private void Aqi_Click(object sender, RoutedEventArgs e)//air quality inedx
        {


          

        }

        private void Md_Click(object sender, RoutedEventArgs e)//air quality inedx
        {
         
        }
    }
}
