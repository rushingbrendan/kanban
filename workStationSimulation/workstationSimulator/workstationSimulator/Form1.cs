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

namespace workstationSimulator
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static bool exitFlag = false;
        static int alarmCounter = 1;


        private string sourceConnectionString { get; set; }
        private int numberOfWorkstations { get; set; }
        private int timeScale { get; set; }

        private int assemblyTime { get; set; }

        private int testTraySize { get; set; }


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

        private bool harnessOrdered { get; set; }
        private bool reflectorOrdered { get; set; }
        private bool housingOrdered { get; set; }
        private bool lensOrdered { get; set; }
        private bool bulbOrdered { get; set; }
        private bool bezelOrdered { get; set; }

        private DateTime? harnessReplenishTime { get; set; }
        private DateTime? reflectorReplenishTime { get; set; }
        private DateTime? housingReplenishTime { get; set; }
        private DateTime? lensReplenishTime { get; set; }
        private DateTime? bulbReplenishTime { get; set; }
        private DateTime? bezelReplenishTime { get; set; }


        private int fogLampAssemblyCount = 0;

        public Form1()
        {
            InitializeComponent();

            InitializeForm();
        }

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


        }

        private void SendTestTray()
        {
            int i = 0;
        }

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

        private void startButton_Click(object sender, EventArgs e)
        {
            //disable start button
            startButton.Enabled = false;

            //enable stop button
            stopButton.Enabled = true;

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

        }

        private void UpdateStartTime()
        {
            DateTime currentTime = DateTime.Now;
            startTimeLabel.Text = currentTime.ToString();
        }

        private void UpdateCurrentTime()
        {
            DateTime currentTime = DateTime.Now;
            currentTimeLabel.Text = currentTime.ToString();
        }

        private void AssembleFogLamp()
        {
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

                CheckPartQuantity();

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
        }

        private void CheckIfRunnerHasArrived()
        {
            DateTime currentTime = DateTime.Now;

            if ((harnessReplenishTime < currentTime) && (harnessOrdered))
            {                
                harnessOrdered = false;
                harnessReplenishTime = null;
                harnessQuantity += harnessInitialQuantity;

            }
            if ((reflectorReplenishTime < currentTime) && (reflectorOrdered))
            {
                
                reflectorOrdered = false;
                reflectorReplenishTime = null;
                reflectorQuantity += reflectorInitialQuantity;
            }
            if ((housingReplenishTime < currentTime) && (housingOrdered))
            {
                
                housingOrdered = false;
                housingReplenishTime = null;
                housingQuantity += housingInitialQuantity;
            }
            if ((lensReplenishTime < currentTime) && (lensOrdered))
            {

                lensOrdered = false;
                lensReplenishTime = null;
                lensQuantity += lensInitialQuantity;
            }
            if ((bulbReplenishTime < currentTime) && (bulbOrdered))
            {
                
                bulbOrdered = false;
                bulbReplenishTime = null;
                bulbQuantity += bulbInitialQuantity;
            }
            if ((bezelReplenishTime < currentTime) && (bezelOrdered))
            {
                
                bezelOrdered = false;
                bezelReplenishTime = null;
                bezelQuantity += bezelInitialQuantity;
            }
        }

        private void UpdateProgressBar(int currentProgress, int totalAssemblyTime)
        {
            progressBar.Value = currentProgress;
        }



        private void FogLampAssemblyCompleted()
        {
            int workstationNumber = 0;
            int.TryParse(workstationInput.Value.ToString(), out workstationNumber);
            fogLampAssemblyCount++;

            LogEvent($"Fog lamp has been assembled: #{fogLampAssemblyCount}");

            LogEvent("Sending fog lamp assembly message to server");

            UpdatePartQuantities();

            if (fogLampAssemblyCount == testTraySize)
            {
                SendTestTray();
                LogEvent("Test tray has been filled and sent");
                fogLampAssemblyCount = 0;
            }


        }

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
        private void CheckPartQuantity()
        {
            if ((harnessQuantity < 6) && (!harnessOrdered))
            {
                RequestPartFromRunner("harness");
                harnessOrdered = true;
                harnessReplenishTime = DateTime.Now.AddMinutes(5/timeScale);

            }
            if ((reflectorQuantity < 6) && (!reflectorOrdered))
            {
                RequestPartFromRunner("reflector");
                reflectorOrdered = true;
                reflectorReplenishTime = DateTime.Now.AddMinutes(5 / timeScale);
            }
            if ((housingQuantity < 6) && (!housingOrdered))
            {
                RequestPartFromRunner("housing");
                housingOrdered = true;
                housingReplenishTime = DateTime.Now.AddMinutes(5 / timeScale);
            }
            if ((lensQuantity < 6) && (!lensOrdered))
            {
                RequestPartFromRunner("lens");
                lensOrdered = true;
                lensReplenishTime = DateTime.Now.AddMinutes(5 / timeScale);
            }
            if( (bulbQuantity < 6) && (!bulbOrdered))
            {
                RequestPartFromRunner("bulb");
                bulbOrdered = true;
                bulbReplenishTime = DateTime.Now.AddMinutes(5 / timeScale);
            }
            if ((bezelQuantity < 6) && (!bezelOrdered))
            {
                RequestPartFromRunner("bezel");
                bezelOrdered = true;
                bezelReplenishTime = DateTime.Now.AddMinutes(5 / timeScale);
            }
        }

        private void RequestPartFromRunner(string partName)
        {
            ExecuteNonQueryCommand($"[dbo].[RequestPartFromRunner] '{partName}', '{workstationInput.Value}'");
        }

        // This is the method to run when the timer is raised.
        private static void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            myTimer.Stop();

            // Stops the timer.
            exitFlag = true;
        }

        private void GetParts()
        {

            try
            {
                using (OleDbConnection connection = new OleDbConnection(this.sourceConnectionString))
                {
                    OleDbCommand command = new OleDbCommand(("[dbo].[GetPartQuantities]".ToString()), connection);

                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

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
                    reader.Close();
                    
                }
            }
            catch (Exception e)
            {                
                LogEvent("Error getting part quantities from database server");
            }
            
        }

    }
}
