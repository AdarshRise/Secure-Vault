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
    /*
    public class Register
    {
        [AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        [PrimaryKey]
        public string VaultID { get; set; }
        public string Password { get; set; }
    }

    public class Record
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public string EmailId { get; set; }
        [NotNull]
        public string Password { get; set; }
    }
    */

    public partial class App : Application
    {
        System.Data.SQLite.SQLiteConnection sqlcon = new System.Data.SQLite.SQLiteConnection(getInfo.dbcon);


        protected override void OnStartup(StartupEventArgs e)
        {
            Window start = new MainWindow();

            try
            {
                sqlcon.Open();
               // MessageBox.Show(sqlcon.ToString());
                string query = " Create table Register (Id int ,name varchar(40),VaultID varchar(40) primary key, Password varchar(40) );";
                // string query = "insert into Stock values(null,'" + NewConAdd.Text + "');";
                System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(query, sqlcon);
                com.ExecuteNonQuery();
                query = "Create table Record(Id int,EmailID varchar(40) primary key,Password varchar(40) not null );";
                com = new System.Data.SQLite.SQLiteCommand(query, sqlcon);
                com.ExecuteNonQuery();
                sqlcon.Close();
            }
            catch
            {
                MessageBox.Show("New Update will come soon");
            }
            start.Show();



        }

        // static String databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WinFile.db"); // new location
        // static SQLiteConnection db = new SQLiteConnection(databasePath);

        //protected override void  OnStartup(StartupEventArgs e){}


    }
}
