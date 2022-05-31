using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Projekt_zaliczeniowy
{
    internal class Models
    {
       public class Stacja_Pomiarowa
        {
            [JsonPropertyName("id")]
            public int Id {get;set;}
            [JsonPropertyName("stationName")]
            public string? StationName {get;set;}
            [JsonPropertyName("gegrLat")]
            public string? GegrLat { get;set;}
            [JsonPropertyName("gegrLon")]
            public string? GegrLon { get; set; }
            [JsonPropertyName("city")]
            public City? City {get;set;}
        }
       public class City
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("name")]
            public string? Name { get; set; }
            [JsonPropertyName("commune")]
            public Commune? Commune { get; set; }
        }
      public  class Commune
        {
            [JsonPropertyName("communeName")]
            public string? CommuneName { get; set; }
            [JsonPropertyName("districtName")]
            public string? DistrictName { get; set; }
            [JsonPropertyName("provinceName")]
            public string? ProvinceName { get; set; }
        }
    }
}
