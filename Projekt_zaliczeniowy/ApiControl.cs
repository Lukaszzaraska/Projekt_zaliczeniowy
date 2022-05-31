using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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

        


    }
}
