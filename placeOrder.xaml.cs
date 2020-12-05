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
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PizzaApp
{
    /// <summary>
    /// Interaction logic for placeOrder.xaml
    /// </summary>
    public partial class placeOrder : Window
    {
        //prepare global variable for database
        double[] total_price = new double[3];
        string topping = "";
        string side_value = "";
        string crust_value = "";
        string size_value = "";

        /*
         * param double[] result
         * param string[] toppings
         * param string[] sides
         * param string size
         * param string crust
         */
        public placeOrder(double[] result, string[] toppings, string[] sides, string crust, string size )
        {
            InitializeComponent();
            lblCrust.Content = crust;
            lblSize.Content = size;
            string topps = string.Join(",", toppings);
            lblToppings.Content = topps;
            lblPrice.Content = result[0];
            lblTax.Content = result[1];
            lblTotal.Content = result[2];
            string side = string.Join(",", sides);
            lblSides.Content = side;
            //updating values of variables for database
            crust_value = crust;
            size_value = size;
            total_price[0] = result[0];
            total_price[1] = result[1];
            total_price[2] = result[2];
            topping = topps;
            side_value = side;
        }
        //takes back to MainWindow to edit order
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }
        // method to push values to database
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=password;database=pizzaApp;";
            string query1 = "INSERT INTO user_data (`User_ID`, `Name`, `Last_Name`, `Address`, `Size`, `Crust`,`Toppings`,`Sides`, `Price`,`Tax`,`Total`) VALUES (NULL, '" + txtName.Text + "', '" + txtLname.Text + "', '" + txtAddress.Text + "', '" + size_value + "', '" + crust_value + "', '"+topping+"','"+side_value+"','" + total_price[0] + "', '" + total_price[1] + "', '" + total_price[2] + "')";
            
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection);

            commandDatabase1.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader1 = commandDatabase1.ExecuteReader();
                if (myReader1.HasRows)
                {
                    myReader1 = commandDatabase1.ExecuteReader();
                    MessageBox.Show("Order Placed Successfully");
                }
                else
                {
                    Console.WriteLine("No rows found");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
