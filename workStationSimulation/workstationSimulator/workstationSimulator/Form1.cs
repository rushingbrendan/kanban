/*  Course: Advanced SQL
 *  Date:   April 2, 2019
 *  Assignment: Kanban
 *  Description:    Kanban single work station simulation
 * 
 * 
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
using System.Data.OleDb;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient; //T: For SQL DB

namespace workstationSimulator
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static bool exitFlag = false;

        private bool StopWorker = false;

        private string sourceConnectionString { get; set; }
        private int numberOfWorkstations { get; set; }
        private int timeScale { get; set; }

        private int assemblyTime { get; set; }

        private int testTraySize { get; set; }

        private double defectRate { get; set; }

        private int workstationID { get; set; }

        private int harnessInitialQuantity { get; set; }
        private int reflectorInitialQuantity { get; set; }
        private int housingInitialQuantity { get; set; }
        private int lensInitialQuantity { get; set; }
        private int bulbInitialQuantity { get; set; }
        private int bezelInitialQuantity { get; set; }


        private int harnessQuantity { get; set; }
        private int reflectorQuantity { get; set; }
        private int housingQuantity { get; set; }
        private int lensQuantity { get; set; }
        private int bulbQuantity { get; set; }
        private int bezelQuantity { get; set; }


        private DateTime refillTime { get; set;  }


        private int fogLampAssemblyCount = 0;

        /// <summary>
        /// constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            InitializeForm();
        }

        /// <summary>
        /// Initialize form elements
        /// </summary>
        private void InitializeForm()
        {
            //read from app.config
            this.sourceConnectionString = ConfigurationManager.AppSettings["databaseConnectionString"].ToString();  //connection string

            //update number of work stations
            GetWorkStationCount();

            //update max number for workstations
            workstationInput.Maximum = numberOfWorkstations;

            //set selected employee skill to normal
            employeeSkillInput.SelectedIndex = 1;

            //get time scale
            GetTimeScale();
            timescaleLabel.Text = timeScale.ToString();

            //get parts
            GetParts();

            //get test tray size
            GetTestTraySize();

            GetDefectRate();


        }

        private void AddWorkstationToDB()
        {
            
            string command = $"[dbo].[AddWorkstation] " +
                    $"'{harnessQuantity}', " +
                    $"'{reflectorQuantity}', " +
                    $"'{housingQuantity}', " +
                    $"'{lensQuantity}', " +
                    $"'{bulbQuantity}', " +
                    $"'{bezelQuantity}'";

            int ret = ExecuteNonQueryCommand(command);
            if (ret != -1) { workstationID = ret; }

        }

        private void UpdateWorkstationRecord()
        {

            string command = $"[dbo].[AddWorkstation] " +
                    $"'{workstationID}', " +
                    $"'{harnessQuantity}', " +
                    $"'{reflectorQuantity}', " +
                    $"'{housingQuantity}', " +
                    $"'{lensQuantity}', " +
                    $"'{bulbQuantity}', " +
                    $"'{bezelQuantity}'";

            ExecuteNonQueryCommand(command);

        }


        /// <summary>
        /// send test tray to database server
        /// </summary>
        private void SendTestTray()
        {
            Random rnd = new Random();

            for (int i = 0; i < fogLampAssemblyCount; i++)
            {
                //determine if current fog lamp has failed                
                bool testStatus = CheckIfFogLampPassedTest(rnd);

                if (testStatus)
                {
                    ExecuteNonQueryCommand($"[dbo].[AddBuiltFogLamp] '{numberOfWorkstations}' , '{employeeSkillInput.Text.ToString()}' , '1'");
                }
                else
                {
                    ExecuteNonQueryCommand($"[dbo].[AddBuiltFogLamp] '{numberOfWorkstations}' , '{employeeSkillInput.Text.ToString()}' , '0'");
                }
                
            }

            //reset count
            fogLampAssemblyCount = 0;
        }

        /// <summary>
        /// check if fog lamp has passed test based on defect rate
        /// </summary>
        /// <param name="inputRandom"></param>
        /// <returns></returns>
        private bool CheckIfFogLampPassedTest(Random inputRandom)
        {
            double currentEmployeeDefectRate = defectRate * 100;
            double randomNumber = 0;

            randomNumber = inputRandom.Next(1, 1000);

            if (randomNumber < currentEmployeeDefectRate)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// Get number of workstations
        /// </summary>
        private void GetWorkStationCount()
        {
            int workstations = 0;

            workstations = ExecuteDataReader("GetNumberOfWorkStations");

            if (workstations == -1)
            {
                LogEvent("Error getting workstation count from database server");
            }
            else
            {
                this.numberOfWorkstations = workstations;
                LogEvent($"Workstation count: {workstations}");
            }
        }

        /// <summary>
        /// get time scale value
        /// </summary>
        private void GetTimeScale()
        {
            int timeScaleValue = 0;

            timeScaleValue = ExecuteDataReader("GetTimeScale");

            if (timeScaleValue == -1)
            {
                LogEvent("Error getting time scale from database server");
            }
            else
            {
                this.timeScale = timeScaleValue;
                LogEvent($"Timescale: {timeScale}");
            }
        }

        /// <summary>
        /// Get assembly time
        /// </summary>
        private void GetAssemblyTime()
        {
            int returnInt = 0;
            string employeeSkill = employeeSkillInput.Text.ToString();

            returnInt = ExecuteDataReader($"[dbo].[GetEmployeeAssemblyTime] '{employeeSkill}'");

            if (returnInt == -1)
            {
                LogEvent("Error getting employee assembly time from database server");
            }
            else
            {
                this.assemblyTime = returnInt;
                LogEvent($"Employee assembly time: {assemblyTime/timeScale}");
            }
        }

        /// <summary>
        /// get defect rate from server
        /// </summary>
        private void GetDefectRate()
        {
            double returnDouble = 0;
            string employeeSkill = employeeSkillInput.Text.ToString();
            SqlDataReader reader = null;

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
                    SqlCommand searchCommand = new SqlCommand($"[dbo].[GetDefectRate] '{employeeSkill}'", sqlConnection);
                    reader = searchCommand.ExecuteReader();
                    //reader = searchCommand.ExecuteNonQuery();
                    while (reader.Read())
                    {
                        string returnValue = reader[0].ToString();
                        double.TryParse(returnValue, out returnDouble);

                        this.defectRate = returnDouble;
                    }

                    sqlConnection.Close();
                    
                }
            }

            catch (SqlException ex)
            {
                
            }

        }


        /// <summary>
        /// get test tray size from server
        /// </summary>
        private void GetTestTraySize()
        {
            int returnInt = 0;            

            returnInt = ExecuteDataReader($"[dbo].[GetTestTraySize]");

            if (returnInt == -1)
            {
                LogEvent("Error getting test tray size from database server");
            }
            else
            {
                this.testTraySize = returnInt;
                LogEvent($"Test tray size: {testTraySize}");
            }
        }


        /// <summary>
        /// Execute SQL server non query command
        /// </summary>
        /// <param name="inputCommand"></param>
        /// <returns></returns>
        private int ExecuteNonQueryCommand(string inputCommand)
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
                    SqlCommand searchCommand = new SqlCommand(inputCommand, sqlConnection);
                    //reader = searchCommand.ExecuteReader();
                    int returnCode = searchCommand.ExecuteNonQuery();



                    //var data = new Patient(reader[1].ToString(), reader[2].ToString(), reader[4].ToString(), "July", "10", "1992", "M");
                    sqlConnection.Close();
                    return returnCode;
                }
            }

            catch (SqlException ex)
            {
                return -1;
            }


        }

        /// <summary>
        /// Execute SQL data reader 
        /// </summary>
        /// <param name="inputQuery"></param>
        /// <returns></returns>
        private int ExecuteDataReader(string inputQuery)
        {

            SqlConnectionStringBuilder connStringBuild = new SqlConnectionStringBuilder();

            connStringBuild.DataSource = "tcp:kanban.database.windows.net,1433";
            connStringBuild.UserID = "SetUser3"; //standard Username
            connStringBuild.Password = "Conestoga1"; //standard Password
            connStringBuild.InitialCatalog = "kanban"; //inital DB
            SqlDataReader reader = null;

            int returnInteger = 0;

            
            try
            {

                using (SqlConnection sqlConnection = new SqlConnection(connStringBuild.ConnectionString))
                {


                    sqlConnection.Open();
                    SqlCommand searchCommand = new SqlCommand(inputQuery, sqlConnection);
                    reader = searchCommand.ExecuteReader();
                    //reader = searchCommand.ExecuteNonQuery();
                    while (reader.Read())
                    {
                        string returnValue = reader[0].ToString();
                        int.TryParse(returnValue, out returnInteger);
                    }

                    sqlConnection.Close();
                    return returnInteger;
                }
            }

            catch (SqlException ex)
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

        /// <summary>
        /// start button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            //disable start button
            startButton.Enabled = false;
            StopWorker = false;

            //enable stop button
            stopButton.Enabled = true;

            // add the workstation to the database
            AddWorkstationToDB();

            //get assembly time
            GetAssemblyTime();
            assemblyTimeLabel.Text = assemblyTime.ToString();

            //disable workstation input
            workstationInput.Enabled = false;

            //disable employee skill input
            employeeSkillInput.Enabled = false;

            //update start time
            UpdateStartTime();

            //Update current time
            UpdateCurrentTime();
            
            //start building fog lamps           
            AssembleFogLamp();

                

        }

        /// <summary>
        /// stop button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            //disable stop button
            stopButton.Enabled = false;

            //enable start button
            startButton.Enabled = true;

            //enable workstation input
            workstationInput.Enabled = true;

            //enable employee skill input
            employeeSkillInput.Enabled = true;

            StopWorker = true;

        }

        /// <summary>
        /// update start time label on form
        /// </summary>
        private void UpdateStartTime()
        {
            DateTime currentTime = DateTime.Now;
            startTimeLabel.Text = currentTime.ToString();
        }

        /// <summary>
        /// update current time label
        /// </summary>
        private void UpdateCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            currentTimeLabel.Text = currentTime.ToString();
        }

        /// <summary>
        /// Assemble fog lamp
        /// </summary>
        private void AssembleFogLamp()
        {
            

            if (StopWorker == false)
            {
                refillTime.AddSeconds(300f / timeScale);
                int currentAssemblyProgress = 0;
                int totalAssemblyTime = assemblyTime / timeScale;

                LogEvent($"Started to assemble fog lamp #{fogLampAssemblyCount + 1}");

                //setup progress bar
                progressBar.Maximum = totalAssemblyTime + 1;
                progressBar.Value = 0;


                do
                {
                    myTimer.Tick += new EventHandler(TimerEventProcessor);

                    // Sets the timer interval to 1 seconds.
                    myTimer.Interval = 1000;
                    myTimer.Start();

                    // Runs the timer, and raises the event.
                    while (exitFlag == false)
                    {
                        // Processes all the events in the queue.
                        Application.DoEvents();
                    }

                    exitFlag = false;

                    CheckIfRunnerHasArrived();

                    if (CanFogLampBeAssembled())
                    {

                        //update 1 second to current progress
                        UpdateProgressBar(currentAssemblyProgress, totalAssemblyTime);
                        currentAssemblyProgress++;
                    }
                    else
                    {
                        LogEvent("Do not have parts available for fog lamp");
                    }
                    UpdateCurrentTime();




                } while (currentAssemblyProgress < totalAssemblyTime);

                //update count and flag
                exitFlag = false;
                FogLampAssemblyCompleted();
                AssembleFogLamp();

                UpdateWorkstationRecord();
            }
            
        }

        /// <summary>
        /// check if runner has arrived with new parts
        /// </summary>
        private void CheckIfRunnerHasArrived()
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime > refillTime)
            {
                if (harnessQuantity < 5)
                {
                    harnessQuantity += harnessInitialQuantity;
                }
                else if(reflectorQuantity < 5)
                {
                    reflectorQuantity += reflectorInitialQuantity;
                }
                else if (housingQuantity < 5)
                {
                    housingQuantity += housingInitialQuantity;
                }
                else if (lensQuantity < 5)
                {
                    lensQuantity += lensInitialQuantity;
                }
                else if (bulbQuantity < 5)
                {
                    bulbQuantity += bulbInitialQuantity;
                }
                else if (bezelQuantity < 5)
                {
                    bezelQuantity += bezelInitialQuantity;
                }
            }
            
        }

        /// <summary>
        /// Update progress bar value
        /// </summary>
        /// <param name="currentProgress"></param>
        /// <param name="totalAssemblyTime"></param>
        private void UpdateProgressBar(int currentProgress, int totalAssemblyTime)
        {
            progressBar.Value = currentProgress;
        }



        /// <summary>
        /// fog lamp has been completed
        /// </summary>
        private void FogLampAssemblyCompleted()
        {
            int workstationNumber = 0;
            int.TryParse(workstationInput.Value.ToString(), out workstationNumber);
            fogLampAssemblyCount++;

            LogEvent($"Fog lamp has been assembled: #{fogLampAssemblyCount}");            

            UpdatePartQuantities();

            if (fogLampAssemblyCount == testTraySize)
            {
                SendTestTray();
                LogEvent("Test tray has been filled and sent");
                fogLampAssemblyCount = 0;
            }


        }

        /// <summary>
        /// update part quantities
        /// </summary>
        private void UpdatePartQuantities()
        {
            //decrement all part quantities by 1
            harnessQuantity--;
            reflectorQuantity--;
            housingQuantity--;
            lensQuantity--;
            bulbQuantity--;
            bezelQuantity--;

        }


        /// <summary>
        /// check if fog lamp can be completed
        /// </summary>
        /// <returns></returns>
        private bool CanFogLampBeAssembled()
        {
            if (harnessQuantity < 1)
            {
                return false;
            }
            if (reflectorQuantity < 1)
            {
                return false;
            }
            if (housingQuantity < 1)
            {
                return false;
            }
            if (lensQuantity < 1)
            {
                return false;
            }
            if (bulbQuantity < 1)
            {
                return false;
            }
            if (bezelQuantity < 1)
            {
                return false;
            }

            return true;
        }
        


        // This is the method to run when the timer is raised.
        private static void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            myTimer.Stop();

            // Stops the timer.
            exitFlag = true;
        }

        /// <summary>
        /// get parts
        /// </summary>
        private void GetParts()
        {

            
            SqlConnectionStringBuilder connStringBuild = new SqlConnectionStringBuilder();

            connStringBuild.DataSource = "tcp:kanban.database.windows.net,1433";
            connStringBuild.UserID = "SetUser3"; //standard Username
            connStringBuild.Password = "Conestoga1"; //standard Password
            connStringBuild.InitialCatalog = "kanban"; //inital DB

            SqlDataReader reader = null;        

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connStringBuild.ConnectionString))
                {
                    //OleDbCommand command = new OleDbCommand(("[dbo].[GetPartQuantities]".ToString()), connection);

                    //connection.Open();
                    //OleDbDataReader reader = command.ExecuteReader();

                    sqlConnection.Open();
                    SqlCommand searchCommand = new SqlCommand(("[dbo].[GetPartQuantities]".ToString()), sqlConnection);
                    reader = searchCommand.ExecuteReader();


                    while (reader.Read())
                    {
                        //harness
                        string harnessQuantityValue = reader[0].ToString();
                        int harnessQuantityInt = 0;
                        int.TryParse(harnessQuantityValue, out harnessQuantityInt);
                        harnessQuantity = harnessQuantityInt;
                        harnessInitialQuantity = harnessQuantityInt;
                        

                        //reflector
                        string reflectorQuantityValue = reader[1].ToString();
                        int reflectorQuantityInt = 0;
                        int.TryParse(reflectorQuantityValue, out reflectorQuantityInt);
                        reflectorQuantity = reflectorQuantityInt;
                        reflectorInitialQuantity = reflectorQuantityInt;

                        //housing
                        string housingQuantityValue = reader[2].ToString();
                        int housingQuantityInt = 0;
                        int.TryParse(housingQuantityValue, out housingQuantityInt);
                        housingQuantity = housingQuantityInt;
                        housingInitialQuantity = housingQuantityInt;

                        //lensQuantity
                        string lensQuantityValue = reader[3].ToString();
                        int lensQuantityInt = 0;
                        int.TryParse(lensQuantityValue, out lensQuantityInt);
                        lensQuantity = lensQuantityInt;
                        lensInitialQuantity = lensQuantityInt;

                        //bulbQuantity
                        string bulbQuantityValue = reader[4].ToString();
                        int bulbQuantityInt = 0;
                        int.TryParse(bulbQuantityValue, out bulbQuantityInt);
                        bulbQuantity = bulbQuantityInt;
                        bulbInitialQuantity = bulbQuantityInt;

                        //bezelQuantity
                        string bezelQuantityValue = reader[5].ToString();
                        int bezelQuantityInt = 0;
                        int.TryParse(bezelQuantityValue, out bezelQuantityInt);
                        bezelQuantity = bezelQuantityInt;
                        bezelInitialQuantity = bezelQuantityInt;


                    }
                    //reader.Close();
                    sqlConnection.Close();

                }
            }
            catch (Exception e)
            {                
                LogEvent("Error getting part quantities from database server");
            }
            
        }

    }
}
