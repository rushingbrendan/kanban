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



        private int ExecuteNonQueryCommand(string inputCommand)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(this.sourceConnectionString))
                {
                    connection.Open();
                    OleDbCommand command = new
                        OleDbCommand(inputCommand, connection);
                    command.ExecuteNonQuery();

                    return 0;
                }
            }
            catch
            {
                return -1;
            }

        }

        private int ExecuteDataReader(string inputQuery)
        {
            int returnInteger = 0;
            try
            {
                using (OleDbConnection connection = new OleDbConnection(this.sourceConnectionString))
                {
                    OleDbCommand command = new OleDbCommand(inputQuery, connection);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string returnValue = reader[0].ToString();
                        int.TryParse(returnValue, out returnInteger);
                    }
                    reader.Close();
                    return returnInteger;
                }
            }
            catch (Exception e)
            {
                return -1;
            }


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
