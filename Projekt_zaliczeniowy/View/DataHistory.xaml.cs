
using Projekt_zaliczeniowy.Services;
using System;
using System.Windows.Controls;


namespace Projekt_zaliczeniowy.View
{
    /// <summary>
    /// Logika interakcji dla klasy DataHistory.xaml
    /// </summary>
    public partial class DataHistory : UserControl
    {
        public DataHistory()
        {
            InitializeComponent();
            DataContext = this;
            DataHistoryTable.ItemsSource = HistoryRepository.GetHistory();
        }
    }
}
