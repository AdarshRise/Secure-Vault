using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLite;

namespace SecureVault
{
    /// <summary>
    /// Interaction logic for Tab1.xaml
    /// </summary>
    /// 

  


    public partial class Tab1 : UserControl
    {

        static String databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WinFile.db"); // new location
        SQLiteConnection db = new SQLiteConnection(databasePath);



        public static void AddUser(SQLiteConnection db, string name,string pass)
        {
            var user = new Register()
            {
                Name = name,
                Password=pass
            };
            db.Insert(user);
            MessageBox.Show("Your Entry Has been Registered, You are our new User now.", " Welcome New User", MessageBoxButton.OK, MessageBoxImage.Information);
            
        }


        public static void VerifyUser(SQLiteConnection db, string name,string pass)
        {
            var user = new Register()
            {
                Name = name,
                Password = pass
            };


            try
            {



                //var t= db.Execute("select * from Register where Name = ? and Password = ?", user.Name, user.Password);
/*
                var query = db.Table<Register>().Where(v => v.Name.);

                foreach (var stock in query)
                    Console.WriteLine("Stock: " + stock.Symbol);


                MessageBox.Show(" Welcome User, Happy to see you again. ", " Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                */




            }
            catch( Exception error)
            {
                MessageBox.Show(" Error in login, Is your Id and Password Correct? ", " Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(error.ToString());
            }
            
        }



        public Tab1()
        {
            InitializeComponent();

        }

        private void LoginBut_Click(object sender, RoutedEventArgs e)
        {
            VerifyUser(db, Logintxt.Text, passtxt.Text); ;
        }
    }
}
