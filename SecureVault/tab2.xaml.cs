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
using System.Data.SQLite;
namespace SecureVault
{
    /// <summary>
    /// Interaction logic for tab2.xaml
    /// </summary>
    /// 



    public partial class tab2 : UserControl
    {
        //static String databasePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WinFile.db"); // new location
        //static string dbcon = @"data Source=" + databasePath + ";Version=3;";

        
        System.Data.SQLite.SQLiteConnection sqlcon = new System.Data.SQLite.SQLiteConnection(getInfo.dbcon);
        //SQLiteConnection db = new SQLiteConnection(databasePath);
        public tab2()
        {
            InitializeComponent();
            
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if( string.IsNullOrWhiteSpace(nametxt.Text))
            {
                MessageBox.Show("Error in Name Field, Please Check it again.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
          else  if (string.IsNullOrWhiteSpace(Idtxt.Text))
            {
                MessageBox.Show("Error in Vault Id Field, Please Check it again.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
           else if (string.IsNullOrWhiteSpace(Passtxt.Password))
            {
                MessageBox.Show("Error in Password Field, Please Check it again.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
           else if (string.IsNullOrWhiteSpace(RePasstxt.Password))
            {
                MessageBox.Show("Error in Re-Pass Field, Please Check it again.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                
            }
          else  if (!string.IsNullOrWhiteSpace(nametxt.Text) && !string.IsNullOrWhiteSpace(Idtxt.Text) && !string.IsNullOrWhiteSpace(Passtxt.Password) && !string.IsNullOrWhiteSpace(RePasstxt.Password) && RePasstxt.Password == Passtxt.Password)
            {
                sqlcon.Open();
                //MessageBox.Show(sqlcon.ToString());
                string query = "insert into Register values(null,'" + nametxt.Text + "','" + Idtxt.Text + "','" + RePasstxt.Password + "');";
                SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(query, sqlcon);
                com.ExecuteNonQuery();
                MessageBox.Show("Welcome , You have been successefully registered ", "Registration Completed", MessageBoxButton.OK, MessageBoxImage.Information);
                sqlcon.Close();

            }
            else
            {
                MessageBox.Show("Pass Code are not same, Please Check it again.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
           // MessageBox.Show(RePasstxt.Password);// this works


        }
    }
}
