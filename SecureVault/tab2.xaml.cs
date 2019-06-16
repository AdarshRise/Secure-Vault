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
    /// Interaction logic for tab2.xaml
    /// </summary>
    public partial class tab2 : UserControl
    {
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
            if (string.IsNullOrWhiteSpace(Idtxt.Text))
            {
                MessageBox.Show("Error in Vault Id Field, Please Check it again.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (string.IsNullOrWhiteSpace(Passtxt.Password))
            {
                MessageBox.Show("Error in Password Field, Please Check it again.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (string.IsNullOrWhiteSpace(RePasstxt.Password))
            {
                MessageBox.Show("Error in Re-Pass Field, Please Check it again.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                
            }
            if (!string.IsNullOrWhiteSpace(nametxt.Text) && !string.IsNullOrWhiteSpace(Idtxt.Text) && !string.IsNullOrWhiteSpace(Passtxt.Password) && !string.IsNullOrWhiteSpace(RePasstxt.Password) && RePasstxt.Password == Passtxt.Password)
            {
                MessageBox.Show("both are same");

            }
            
           // MessageBox.Show(RePasstxt.Password);// this works


        }
    }
}
