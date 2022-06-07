
using System.Windows.Controls;
using static Projekt_zaliczeniowy.ApiControl;

namespace Projekt_zaliczeniowy.View
{
    /// <summary>
    /// Logika interakcji dla klasy Md.xaml
    /// </summary>
    public partial class Md : UserControl
    {
      
        public Md(int id)
        {
            InitializeComponent();
            DataContext = this;
            DanePomiaroweTable.ItemsSource = Measurement_data(id).Values;
            Key.Text = Measurement_data(id).Key;
        }
       
    }
}
