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
using System.Threading;
using AutoUpdaterDotNET;

namespace SecureVault
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        static UserControl usc1 = new Tab1();
        static UserControl usc2 = new tab2();
        static UserControl usc3 = new Tab3();


        private void AutoUpdater_ApplicationExitEvent()
        {
           string Text = @"Closing application...";
            Thread.Sleep(5000);
            Application.Current.Shutdown();
        }


        public MainWindow()
        {
            InitializeComponent();
           // UserControl usc = new Tab1();
            GridMain.Children.Add(usc1);
            usc1 = null;
            GC.Collect();

            
        }



        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //UserControl usc = null;
            
            GridMain.Children.Clear();
            
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemLogin":
                    usc1 = new Tab1();
                    GridMain.Children.Clear();
                    GridMain.Children.Remove(usc2);
                    GridMain.Children.Remove(usc3);
                    
                    //usc = new Tab1();
                    GridMain.Children.Add(usc1);
                    usc1 = null;
                    
                    break;
                case "ItemRegister":
                    usc2 = new tab2();
                    GridMain.Children.Clear();
                    GridMain.Children.Remove(usc1);
                    GridMain.Children.Remove(usc3);
                    //usc = new tab2();
                    GridMain.Children.Add(usc2);
                    usc2 = null;
                    break;
                case "ItemRecord":
                    usc3 = new Tab3();
                    GridMain.Children.Clear();
                    GridMain.Children.Remove(usc1);
                    GridMain.Children.Remove(usc2);
                    //usc = new Tab3();
                    GridMain.Children.Add(usc3);
                    usc3= null;
                    break;
                
                default:
                    MessageBox.Show("Thanks, This Part is UnderDevelopment, Please Wait for The next Update", "Work In Progress", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
            
            }
            GC.Collect();
           // GridMain.Children.Remove(usc);
            
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            // Change this later
            MessageBox.Show("Thanks, This Part is UnderDevelopment, Please Wait for The next Update", "Work In Progress", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            // Change this later
            MessageBox.Show("Thanks, This Part is UnderDevelopment, Please Wait for The next Update", "Work In Progress", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            // Change this later
            MessageBox.Show("Thanks, This Part is UnderDevelopment, Please Wait for The next Update", "Work In Progress", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        


      private void Help_Click(object sender, RoutedEventArgs e)
        {
            // Change this later
            MessageBox.Show("Thanks, This Part is UnderDevelopment, Please Wait for The next Update", "Work In Progress", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                AutoUpdater.DownloadPath = Environment.CurrentDirectory;
                AutoUpdater.Start("https://www.dropbox.com/s/h8gy8pk9fe5i3a7/update.xml?dl=1");
                AutoUpdater.ReportErrors = true;
                AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
            }
            catch (Exception tr)
            {
                MessageBox.Show("Error in update, send this screenshot to developer:-" + tr.ToString());
            }

        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized; 
        }
        private void Pow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }

}
