using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using static Projekt_zaliczeniowy.Models;

namespace Projekt_zaliczeniowy
{
    internal class ApiControl
    {
     
            public static IList<string> Miasta()
            {
                WebClient client = new WebClient();
                string json = client.DownloadString("https://api.gios.gov.pl/pjp-api/rest/station/findAll");
                var stacje_pomiarowe = JsonSerializer.Deserialize<IList<Stacja_Pomiarowa>>(json);
                IList<string> lista_miast = new List<string>();

            foreach (var dept in stacje_pomiarowe)
            {
                lista_miast.Add(dept.City.Name);
            }
            IList<string> lista_miasta = lista_miast.Distinct().ToList();

            return lista_miasta;
            }
        public static IList<Stanowisko_Pomiarowe> Stacje(string city)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString("https://api.gios.gov.pl/pjp-api/rest/station/findAll");
            var stacje_pomiarowe = JsonSerializer.Deserialize<List<Stacja_Pomiarowa>>(json);

            int Id_stacji = stacje_pomiarowe.First(x => x.City.Name == city).Id;

            string json_stacji = client.DownloadString($"https://api.gios.gov.pl/pjp-api/rest/station/sensors/{Id_stacji}");
            var stanowiska_pomiarowe = JsonSerializer.Deserialize<List<Stanowisko_Pomiarowe>>(json_stacji);
          
           
            return stanowiska_pomiarowe;
        }
        public static Jakosc_powietrza Air_Qualities(int Id)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString($"https://api.gios.gov.pl/pjp-api/rest/aqindex/getIndex/{Id}");
            var Indeks_powietrza = JsonSerializer.Deserialize<Jakosc_powietrza>(json);

            return Indeks_powietrza;
        }
        public static Dane_pomiarowe Measurement_data(int Id)
        {
            WebClient client = new WebClient();
            string json = client.DownloadString($"https://api.gios.gov.pl/pjp-api/rest/data/getData/{Id}");
            var Measurement = JsonSerializer.Deserialize<Dane_pomiarowe>(json);

            return Measurement;
        }
        public static void Color_Air(TextBlock data)
        {
            if(data.Text.Equals("Bardzo dobry"))
            {
                data.Background = Brushes.Green;
            }else if(data.Text.Equals("Dobry"))
            {
                data.Background = Brushes.GreenYellow;
            }
            else if (data.Text.Equals("Umiarkowany"))
            {
                data.Background = Brushes.Yellow;
            }
            else if (data.Text.Equals("Dostateczny"))
            {
                data.Background = Brushes.OrangeRed;
            }
            else if (data.Text.Equals("Zły"))
            {
                data.Background = Brushes.Red;
            }
            else if (data.Text.Equals("Bardzo zły"))
            {
                data.Background = Brushes.Purple;
            }
            else
            {
                data.Background = Brushes.Gray;
            }
        }
    }
}
