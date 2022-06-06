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
        //-------------------------------------------------------------------------------------
        public class Stanowisko_Pomiarowe
        {

            [JsonPropertyName("id")]
            public int ? Id { get; set; }
            [JsonPropertyName("stationId")]
            public int? StationId { get; set; }
            [JsonPropertyName("param")]
            public Param? Param { get; set; }

         
        }
        public class Param
        {
            [JsonPropertyName("paramName")]
            public string ? ParamName { get; set; }
            [JsonPropertyName("paramFormula")]
            public string? ParamFormula { get; set; }
            [JsonPropertyName("paramCode")]
            public string? ParamCode { get; set; }
            [JsonPropertyName("idParam")]
            public int IdParam { get; set; }

        }
        //-------------------------------------------------------------------------------------
        public class Jakosc_powietrza
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("stCalcDate")]
            public string? StCalcDate { get; set; }

            [JsonPropertyName("so2CalcDate")]
            public string? So2CalcDate { get; set; }

            [JsonPropertyName("so2IndexLevel")]
            public StIndexLevel? So2IndexLevel { get; set; }

            [JsonPropertyName("no2CalcDate")]
            public string? No2CalcDate { get; set; }

            [JsonPropertyName("no2IndexLevel")]
            public StIndexLevel? No2IndexLevel { get; set; }

            [JsonPropertyName("pm10CalcDate")]
            public string? Pm10CalcDate { get; set; }

            [JsonPropertyName("pm10IndexLevel")]
            public StIndexLevel? Pm10IndexLevel { get; set; }

            [JsonPropertyName("pm25CalcDate")]
            public string? Pm25CalcDate { get; set; }

            [JsonPropertyName("pm25IndexLevel")]
            public StIndexLevel? Pm25IndexLevel { get; set; }

            [JsonPropertyName("o3CalcDate")]
            public string? O3CalcDate { get; set; }

            [JsonPropertyName("o3IndexLevel")]
            public StIndexLevel? O3IndexLevel { get; set; }
        }

        public class StIndexLevel
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }
            [JsonPropertyName("indexLevelName")]
            public string? IndexLevelName { get; set; } = "Empty";
        }
    }
}
