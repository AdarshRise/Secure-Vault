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

namespace SecureVault
{
    /// <summary>
    /// Interaction logic for Tab3.xaml
    /// </summary>
    public partial class Tab3 : UserControl
    {
        System.Data.SQLite.SQLiteConnection sqlcon = new System.Data.SQLite.SQLiteConnection(getInfo.dbcon);
        public Tab3()
        {
            InitializeComponent();
        }

        private void UnLoad_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Rwebidtxt.Text))
            {
                MessageBox.Show("Error in WebId Field, Please Check it again.", "UnLoading Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                // MessageBox.Show("Thanks, This Part is UnderDevelopment, Please Wait for The next Update", "Work In Progress", MessageBoxButton.OK, MessageBoxImage.Information);

                if (!string.IsNullOrWhiteSpace(Rwebidtxt.Text))
                {
                    sqlcon.Open();
                    //MessageBox.Show(sqlcon.ToString());
                   string query = "Select password from Record where EmailID='" +Rwebidtxt.Text + "';";
                    System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(query, sqlcon);
                    com.ExecuteNonQuery();
                    System.Data.SQLite.SQLiteDataReader dr = com.ExecuteReader();
                    dr.Read();

                    Rpasstxt.Text= dr["Password"].ToString();


                    //MessageBox.Show("Congrats , You have successefully Loaded the Data ", "Data Loaded  ", MessageBoxButton.OK, MessageBoxImage.Information);
                    sqlcon.Close();
                }

            }

        



        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Wwebidtxt.Text))
            {
                MessageBox.Show("Error in WebId Field, Please Check it again.", "Loading Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            if (string.IsNullOrWhiteSpace(Wpasstxt.Text))
            {
                MessageBox.Show("Error in PassWord Field, Please Check it again.", "Loading Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            if (!string.IsNullOrWhiteSpace(Wpasstxt.Text) && !string.IsNullOrWhiteSpace(Wwebidtxt.Text))
            {
                sqlcon.Open();
                //MessageBox.Show(sqlcon.ToString());
                string query = "insert into Record values(null,'" + Wwebidtxt.Text + "','" + Wpasstxt.Text + "');";
                System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(query, sqlcon);
                com.ExecuteNonQuery();
                MessageBox.Show("Congrats , You have successefully Loaded the Data ", "Data Loaded  ", MessageBoxButton.OK, MessageBoxImage.Information);
                sqlcon.Close();
            }

        }
    }
}
