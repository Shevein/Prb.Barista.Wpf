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

namespace Prb.Barista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fName;
        string lName;
        string fullName;
        double coffeeShot;
        double cream;
        double syrup;
        double coffeePrice;
        double sizePrice;
        int count;

        double totaal;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text == "" || txtLastName.Text == "")
            {
                MessageBox.Show("Gelieve uw naam in te vullen.", "Fout!", MessageBoxButton.OK, MessageBoxImage.Error);
                txtFirstName.Focus();
            }
            else
            {
                FillListOfCustomers();
                Calculation();
                CountCustomers();
                tbkTotal.Text = $"€ {totaal.ToString()}";
                txtFirstName.Text = null;
                txtLastName.Text = null;
                lblToPay.Visibility = Visibility.Visible;
                lblCustomer.Visibility = Visibility.Visible;
                lstCustomers.Visibility = Visibility.Visible;
            }
        }

        private void FillListOfCustomers()
        {
            fName = txtFirstName.Text;
            lName = txtLastName.Text;

            fullName = lName + " " + fName;

            lstCustomers.Items.Add($"Klant : {fName} {lName} ");
        }

        private void CkbAmericano_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbAmericano.IsChecked == true)
            {
                ckbCapuccino.IsChecked = false;
                ckbEspresso.IsChecked = false;
                ckbLatteMachiato.IsChecked = false;
                ckbRistretto.IsChecked = false;
                
            }
        }

        private void CkbEspresso_Checked(object sender, RoutedEventArgs e)
        {
            ckbAmericano.IsChecked = false;
            ckbCapuccino.IsChecked = false;
            ckbLatteMachiato.IsChecked = false;
            ckbRistretto.IsChecked = false;
        }

        private void CkbRistretto_Checked(object sender, RoutedEventArgs e)
        {
            ckbAmericano.IsChecked = false;
            ckbCapuccino.IsChecked = false;
            ckbLatteMachiato.IsChecked = false;
            ckbEspresso.IsChecked = false;
        }

        private void CkbCapuccino_Checked(object sender, RoutedEventArgs e)
        {
            ckbAmericano.IsChecked = false;
            ckbEspresso.IsChecked = false;
            ckbLatteMachiato.IsChecked = false;
            ckbRistretto.IsChecked = false;
        }

        private void CkbLatteMachiato_Checked(object sender, RoutedEventArgs e)
        {
            ckbAmericano.IsChecked = false;
            ckbCapuccino.IsChecked = false;
            ckbEspresso.IsChecked = false;
            ckbRistretto.IsChecked = false;
        }

        private void CkbSmall_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbSmall.IsChecked == true)
            {
                ckbMedium.IsChecked = false;
                ckbLarge.IsChecked = false;
            }
        }

        private void ckbMedium_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbMedium.IsChecked == true)
            {
                ckbSmall.IsChecked = false;
                ckbLarge.IsChecked = false;
            }
        }

        private void CkbLarge_Checked(object sender, RoutedEventArgs e)
        {
            if (ckbLarge.IsChecked == true)
            {
                ckbSmall.IsChecked = false;
                ckbMedium.IsChecked = false;
            }
        }

        private void PriceOfCoffee()
        {

            if (ckbAmericano.IsChecked == true)
            {
                coffeePrice = 1.50;
            }
            else if (ckbEspresso.IsChecked == true)
            {
                coffeePrice = 1.80;
            }
            else if (ckbCapuccino.IsChecked == true)
            {
                coffeePrice = 2.20;
            }
            else if (ckbRistretto.IsChecked == true)
            {
                coffeePrice = 2.50;
            }
            else if (ckbLatteMachiato.IsChecked == true)
            {
                coffeePrice = 2.80;
            }
        }

        private void SizePrice()
        {

            if (ckbSmall.IsChecked == true)
            {
                sizePrice = 0.10;
            }
            else if (ckbMedium.IsChecked == true)
            {
                sizePrice = 0.30;
            }
            else if (ckbLarge.IsChecked == true)
            {
                sizePrice = 0.50;
            }
        }

        private void ToppingPrice()
        {


            if (ckbExtraCoffeeShot.IsChecked == true)
            {
                coffeeShot = 1;
            }
            if (ckbWhippedCream.IsChecked == true)
            {
                cream = 1;
            }
            if (ckbSyrup.IsChecked == true)
            {
                syrup = 1;
            }
        }

        private void Calculation()
        {
            PriceOfCoffee();
            SizePrice();
            ToppingPrice();
            totaal = 0;
            totaal = coffeePrice + sizePrice + cream + coffeeShot + syrup;

        }

        private void CountCustomers()
        {
            count = 0;

            foreach (var item in lstCustomers.Items)
            {
                count++;
                tbkNumberOfCustomers.Text = count.ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ckbAmericano.IsChecked = true;
            ckbSmall.IsChecked = true;
            txtFirstName.Focus();
            lblToPay.Visibility = Visibility.Collapsed;
            lblCustomer.Visibility = Visibility.Collapsed;
            lstCustomers.Visibility = Visibility.Collapsed;
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            tbkTotal.Text = null;
            MessageBox.Show($"Ticket: \n{fullName}\n€ {totaal} ", "Kassa-Ticket", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
