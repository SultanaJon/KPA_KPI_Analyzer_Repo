﻿using Excel_Access_Tools.Access;
using Excel_Access_Tools.Access.ExceptionClasses;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class SplashScreen : Form
    {
        private bool runningThread = false;
        private OleDbConnection conn = null;
        List<string> errorList;




        /// <summary>
        /// The state that the current parallel running thread is in.
        /// </summary>
        internal enum State
        {
            DirectoryCheck,
            FileCheck,
            DatabaseCheck,
        }




        /// <summary>
        /// The status of the state that the currently parallel running thread is in.
        /// </summary>
        internal enum CheckStatus
        {
            Checking,
            Complete
        }




        /// <summary>
        /// The status of the loading operation of the application.
        /// </summary>
        internal enum LoadStatus
        {
            Loading,
            Complete
        }


        

        /// <summary>
        /// The Current state of the secondary thread
        /// </summary>
        internal static State CurrentState { get; set; }





        /// <summary>
        /// The current status of the secondary thread.
        /// </summary>
        internal static CheckStatus CurrentStatus { get; set; }





        /// <summary>
        /// The current status of the application load operation.
        /// </summary>
        internal static  LoadStatus CurrentAppStatus { get; set; }






        /// <summary>
        /// Constructor
        /// </summary>
        public SplashScreen()
        {
            InitializeComponent();
            CurrentState = State.DirectoryCheck;
            CurrentStatus = CheckStatus.Checking;
            CurrentAppStatus = LoadStatus.Loading;

            errorList = new List<string>();

            AccessUtils.AppDirectoryPath = Configuration.AppDir;
            AccessUtils.DatabasePath = Configuration.DbPath;
            AccessUtils.AI = new AccessInfo { FileName = Configuration.DbPath };
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
                else
                {

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
                        this.Hide();
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

                if (conn != null)
                    Application.Run(new KPA_KPI_UI(conn));
                else
                    Application.Run(new KPA_KPI_UI());
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
            lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Checking Folder Structure..."; });

            try
            {
                foreach (var directory in Enum.GetValues(typeof(IOUtils.AppDirectoryUtils.Directories)))
                {
                    if (!Directory.Exists(Path.Combine(Configuration.AppDir, IOUtils.AppDirectoryUtils.DirectoryStructures[(int)directory])))
                    {
                        lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Creating Directory - " + IOUtils.AppDirectoryUtils.DirectoryStructures[(int)directory]; });
                        Directory.CreateDirectory(Path.Combine(Configuration.AppDir, IOUtils.AppDirectoryUtils.DirectoryStructures[(int)directory]));
                    }
                }
            }
            catch(Exception ex)
            {
                errorList.Add(ex.Message);
                errorList.Add("There was an error generated while trying to create an application directory.");
                using (IOUtils.ErrorMessageBox errmsgbx = new IOUtils.ErrorMessageBox() { Errors = errorList })
                {
                    if (errmsgbx.ShowDialog() == DialogResult.OK)
                    {
                        errmsgbx.Close();
                    }
                }
            }
            

            Thread.Sleep(2000);
            CurrentStatus = CheckStatus.Complete;
        }






        /// <summary>
        /// This function will check the files of the application. If they are not there, create them.
        /// </summary>
        private void CheckApplicationFiles()
        {
            lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Checking Application Files..."; });
            try
            {
                foreach (var file in Enum.GetValues(typeof(IOUtils.AppDirectoryUtils.ResourceFiles)))
                {
                    if (!File.Exists(Path.Combine(Configuration.AppDir, IOUtils.AppDirectoryUtils.resourceFiles[(int)file])))
                    {
                        lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Creating File - " + IOUtils.AppDirectoryUtils.resourceFiles[(int)file]; });
                        try
                        {
                            AccessUtils.CreateAccessDB();
                        }
                        catch(Exception ex)
                        {
                            throw ex; // throw the exception thrown by AccesUtils
                        }
                        Thread.Sleep(2000);
                    }
                }

                foreach (var file in Enum.GetValues(typeof(IOUtils.AppDirectoryUtils.ReportFiles)))
                {
                    if (!File.Exists(Path.Combine(Configuration.AppDir, IOUtils.AppDirectoryUtils.reportFiles[(int)file])))
                    {
                        lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Creating File - " + IOUtils.AppDirectoryUtils.reportFiles[(int)file]; });
                        File.Create(IOUtils.AppDirectoryUtils.reportFiles[(int)file]);
                        Thread.Sleep(2000);
                    }
                }

                foreach (var file in Enum.GetValues(typeof(IOUtils.AppDirectoryUtils.LogFiles)))
                {
                    if (!File.Exists(Path.Combine(Configuration.AppDir, IOUtils.AppDirectoryUtils.logFiles[(int)file])))
                    {
                        lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Creating File - " + IOUtils.AppDirectoryUtils.logFiles[(int)file]; });
                        File.Create(Path.Combine(Configuration.AppDir, IOUtils.AppDirectoryUtils.logFiles[(int)file]));
                        Thread.Sleep(2000);
                    }
                }
            }
            catch(DatabaseCreationFailureException ex)
            {
                errorList.Add(ex.Message);
                using (IOUtils.ErrorMessageBox errmsgbx = new IOUtils.ErrorMessageBox() { Errors = errorList })
                {
                    if(errmsgbx.ShowDialog() == DialogResult.OK)
                    {
                        errmsgbx.Close();
                        Application.Exit();
                    }
                }
            }
            catch(Exception ex)
            {
                errorList.Add(ex.Message);
                using (IOUtils.ErrorMessageBox errmsgbx = new IOUtils.ErrorMessageBox() { Errors = errorList })
                {
                    if (errmsgbx.ShowDialog() == DialogResult.OK)
                    {
                        errmsgbx.Close();
                    }
                }
            }
            
            Thread.Sleep(2000);
            CurrentStatus = CheckStatus.Complete;
        }







        /// <summary>
        /// This function will check the presence of the database used to read data from.
        /// </summary>
        private void CheckDatabase()
        {
            try
            {
                lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Checking for a valid database..."; });
                Thread.Sleep(2000);
                AccessUtils.CheckDatabase();
                lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Valid database found. Establishing a connection..."; });

                conn = new OleDbConnection(AccessUtils.AI.connectionString());

                    Thread.Sleep(5000);
                CurrentStatus = CheckStatus.Complete;
            }
            catch(TablesDoNotExistException)
            {
                // The database exists but the tables did not. We want to keep the current database but we do not want to attempt to connect.
                CurrentStatus = CheckStatus.Complete;
            }
            catch (PRPODatabaseNotFoundException)
            {
                // The database did not exist so create a new one before the application starts.
                lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Creating new database..."; });
                try
                {
                    AccessUtils.CreateAccessDB();
                }
                catch(DatabaseCreationFailureException ex)
                {
                    errorList.Add(ex.Message);
                    using (IOUtils.ErrorMessageBox errmsgbx = new IOUtils.ErrorMessageBox() { Errors = errorList })
                    {
                        if (errmsgbx.ShowDialog() == DialogResult.OK)
                        {
                            errmsgbx.Close();
                            Application.Exit();
                        }
                    }
                }
                Thread.Sleep(2000);
                CurrentStatus = CheckStatus.Complete;
            }
            catch (TableNameMismatchException)
            {
                // The names of the table are not correct so lets delete the database and create a new one and
                // wait for the user to drop new files to load.
                lbl_CheckStatus.Invoke((MethodInvoker)delegate { lbl_CheckStatus.Text = "Database error! Creating new database..."; });

                try
                {
                    File.Delete(Configuration.DbPath);
                    AccessUtils.CreateAccessDB();
                    Thread.Sleep(2000);
                    CurrentStatus = CheckStatus.Complete;
                }
                catch (DatabaseCreationFailureException ex)
                {
                    errorList.Add(ex.Message);
                    using (IOUtils.ErrorMessageBox errmsgbx = new IOUtils.ErrorMessageBox() { Errors = errorList })
                    {
                        if (errmsgbx.ShowDialog() == DialogResult.OK)
                        {
                            errmsgbx.Close();
                            Application.Exit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Something happened while deleting the file
                    errorList.Add(ex.Message);
                    errorList.Add("There was an error while attempting to delete the MS Access Database");
                    using (IOUtils.ErrorMessageBox errmsgbx = new IOUtils.ErrorMessageBox() { Errors = errorList })
                    {
                        if (errmsgbx.ShowDialog() == DialogResult.OK)
                        {
                            errmsgbx.Close();
                            Application.Exit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Some other type of run-time error occured.
                errorList.Add(ex.Message);
                using (IOUtils.ErrorMessageBox errmsgbx = new IOUtils.ErrorMessageBox() { Errors = errorList })
                {
                    if (errmsgbx.ShowDialog() == DialogResult.OK)
                    {
                        errmsgbx.Close();
                        Application.Exit();
                    }
                }
            }
        }
    }
}
