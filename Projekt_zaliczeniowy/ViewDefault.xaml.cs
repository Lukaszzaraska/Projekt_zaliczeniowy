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
using static Projekt_zaliczeniowy.Models_api;
using static Projekt_zaliczeniowy.ApiControl;
using Projekt_zaliczeniowy.Models;
using Projekt_zaliczeniowy.Services;

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
                StacjeTable.ToolTip = Miasta_info(selectedItem).StationName;
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

    
        public ViewDefault()
        {
            InitializeComponent();
            ObservableCollectionCity = new ObservableCollection<string>(Miasta());
            DataContext = this;
           
            
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void Onpropertychanged([CallerMemberName] string? propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
   
        private void Aqi_Click(object sender, RoutedEventArgs e)
        {


            var Button = sender as Button;
            var data = Button.Tag;
            Content = new AirQuality(int.Parse(data.ToString()));

        }

        private void Md_Click(object sender, RoutedEventArgs e)
        {
            var Button = sender as Button;
            var data = Button.Tag;
            var result = Measurement_data(int.Parse(data.ToString())) ;
            var hm = result.Values;
            Dane_pomiarowe history = new()
            {
                DateTime = DateTime.Now,
                Key = result.Key,
                IValues = result.Values,
            };

            HistoryRepository.AddHistory(history);
            Content = new Md(int.Parse(data.ToString()));
            
        }


        GridViewColumnHeader _lastHeaderClicked;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        void GridViewColumnHeaderClickedHandler(object sender,
                                                RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }
        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
            CollectionViewSource.GetDefaultView(StacjeTable.ItemsSource);
            if (dataView != null)
            {
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription(sortBy, direction);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }
          
        }
    }

}

