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
                LogEvent($"Employee assembly time: {assemblyTime}");
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

                UpdateCurrentTime();
                exitFlag = false;

                //update 1 second to current progress
                currentAssemblyProgress++;

            } while (currentAssemblyProgress < totalAssemblyTime);

            //update count and flag
            exitFlag = false;
            FogLampAssemblyCompleted();
            AssembleFogLamp();
        }

        private void FogLampAssemblyCompleted()
        {
            int workstationNumber = 0;
            int.TryParse(workstationInput.Value.ToString(), out workstationNumber);
            fogLampAssemblyCount++;

            LogEvent($"Fog lamp has been assembled: #{fogLampAssemblyCount}");

            LogEvent("Sending fog lamp assembly message to server");


        }

        // This is the method to run when the timer is raised.
        private static void TimerEventProcessor(Object myObject,
                                                EventArgs myEventArgs)
        {
            myTimer.Stop();

            // Stops the timer.
            exitFlag = true;
        }

    }
}
