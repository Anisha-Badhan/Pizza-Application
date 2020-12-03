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

namespace PizzaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double total = 0.00;
        double crust_price = 0.00;
        double size_price = 0.00;
        double topping_price = 0.00;
        double[] sides = {0,0,0,0,0};
        double[] topps = {0,0,0,0,0};
        double side_price = 0.00;
        int topping = 0;
       
        private void rbtnsmall_Checked(object sender, RoutedEventArgs e)
        {  

            if (rbtnsmall.IsChecked == true)
            {
                size_price = 5.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void rbtnMedium_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtnMedium.IsChecked == true)
            {
                size_price = 7.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void rbtnLarge_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtnLarge.IsChecked == true)
            {
                size_price = 12.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void rbtnThin_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtnThin.IsChecked == true)
            {
                crust_price = 1.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void rbtnThick_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtnThick.IsChecked == true)
            {
                crust_price = 2.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void rbtnPan_Checked(object sender, RoutedEventArgs e)
        {
            if (rbtnPan.IsChecked == true)
            {
                crust_price = 4.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbOlives_Checked(object sender, RoutedEventArgs e)
        {

            if (cbOlives.IsChecked == true)
            {
                if (topping > 2)
                {
                   topps[0] = 0.50;
                }
                topping++;
            }
            else
            {
                topps[0] = 0.00;
                topping--;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbPineapple_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPineapple.IsChecked == true)
            {
                if (topping > 2)
                {
                    topps[1]= 0.50;
                }
                topping++;
            }
            else
            {
                topps[1] = 0.00;
                topping--;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbMashroom_Checked(object sender, RoutedEventArgs e)
        {
            if (cbMashroom.IsChecked == true)
            {
                if (topping > 2)
                {
                    topps[2] = 0.50;
                }
                topping++;
            }
            else
            {
                topps[2] = 0.00;
                topping--;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbGreenp_Checked(object sender, RoutedEventArgs e)
        {
            if (cbGreenp.IsChecked == true)
            {
                if (topping > 2)
                {
                    topps[3]= 0.50;
                }
                topping++;
            }
            else
            {
                topps[3] = 0.00;
                topping--;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbTomato_Checked(object sender, RoutedEventArgs e)
        {
            if (cbTomato.IsChecked == true) {
                if (topping > 2)
                {
                    topps[4]= 0.50;
                }
                topping++;
            }
            else
            {
                topps[4] = 0.00;
                topping--;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbWings_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (cbWings.IsChecked == true)
            {
                sides[0] = 4.00;
            }
            else
            {
                sides[0] = 0.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }
        
        private void cbOnionR_Checked(object sender, RoutedEventArgs e)
        {
            if (cbOnionR.IsChecked == true)
            {
                sides[1] = 4.00;
            }
            else
            {
                sides[1] = 0.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbPoppers_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPoppers.IsChecked == true)
            {
                sides[2] = 5.00;
            }
            else
            {
                sides[2] = 0.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbSalad_Checked(object sender, RoutedEventArgs e)
        {
            if (cbSalad.IsChecked == true)
            {
                sides[3] = 3.00;
            }
            else
            {
                sides[3] = 0.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        private void cbGarlicB_Checked(object sender, RoutedEventArgs e)
        {
            if (cbGarlicB.IsChecked == true)
            {
                sides[4] = 6.00;
            }
            else
            {
                sides[4] = 0.00;
            }
            double[] price = Calculate_result();
            lblPrice.Content = "Before tax: " + price[0];
            lblTax.Content = "Tax: " + price[1];
            lblTotal.Content ="Total Price: " + price[2];
        }

        public double[] Calculate_result()
        {
            topping_price = topps[0] + topps[1] + topps[2] + topps[3] + topps[4];
            side_price = sides[0] + sides[1] + sides[2] + sides[3] + sides[4];
            total = size_price + crust_price + topping_price + side_price;
            double tax = Math.Round((total * 0.13),2);
            double grand_total = Math.Round((total + tax),2);
            double[] result = { total, tax, grand_total } ;
            return result;
        }
    }
}
