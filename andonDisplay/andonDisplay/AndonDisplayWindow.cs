using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace andonDisplay
{
    public partial class AndonDisplayWindow : Form
    {

        #region PARTS
        private string harnesses { get; set; }
        private string reflectors { get; set; }
        private string housings { get; set; }
        private string lenses { get; set; }
        private string bulbs { get; set; }
        private string bezels { get; set; }
        #endregion

        #region WORKSTATION
        private string workstationSelected { get; set; }
        #endregion

        #region CONNECTION
        private SqlConnectionStringBuilder conString { get; set; }

        private string tblName = "WorkstationParts";
        private string workstationIDCol = "workstationID";
        private string harnessesCol = "harnesses";
        private string reflectorsCol = "reflectors";
        private string housingsCol = "housings";
        private string lensesCol = "lenses";
        private string bulbsCol = "bulbs";
        private string bezelsCol = "bezels";
        #endregion

        public AndonDisplayWindow()
        {
            InitializeComponent();

            harnesses = "0";
            reflectors = "0";
            housings = "0";
            lenses = "0";
            bulbs = "0";
            bezels = "0";

            SetUpConnectionString();
            UpdateActiveSelectableStations();
            GetPartsCount();
            UpdateWorkerStatus();

            SetUpTimer();

        }

        private void SetUpTimer()
        {
            const int ONESECOND = 1000;
            Timer timer = new Timer();
            timer.Interval = (ONESECOND);
            timer.Tick += new EventHandler(TimerTicked);
            timer.Start();
        }

        private void TimerTicked(object sender, EventArgs e)
        {
            // refresh the data
            GetPartsCount();
            UpdateWorkerStatus();
        }

        private void SetUpConnectionString()
        {
            // set up the connection string for the database
            conString = new SqlConnectionStringBuilder
            {
                DataSource = "tcp:kanban.database.windows.net,1433",
                UserID = "SetUser3",
                Password = "Conestoga1",
                InitialCatalog = "kanban"
            };
        }

        private void UpdateActiveSelectableStations()
        {
            string query = "SELECT " + workstationIDCol + " FROM " + tblName;
            DataTable data = QueryWorkstationPartsTable(query);

            if (data != null)
            {
                // update the combo box with the values queried
                cbWorkstation.DataSource = data;
                cbWorkstation.ValueMember = "workstationID";
                cbWorkstation.DisplayMember = "Workstation";

                // get the workstation id of the one selected
                workstationSelected = cbWorkstation.GetItemText(cbWorkstation.SelectedItem);
            }          
        }

        private void GetPartsCount()
        {
            if (workstationSelected != "System.Data.DataRowView")
            {
                string query =
                "SELECT " + workstationIDCol + ", " +
                harnessesCol + ", " + reflectorsCol + ", " +
                housingsCol + ", " + lensesCol + ", " + bulbsCol + ", " + bezelsCol + " " +
                "FROM " + tblName +
                " WHERE " + workstationIDCol + " = " + workstationSelected;

                DataTable data = QueryWorkstationPartsTable(query);

                if (data != null)
                {
                    foreach (DataRow row in data.Rows)
                    {

                        // update the values of each part
                        harnesses = row[harnessesCol].ToString();
                        reflectors = row[reflectorsCol].ToString();
                        housings = row[housingsCol].ToString();
                        lenses = row[lensesCol].ToString();
                        bulbs = row[bulbsCol].ToString();
                        bezels = row[bezelsCol].ToString();

                        // update the parts on the screen
                        UpdatePartsCount();

                    }
                }
            }
        }

        private void UpdatePartsCount()
        {
            lbHarnesCount.Text = harnesses;
            lbReflectCount.Text = reflectors;
            lbHousCount.Text = housings;
            lbLensCount.Text = lenses;
            lbBulbCount.Text = bulbs;
            lbBezCount.Text = bezels;
        }

        private void UpdateWorkerStatus()
        {
            workerLabel.Text = (IsWorkerNeeded()) ? "YES" : "NO";
        }

        private void UpdateSelectedWorkstation(object sender, EventArgs e)
        {
            // get the workstation id of the one selected
            workstationSelected = cbWorkstation.GetItemText(cbWorkstation.SelectedItem);

            GetPartsCount();
            UpdateWorkerStatus();
        }

        private bool IsWorkerNeeded()
        {
            const int MINNUMOFPART = 5;

            if (Int32.Parse(harnesses) <= MINNUMOFPART ||
                Int32.Parse(reflectors) <= MINNUMOFPART ||
                Int32.Parse(housings) <= MINNUMOFPART ||
                Int32.Parse(lenses) <= MINNUMOFPART ||
                Int32.Parse(bulbs) <= MINNUMOFPART ||
                Int32.Parse(bezels) <= MINNUMOFPART)
            {
                return true;
            }

            return false;
        }   

        private DataTable QueryWorkstationPartsTable(string query)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(conString.ConnectionString))
            {
                conn.Open();
                
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    data.Load(reader);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }            
            }

            return data;

        }
    }
}
