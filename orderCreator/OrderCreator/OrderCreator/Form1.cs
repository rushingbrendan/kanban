using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient; //T: For SQL DB



namespace OrderCreator
{
    public partial class Form1 : Form
    {
        private string sourceConnectionString { get; set; }

        public Form1()
        {
            InitializeComponent();

            InitializeForm();
        }

        private void InitializeForm()
        {
            //read from app.config
            this.sourceConnectionString = ConfigurationManager.AppSettings["databaseConnectionString"].ToString();  //connection string
        }



   

        private int ExecuteDataReader(string inputQuery)
        {
            SqlConnectionStringBuilder connStringBuild = new SqlConnectionStringBuilder();

            connStringBuild.DataSource = "tcp:kanban.database.windows.net,1433";
            connStringBuild.UserID = "SetUser3"; //standard Username
            connStringBuild.Password = "Conestoga1"; //standard Password
            connStringBuild.InitialCatalog = "kanban"; //inital DB

            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(connStringBuild.ConnectionString))
                {


                    sqlConnection.Open();
                    string addPatient = inputQuery;
                    SqlCommand searchCommand = new SqlCommand(addPatient, sqlConnection);
                    //reader = searchCommand.ExecuteReader();
                    int returnCode = searchCommand.ExecuteNonQuery();



                    //var data = new Patient(reader[1].ToString(), reader[2].ToString(), reader[4].ToString(), "July", "10", "1992", "M");
                    sqlConnection.Close();
                    return 0;
                }
            }
        
            catch (SqlException ex)
            {
                return -1;
            }
        //return null;
        //catch web exception
    }





/// <summary>
/// Log event to log form
/// </summary>
/// <param name="inputEvent"></param>
private void LogEvent(string inputEvent)
        {
            DateTime currentTime = DateTime.Now;

            logOutput.Text += currentTime.ToString() + ": " + inputEvent + Environment.NewLine;
            logOutput.SelectionStart = logOutput.Text.Length;
            logOutput.ScrollToCaret();
        }

        private void placeOrderButton_Click(object sender, EventArgs e)
        {
            PlaceOrder();
        }

        private void PlaceOrder()
        {
            //get quantity
            int orderQuantity = 0;
            int.TryParse(orderQuantityInput.ToString(), out orderQuantity);

            //send request
            PlaceOrderToServer();

        }

        private void PlaceOrderToServer()
        {
            int returnInt = 0;
            int orderQuantity = 0;
            int.TryParse(orderQuantityInput.Value.ToString(), out orderQuantity);

            returnInt = ExecuteDataReader($"[dbo].[PlaceOrder] '{orderQuantity}'");

            if (returnInt == -1)
            {
                LogEvent("Error placing order to database server");
            }
            else
            {                
                LogEvent($"Order of {orderQuantity} units has been sent to database server");
            }
        }

    }
}
