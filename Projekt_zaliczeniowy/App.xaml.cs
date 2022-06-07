using Projekt_zaliczeniowy.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt_zaliczeniowy
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DataContext dbContext = new();

        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.Database.EnsureCreatedAsync();
            await dbContext.SaveChangesAsync();

            MainWindow main = new();
            main.Show();

        }
    }
}
