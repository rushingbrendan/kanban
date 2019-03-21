/*  Course:         PROG3070 - Advanced SQL
 *  Assignment:     SQL Database data visualization in chart
 *  Programmer:     Brendan Rushing, Tudor Lupu
 *  Date:           3/14/2019
 *  
 *  Description:    A script to insert configurations into the
 *                  database using the Configuration Table
 * 
 * 
 * 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Configuration;

namespace asql_configuration_client
{
    class ConfigurationClient
    {
        private string connectionString { get; set; }
        private int harnessQuantity { get; set; }
        private int reflectorQuantity { get; set; }
        private int housingQuantity { get; set; }
        private int lensQuantity { get; set; }
        private int bulbQuantity { get; set; }
        private int runnerCollectionTimeCycle { get; set; }
        private int numberOfStations { get; set; }
        private int testTraySize { get; set; }

        private string queryString { get; set; }
            

        static void Main(string[] args)
        {

            Console.WriteLine("Reading configuration settings from App.config file...");

            ConfigurationClient currentConfiguration = new ConfigurationClient();
            currentConfiguration.ReadConfigurationSettings();

            Console.WriteLine("Updating Database with configuration settings...");
            currentConfiguration.UpdateDatabaseConfigurationTable();

            Console.WriteLine("Configuration table in database has been updated.");

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey();

        }

        /// <summary>
        /// Read configuration settings from app.config file
        /// </summary>
         public void ReadConfigurationSettings()
        {
            //read configuration data from app.config

            int harnessValue = 0;
            int reflectorValue = 0;
            int housingValue = 0;
            int lensValue = 0;
            int bulbValue = 0;
            int runnerTimeCycleValue = 0;
            int stationsValue = 0;
            int traySizeValue = 0;

            try
            {
                //read from app.config
                this.connectionString = ConfigurationManager.AppSettings["databaseConnectionString"].ToString();  //connection string
                int.TryParse(ConfigurationManager.AppSettings["harnessQuantity"], out reflectorValue);  
                int.TryParse(ConfigurationManager.AppSettings["reflectorQuantity"], out housingValue); 
                int.TryParse(ConfigurationManager.AppSettings["housingQuantity"], out harnessValue); 
                int.TryParse(ConfigurationManager.AppSettings["lensQuantity"], out lensValue);  
                int.TryParse(ConfigurationManager.AppSettings["bulbQuantity"], out bulbValue);  
                int.TryParse(ConfigurationManager.AppSettings["runnerCollectionTimeCycle"], out runnerTimeCycleValue);  
                int.TryParse(ConfigurationManager.AppSettings["numberOfStations"], out stationsValue);  
                int.TryParse(ConfigurationManager.AppSettings["testTraySize"], out traySizeValue);  

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //pass to class variable
            this.harnessQuantity = harnessValue;
            this.reflectorQuantity = reflectorValue;
            this.housingQuantity = housingValue;
            this.lensQuantity = lensValue;
            this.bulbQuantity = bulbValue;
            this.runnerCollectionTimeCycle = runnerTimeCycleValue;
            this.numberOfStations = stationsValue;
            this.testTraySize = traySizeValue;

            //update query string
            queryString = $"INSERT INTO ConfigurationTable(harnessQuantity, reflectorQuantity, housingQuantity, lensQuantity, bulbQuantity, runnerCollectionTimeCycle, numberOfStations, testTraySize) VALUES({this.harnessQuantity}, {this.reflectorQuantity}, {this.housingQuantity}, {this.lensQuantity}, {this.bulbQuantity}, {this.runnerCollectionTimeCycle}, {this.numberOfStations}, {this.testTraySize})";
    }

        /// <summary>
        /// Update database configuration table with data from app.config file
        /// </summary>
        public void UpdateDatabaseConfigurationTable()
        {            

            using (OleDbConnection connection = new OleDbConnection(this.connectionString))
            {
                connection.Open();
                OleDbCommand command = new
                    OleDbCommand(this.queryString, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
