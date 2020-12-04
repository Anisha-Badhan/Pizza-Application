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
        double[] total_price = { };
        string[] topping = { };
        string[] side_value = { };
        string crust_value = "";
        string size_value = "";

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
            crust_value = crust;
            size_value = size;
            total_price.Append(result[0]);
            total_price.Append(result[1]);
            total_price.Append(result[2]);
            topping = toppings;
            side_value = sides;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int user_ID = 0;
            string connectionString = "datasource=localhost;port=3306;username=root;password=password;database=pizzaApp;";
            string query1 = "INSERT INTO user_data (`User_ID`, `Name`, `Last_Name`, `Address`) VALUES (NULL, '" + txtName.Text + "', '" + txtLname.Text + "', '" + txtAddress.Text + "')";
            string query2 = "INSERT INTO order_detail (`Order_ID`,`User_ID`, `Size`, `Crust`, `Price`,`Tax`,`Total`)" + 
                "VALUES (NULL,'"+user_ID +"', '" + size_value + "', '" + crust_value + "', '"+ total_price[0]+"', '"+total_price[1]+"', '"+total_price[2]+"')";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection);
            MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection);

            commandDatabase1.CommandTimeout = 60;
            commandDatabase2.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader1 = commandDatabase1.ExecuteReader();
                user_ID = Convert.ToInt32(commandDatabase2.ExecuteScalar());
                string[] data1 = new string[4];
                if (myReader1.HasRows)
                {
                    while (myReader1.Read())
                    {
                        data1[0] = myReader1.GetString(0);
                        data1[1] = myReader1.GetString(1);
                        data1[2] = myReader1.GetString(2);
                        data1[3] = myReader1.GetString(3);
                    }
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
            //for query2
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader2 = commandDatabase2.ExecuteReader();
                string[] data2 = new string[6];
                if (myReader2.HasRows)
                {
                    while (myReader2.Read())
                    {
                        data2[0] = myReader2.GetString(0);
                        data2[1] = myReader2.GetString(1);
                        data2[2] = myReader2.GetString(2);
                        data2[3] = myReader2.GetString(3);
                        data2[4] = myReader2.GetString(4);
                        data2[5] = myReader2.GetString(5);
                        data2[6] = myReader2.GetString(6);
                    }
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
