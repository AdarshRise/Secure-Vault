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
                MessageBox.Show("Thanks, This Part is UnderDevelopment, Please Wait for The next Update", "Work In Progress", MessageBoxButton.OK, MessageBoxImage.Information);
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
        }
    }
}
