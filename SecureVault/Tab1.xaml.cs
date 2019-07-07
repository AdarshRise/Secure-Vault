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

        
        public Tab1()
        {
            InitializeComponent();

        }

        private void LoginBut_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Logintxt.Text))
            {
                MessageBox.Show("Error in Login Field, Please Check it again.", "Sign In Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            else if (string.IsNullOrWhiteSpace(passtxt.Text))
            {
                MessageBox.Show("Error in Password Field, Please Check it again.", "Sign In Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            else
            {
                //String query = " Record(Id int,EmailID varchar(40) primary key,Password varchar(40) not null );";
                string query = "select Password  from Register where VaultID='" + Logintxt.Text + "';";

                System.Data.SQLite.SQLiteConnection sqlcon = new System.Data.SQLite.SQLiteConnection(getInfo.dbcon);
                sqlcon.Open();
                System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(query, sqlcon);

                try
                {
                    com.ExecuteNonQuery();
                    System.Data.SQLite.SQLiteDataReader dr = com.ExecuteReader();
                    dr.Read();

                    //MessageBox.Show(dr["Password"].ToString());

                    if (passtxt.Text == dr["Password"].ToString())
                    {
                        MessageBox.Show("Welcome, You have logged In ", "Happy to see you again", MessageBoxButton.OK, MessageBoxImage.Information);
                       // MessageBox.Show(getInfo.getLog().ToString());
                        getInfo.setLog();
                        //MessageBox.Show(getInfo.getLog().ToString());
                    }
                    else
                    {
                        MessageBox.Show(" Error in login, Is your Id and Password Correct? ", " Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                catch (Exception error)
                {
                    MessageBox.Show(" Error in login, Is your Id and Password Correct? ", " Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show(error.ToString());
                }

                sqlcon.Close();


            }




        }
    }
}
