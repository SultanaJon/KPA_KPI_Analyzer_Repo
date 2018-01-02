using DataImporter.Access.ExceptionClasses;
using System;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DataAccessLibrary;

namespace KPA_KPI_Analyzer
{
    public partial class SplashScreen : Form
    {
        private bool runningThread = false;
        ApplicationIOLibarary.ApplicationSettings settings = new ApplicationIOLibarary.ApplicationSettings();
        bool settingsCreated = false;
        bool databaseCreated = false;


        /// <summary>
        /// The state that the current parallel running thread is in.
        /// </summary>
        public enum State
        {
            DirectoryCheck,
            FileCheck,
            DatabaseCheck,
        }




        /// <summary>
        /// The status of the state that the currently parallel running thread is in.
        /// </summary>
        public enum CheckStatus
        {
            Checking,
            Complete
        }




        /// <summary>
        /// The status of the loading operation of the application.
        /// </summary>
        public enum LoadStatus
        {
            Loading,
            Complete
        }


        

        /// <summary>
        /// The Current state of the secondary thread
        /// </summary>
        public static State CurrentState { get; set; }





        /// <summary>
        /// The current status of the secondary thread.
        /// </summary>
        public static CheckStatus CurrentStatus { get; set; }





        /// <summary>
        /// The current status of the application load operation.
        /// </summary>
        public static  LoadStatus CurrentAppStatus { get; set; }






        /// <summary>
        /// Default Constructor
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();
            CurrentState = State.DirectoryCheck;
            CurrentStatus = CheckStatus.Checking;
            CurrentAppStatus = LoadStatus.Loading;

            ApplicationIOLibarary.ApplicationFiles.FileUtils fileUtils = new ApplicationIOLibarary.ApplicationFiles.FileUtils();

            // Supply the information regarding the access file we will use for our 
            // datbase to the DatabaseManager.
            DatabaseManager.Configure(new AccessInfo(fileUtils.DbPath));
        }






        /// <summary>
        /// A timer used to check the current status of the applicaiton load.
        /// </summary>
        /// <param name="sender">The timer</param>
        /// <param name="e">the tick event</param>
        private void timer1_Tick(object sender, EventArgs e)
            {
                if(runningThread == false && CurrentAppStatus != LoadStatus.Complete)
                {
                    runningThread = true;
                    if(CurrentState == State.DirectoryCheck)
                    {
                        new Thread(() => {
                            CheckApplicationFolderStructure();
                        }).Start();
                    }
                    else if(CurrentState == State.FileCheck)
                    {
                        new Thread(() => {
                            CheckApplicationFiles();
                        }).Start();
                    }
                    else if(CurrentState == State.DatabaseCheck)
                    {
                        new Thread(() => {
                            CheckDatabase();
                        }).Start();
                    }
                }
                else
                {
                
                    if(CurrentStatus == CheckStatus.Complete)
                    {
                        if (CurrentState == State.DatabaseCheck)
                        {
                            CurrentAppStatus = LoadStatus.Complete;
                            Thread thrd = new Thread(() => { loadMainThread(); });
                            thrd.SetApartmentState(ApartmentState.STA);
                            Hide();
                            timer1.Stop();
                            thrd.Start();
                            thrd.Join(); // Wait here on this thread until the application is closed.
                            Application.Exit(); // Close the splash screen (main thread)
                        }
                        else
                        {
                            runningThread = false;
                            CurrentStatus = CheckStatus.Checking;
                            CurrentState++;
                        }                   
                    }
                }
            }






        /// </summary>
        /// Load the main applicaiton. If the database was present and the tables existed, create the main application with a valid database connection.
        /// <summary>
        public void loadMainThread()
        {
            if (CurrentAppStatus == LoadStatus.Complete)
            {
                if (!settingsCreated)
                {
                    try
                    {
                        settings.Load(ref settings);
                        Application.Run(new KPA_KPI_UI(settings));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    Application.Run(new KPA_KPI_UI());
                }
            }
        }






        /// <summary>
        /// This event will trigger when the application is closed.
        /// </summary>
        /// <param name="sender">The form</param>
        /// <param name="e">the close event</param>
        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
                Application.Exit();
        }






        /// <summary>
        /// This function will check the application directories and make sure they are all there before continueing.
        /// </summary>
        private void CheckApplicationFolderStructure()
        {
            try
            {
                foreach (var directory in Enum.GetValues(typeof(ApplicationIOLibarary.ApplicationDirectories.AppDirectory)))
                {
                    if (!Directory.Exists(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.directories[(int)directory])))
                    {
                        Directory.CreateDirectory(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.directories[(int)directory]));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            CurrentStatus = CheckStatus.Complete;
        }






        /// <summary>
        /// This function will check the files of the application. If they are not there, create them.
        /// </summary>
        private void CheckApplicationFiles()
        {
            try
            {
                foreach (ApplicationIOLibarary.ApplicationFiles.ResourceFile file in Enum.GetValues(typeof(ApplicationIOLibarary.ApplicationFiles.ResourceFile)))
                {
                    if (!File.Exists(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationFiles.FileUtils.resourcesFiles[(int)file])))
                    {
                        if(file == ApplicationIOLibarary.ApplicationFiles.ResourceFile.PRPO_Database)
                        {
                            try
                            {
                                DatabaseManager.CreateAccessDB();
                                databaseCreated = true;

                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                        else
                        {
                            if(file == ApplicationIOLibarary.ApplicationFiles.ResourceFile.Settings)
                            {
                                ApplicationIOLibarary.ApplicationFiles.FileUtils.CreateFile(file);
                                settingsCreated = true;
                            }
                        }
                    }
                }


                foreach (ApplicationIOLibarary.ApplicationFiles.LogFile file in Enum.GetValues(typeof(ApplicationIOLibarary.ApplicationFiles.LogFile)))
                {
                    if (!File.Exists(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationFiles.FileUtils.logFiles[(int)file])))
                    {
                        ApplicationIOLibarary.ApplicationFiles.FileUtils.CreateFile(file);
                    }
                }




                foreach(ApplicationIOLibarary.ApplicationFiles.OverallFile file in Enum.GetValues(typeof(ApplicationIOLibarary.ApplicationFiles.OverallFile)))
                {
                    if (!File.Exists(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)file])))
                    {
                        ApplicationIOLibarary.ApplicationFiles.FileUtils.CreateFile(file);
                    }
                }



                foreach(ApplicationIOLibarary.ApplicationFiles.VariantFile file in Enum.GetValues(typeof(ApplicationIOLibarary.ApplicationFiles.VariantFile)))
                {
                    if(!File.Exists(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationFiles.FileUtils.variantFiles[(int)file])))
                    {
                        ApplicationIOLibarary.ApplicationFiles.FileUtils.CreateFile(file);
                    }
                }
            }
            catch(DatabaseCreationFailureException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CurrentStatus = CheckStatus.Complete;
        }







        /// <summary>
        /// This function will check the presence of the database used to read data from.
        /// </summary>
        private void CheckDatabase()
        {
            // Connect to the database.
            DatabaseManager.ConnectToDatabase();


            if(databaseCreated && !settingsCreated)
            {
                // The database was just creaed so we need to delete the settings
                // file and create a new one as the settings it might contain are
                // no longer valid for the database.
                if(File.Exists(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationFiles.FileUtils.resourcesFiles[(int)ApplicationIOLibarary.ApplicationFiles.ResourceFile.Settings])))
                {
                    File.Delete(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationFiles.FileUtils.resourcesFiles[(int)ApplicationIOLibarary.ApplicationFiles.ResourceFile.Settings]));
                    ApplicationIOLibarary.ApplicationFiles.FileUtils.CreateFile(ApplicationIOLibarary.ApplicationFiles.ResourceFile.Settings);
                    settingsCreated = true;
                }
            }
            else
            {
                // Check if the database contains tables
                if(!DatabaseManager.CheckForTables() && !settingsCreated)
                {
                    // The database does not contain tables so we want to reset any settings regarding the database.
                    File.Delete(Path.Combine(ApplicationIOLibarary.ApplicationDirectories.DirectoryUtils.AppDir, ApplicationIOLibarary.ApplicationFiles.FileUtils.resourcesFiles[(int)ApplicationIOLibarary.ApplicationFiles.ResourceFile.Settings]));
                    ApplicationIOLibarary.ApplicationFiles.FileUtils.CreateFile(ApplicationIOLibarary.ApplicationFiles.ResourceFile.Settings);
                    settingsCreated = true;
                }
            }

            // Connect to the database
            CurrentStatus = CheckStatus.Complete;
        }
    }
}