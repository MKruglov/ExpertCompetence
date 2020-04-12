using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace expertcompetncegeneration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Phone
        {
            public string Title { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
         
        }
        private void AddData_Click(object sender, RoutedEventArgs e)
        {
          
        }
        private void ShowData_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source = DESKTOP-NST5P2P; Initial Catalog = ExpertCompetence; Integrated Security = True";
            string sql = "SELECT * FROM Users";
            DataTable phonesTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            connection.Open();
            adapter.Fill(phonesTable);
            phonesGrid.ItemsSource = phonesTable.DefaultView;
            try
            {
              
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

        }
   
    }


}
