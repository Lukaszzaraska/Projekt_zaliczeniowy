using Projekt_zaliczeniowy.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace Projekt_zaliczeniowy
{
    /// <summary>
    /// Logika interakcji dla klasy ViewDefault.xaml
    /// </summary>
    public partial class ViewDefault : UserControl, INotifyPropertyChanged
    {
        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {

                selectedItem = value;
                StacjeTable.ItemsSource = Stacje(selectedItem);
             
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

       /* private ObservableCollection<string> observableCollectionStation;
        public ObservableCollection<string> ObservableCollectionStation
        {
            get { return observableCollectionStation; }
            set
            {
                observableCollectionStation = value;
                Onpropertychanged(nameof(ObservableCollectionStation));
            }*/
        //}
        public ViewDefault()
        {
            InitializeComponent();
            DataContext = this;
            ObservableCollectionCity = new ObservableCollection<string>(Miasta());
            
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void Onpropertychanged([CallerMemberName] string? propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
   
        private void Aqi_Click(object sender, RoutedEventArgs e)//air quality inedx
        {


            var Button = sender as Button;
            var data = Button.Tag;
            Content = new AirQuality(int.Parse(data.ToString()));

        }

        private void Md_Click(object sender, RoutedEventArgs e)//air quality inedx
        {
            var Button = sender as Button;
            var data = Button.Tag;
           // Content = new Md(int.Parse(data.ToString()));
        }
    }
}
