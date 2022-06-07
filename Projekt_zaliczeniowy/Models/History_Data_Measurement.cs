using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt_zaliczeniowy.Models
{
    public class History_Data_Measurement
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Key { get; set; }
        public Valuess[]? ValuesH { get; set; }

      
    }
    public class Valuess
    {
        [Key]
        public int Id { get; set; }
        public string? Date { get; set; }

        public double? Value { get; set; }

    }

}
