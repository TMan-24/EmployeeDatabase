/*
 * Arthur: Tony Anderson
 * Date: 9/28/2020
 * Filename: MainWindow.xaml.cs
 * Description: This program connects to a database and prints
 *              out the contents of the database
 */

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace EmployeeDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public string Text { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\EmployeeDatabase.accdb");
        }

        //Asset Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select* from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            data += "Assets\n";
            data += "EmployeeID       AssetID          Description";
            data += "\n";

            while (read.Read())
            {
                
                data += read[0].ToString() + "                  ";
                data += read[1].ToString() + "            ";
                data += read[2].ToString() + "\n";
                data += "\n";
            }
            Info_field1.Text = data;
            cn.Close();
        }

        //Employee button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string query = "select* from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();

            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            data += "Employees\n";
            data += "EmployeeID    Lastname    Firstname";
            data += "\n";

            while (read.Read())
            {

                data += read[0].ToString() + "               ";
                data += read[1].ToString() + ",          ";
                data += read[2].ToString() + "\n";
                data += "\n";
            }
            Info_field2.Text = data;
            cn.Close();
        }
    }
}
