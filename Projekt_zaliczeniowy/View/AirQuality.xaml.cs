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
using static Projekt_zaliczeniowy.Models_api;
using static Projekt_zaliczeniowy.ApiControl;


namespace Projekt_zaliczeniowy.View
{
    /// <summary>
    /// Logika interakcji dla klasy air_quality.xaml
    /// </summary>
    public partial class AirQuality : UserControl
    { 
        public AirQuality(int id)
        {
            InitializeComponent();

            var data = Air_Qualities(id);
            Id_Air.Text = $"{data.Id}";
            StCalcDate.Text = $"{data.StCalcDate}";

            so2.Text = data.So2IndexLevel?.IndexLevelName ?? "Empty";
            Color_Air(so2);
            pm25.Text = data.Pm25IndexLevel?.IndexLevelName??"Empty" ;
            Color_Air(pm25);
            no2.Text = data.No2IndexLevel?.IndexLevelName ?? "Empty";
            Color_Air(no2);
            o3.Text = data.O3IndexLevel?.IndexLevelName ?? "Empty";
            Color_Air(o3);
            pm10.Text = data.Pm10IndexLevel?.IndexLevelName ?? "Empty";
            Color_Air(pm10);

        }



    }
}
