using Microsoft.EntityFrameworkCore;
using Projekt_zaliczeniowy.Data;
using Projekt_zaliczeniowy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Projekt_zaliczeniowy.Models_api;

namespace Projekt_zaliczeniowy.Services
{
    public static class HistoryRepository
    {

        private static DataContext _context = new();

        public static void AddHistory(Dane_pomiarowe history)
        {
            _context.history_Data_Measurements.Add(history);
            _context.SaveChanges();
        }
        public static IList<Dane_pomiarowe> GetHistory()
        {
            return _context.history_Data_Measurements.Include(x => x.IValues).ToList();
        }
    }
}
