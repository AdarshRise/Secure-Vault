using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SQLite;

namespace SecureVault
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public class Register
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class Record
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public string EmailId { get; set; }
        [NotNull]
        public decimal Password { get; set; }
    }


    public partial class App : Application
    {
        static String databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WinFile.db"); // new location
        static SQLiteConnection db = new SQLiteConnection(databasePath);


        private void Application_Startup(object sender, StartupEventArgs e)
        {

            try
            {
                db.CreateTable<Record>();
                db.CreateTable<Register>();
            }
            catch { }

        }


        }
}
