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
        SqlDataAdapter adapter;
        DataTable phonesTable;
        public MainWindow()
        {
            InitializeComponent();
            phonesGrid.RowEditEnding += PhonesGrid_RowEditEnding;

        }

        private void PhonesGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateDB();
        }

        private void ShowData_Click(object sender, RoutedEventArgs e)
        {
            string tablename = PickedTable.Text;
            string connectionString = "Data Source = DESKTOP-NST5P2P; Initial Catalog = ExpertCompetence; Integrated Security = True";
            string sql =  $"SELECT * FROM {tablename}";
            phonesTable = new DataTable();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            adapter = new SqlDataAdapter(command);
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
        private void UpdateDB()
        {        
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(phonesTable);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItems != null)
            {
                for (int i = 0; i < phonesGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = phonesGrid.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }
   


    }


}
