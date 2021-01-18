using AUPS.SqlProviders;
using Npgsql;
using System.Data;
using System.Windows;

namespace AUPS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataTable dataTable = new DataTable();

        #region Queries
        private const string GET_ALL_RECORDS_FROM_RADNO_MESTO =
            @"
                  SELECT * FROM radnomesto;
            ";

        private const string GET_ALL_RECORDS_FROM_OPERACIJA =
            @"
                  SELECT * FROM operacija;
            ";

        private const string GET_ALL_RECORDS_FROM_PREDMET_RADA =
            @"
                  SELECT * FROM predmetrada;
            ";

        private const string GET_ALL_RECORDS_FROM_RADNA_LISTA =
            @"
                  SELECT * FROM radnalista;
            ";

        private const string GET_ALL_RECORDS_FROM_RADNI_NALOG=
            @"
                  SELECT * FROM radninalog;
            ";

        private const string GET_ALL_RECORDS_FROM_RADNIK_PROIZVODNJA =
            @"
                  SELECT * FROM radnikproizvodnja;
            ";

        private const string GET_ALL_RECORDS_FROM_TEHNOLOSKI_POSTUPAK =
            @"
                  SELECT * FROM tehnoloskipostupak;
            ";

        private const string GET_ALL_RECORDS_FROM_TREBOVANJE =
            @"
                  SELECT * FROM trebovanje;
            ";
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            FillTableWithData();
        }

        private void FillTableWithData()
        {
            GetAllFromRadnoMesto();
            GetAllFromOperacija();
            GetAllFromPredmetRada();
            GetAllFromRadnaLista();
            GetAllFromRadniNalog();
            GetAllFromRadnikProizvodnja();
            GetAllFromTehnoloskiPostupak();
            GetAllFromTrebovanje();

        }

        private void GetAllFromRadnoMesto()
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNO_MESTO, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

            myDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void GetAllFromOperacija()
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_OPERACIJA, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

            myDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void GetAllFromPredmetRada()
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_PREDMET_RADA, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

            myDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void GetAllFromRadnaLista()
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNA_LISTA, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

            myDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void GetAllFromRadniNalog()
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNI_NALOG, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

            myDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void GetAllFromRadnikProizvodnja()
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_RADNIK_PROIZVODNJA, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

            myDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void GetAllFromTehnoloskiPostupak()
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_TEHNOLOSKI_POSTUPAK, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

            myDataGrid.ItemsSource = dataTable.DefaultView;
        }

        private void GetAllFromTrebovanje()
        {
            using (NpgsqlConnection sqlConnection = ConnectionCreator.createConnection())
            {
                sqlConnection.Open();

                NpgsqlCommand cmd = new NpgsqlCommand(GET_ALL_RECORDS_FROM_TREBOVANJE, sqlConnection);

                dataTable.Load(cmd.ExecuteReader());
            }

            myDataGrid.ItemsSource = dataTable.DefaultView;
        }
    }
}
