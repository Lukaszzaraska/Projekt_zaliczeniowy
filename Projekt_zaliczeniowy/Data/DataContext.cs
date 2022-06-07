
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Projekt_zaliczeniowy.Models;
using static Projekt_zaliczeniowy.Models_api;

namespace Projekt_zaliczeniowy.Data
{
   public class DataContext : DbContext
    {
        public DbSet<Dane_pomiarowe> history_Data_Measurements { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            optionsBuilder.UseSqlite("Data Source=./DataBase.db", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);

            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dane_pomiarowe>().ToTable("history_Data_Measurements");

        }
    }
}
