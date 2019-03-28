/*  Course:         PROG3070 - Advanced SQL
 *  Assignment:     SQL Database data visualization in chart
 *  Programmer:     Brendan Rushing, Tudor Lupu
 *  Date:           3/23/2019
 *  
 *  Description:    A script to insert configurations into the
 *                  database using the Configuration Table form.
 *
 *  This configuration table is for the kanban automation system simulation on SQL Server.
 * 
 * 
 * 
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADODB;  // ADODB 
using System.Data.OleDb;
using System.Data.SqlClient;

namespace ConfigurationClient
{
    /// <summary>
    /// Form for Configuration Client
    /// </summary>
    public partial class Form1 : Form
    {

        private string sourceConnectionString { get; set; }
        private int harnessQuantity { get; set; }
        private int reflectorQuantity { get; set; }
        private int housingQuantity { get; set; }
        private int lensQuantity { get; set; }
        private int bulbQuantity { get; set; }
        private int bezelQuantity { get; set; }

        private double rookieDefectRate { get; set; }
        private double normalDefectRate { get; set; }
        private double experiencedDefectRate { get; set; }

        private int rookieAssemblyTime { get; set; }
        private int normalAssemblyTime { get; set; }
        private int experiencedAssemblyTime { get; set; }

        private int runnerCollectionTimeCycle { get; set; }
        private int numberOfStations { get; set; }
        private int testTraySize { get; set; }

        private string queryString { get; set; }

        /// <summary>
        /// Constructor
        ///     - Select database prompt is shown upon loading
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            SelectDatabase();
        }

        /// <summary>
        /// Transfer variables from UI to Class
        /// </summary>
        private void UpdateVariablesFromUi()
        {
            //temp variables
            int harnessValue = 0;
            int reflectorValue = 0;
            int housingValue = 0;
            int lensValue = 0;
            int bulbValue = 0;
            int bezelValue = 0;

            double rookieDefectValue = 0;
            double normalDefectValue = 0;
            double experiencedDefectValue = 0;

            int rookieAssemblyValue = 0;
            int normalAssemblyValue = 0;
            int experiencedAssemblyValue = 0;

            int runnerCollectionValue = 0;
            int numberOfStationsValue = 0;
            int testTraySizeValue = 0;

            //get from UI layer
            int.TryParse(harnessInput.Text, out harnessValue);
            int.TryParse(reflectorInput.Text, out reflectorValue);
            int.TryParse(housingInput.Text, out housingValue);
            int.TryParse(lensInput.Text, out lensValue);
            int.TryParse(bulbInput.Text, out bulbValue);
            int.TryParse(bezelInput.Text, out bezelValue);

            double.TryParse(rookieDefectInput.Text, out rookieDefectValue);
            double.TryParse(normalDefectInput.Text, out normalDefectValue);
            double.TryParse(experiencedDefectInput.Text, out experiencedDefectValue);

            int.TryParse(rookieAssemblyTimeInput.Text, out rookieAssemblyValue);
            int.TryParse(normalAssemblyTimeInput.Text, out normalAssemblyValue);
            int.TryParse(experiencedAssemblyTimeInput.Text, out experiencedAssemblyValue);

            int.TryParse(cardPickUpCycleInput.Text, out runnerCollectionValue);
            int.TryParse(numberOfStationsInput.Text, out numberOfStationsValue);
            int.TryParse(testTraySizeInput.Text, out testTraySizeValue);

            //send to class variables
            harnessQuantity = harnessValue;
            reflectorQuantity = reflectorValue;
            housingQuantity = housingValue;
            lensQuantity = lensValue;
            bulbQuantity = bulbValue;
            bezelQuantity = bezelValue;

            rookieDefectRate = rookieDefectValue;
            normalDefectRate = normalDefectValue;
            experiencedDefectRate = experiencedDefectValue;

            rookieAssemblyTime = rookieAssemblyValue;
            normalAssemblyTime = normalAssemblyValue;
            experiencedAssemblyTime = experiencedAssemblyValue;

            runnerCollectionTimeCycle = runnerCollectionValue;
            numberOfStations = numberOfStationsValue;
            testTraySize = testTraySizeValue;
        }

        /// <summary>
        /// Update query string from variables in class
        /// </summary>
        private void UpdateQueryString()
        {

            //update query string
            queryString = $"INSERT INTO ConfigurationTable(harnessQuantity, reflectorQuantity, housingQuantity, lensQuantity, bulbQuantity, bezelQuantity,  runnerCollectionTimeCycle, numberOfStations, testTraySize, rookieDefectRate, normalDefectRate, experiencedDefectRate, rookieAssemblyTime, normalAssemblyTime, experiencedAssemblyTime) VALUES({this.harnessQuantity}, {this.reflectorQuantity}, {this.housingQuantity}, {this.lensQuantity}, {this.bulbQuantity}, {this.bezelQuantity} , {this.runnerCollectionTimeCycle}, {this.numberOfStations}, {this.testTraySize}, {this.rookieDefectRate}, {this.normalDefectRate}, {this.experiencedDefectRate}, {this.rookieAssemblyTime}, {this.normalAssemblyTime}, {this.experiencedAssemblyTime})";
        }    

        /// <summary>
        /// Datalink window to select database and build connection string
        /// </summary>
        private void SelectDatabase()
        {
            ADODB.Connection conn = new ADODB.Connection();
            object oConn = (object)conn;

            MSDASC.DataLinks dlg = new MSDASC.DataLinks();
            dlg.PromptEdit(ref oConn);

            LogEvent("Source Connection String: " + conn.ConnectionString);

            this.sourceConnectionString = conn.ConnectionString;

            UpdateDatabaseConnectionLabel(true);
        }

        /// <summary>
        /// Update the label for database selection
        /// </summary>
        /// <param name="valid"></param>
        private void UpdateDatabaseConnectionLabel(bool valid)
        {
            if (valid == true)
            {
                databaseSelectedLabel.Text = "Database Selected: True";
            }
            else
            {
                databaseSelectedLabel.Text = "Database Selected: False";
            }
        }


        /// <summary>
        /// Button handler for update configuration database table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateConfigurationButton_Click(object sender, EventArgs e)
        {
            //get variables from ui
            UpdateVariablesFromUi();

            //build query string
            UpdateQueryString();

            //update configuration table in database
            LogEvent("Updating configuration table in database");
            UpdateConfigurationTable();

        }

        /// <summary>
        /// Update configuration table in database
        /// </summary>
        private void UpdateConfigurationTable()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(sourceConnectionString))
                {
                    connection.Open();
                    OleDbCommand command = new
                        OleDbCommand(this.queryString, connection);
                    command.ExecuteNonQuery();
                }
                LogEvent("Configuration table in database has been updated");
            }
            catch (Exception e)
            {
                LogEvent("Error when updating database configuration table:   " + e);
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


        }


    }
}
