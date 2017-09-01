//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//          Project: KPA-KPI Analysis Application
//          Company: Comau North America
//
//          Developer: Jonathan Michael Sultana
//          Date: 06/09/2017
//          
//          "Once you stop learning you start dying" - Albert Einstein
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.IOUtils;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        private FormData frmData = new FormData();
        private static readonly List<string> errorList = new List<string>();
        private Overall overallData = new Overall();
        private UserControl activeTemplate = new UserControl();






        /// <summary>
        /// The initital constructor of the main ui
        /// </summary>
        public KPA_KPI_UI()
        {
            InitializeComponent();
            NavigationLocked = true;
            PRPO_DB_Utils.AI = AccessUtils.AI;
        }






        /// <summary>
        /// The custom constructor of the main user interface. This constructor takes a database conenection that will be used
        /// to connect to and read data from.
        /// </summary>
        /// <param name="conn">The database connection that was established in the splash scree.</param>
        public KPA_KPI_UI(OleDbConnection conn)
        {
            InitializeComponent();

            // Configure the database Utilities class.
            PRPO_DB_Utils.AI = AccessUtils.AI;
            PRPO_DB_Utils.DatabaseConnection = new OleDbConnection(conn.ConnectionString);
        }






        /// <summary>
        /// This function will be called when the form loads.
        /// </summary>
        /// <param name="sender">The form</param>
        /// <param name="e">The load event</param>
        private void KPA_KPI_UI_Load(object sender, EventArgs e)
        {
            mainNavActiveBtn = btn_Dashboard; // set the active button as the first button (Dashboard)
            FilterUtils.UpdateFilter += UpdateFilters;


            if (PRPO_DB_Utils.DatabaseConnection != null)
            {
                try
                {
                    PRPO_DB_Utils.ConnectToDatabase();
                    //btn_DatabaseConnectionStatus.Image = Properties.Resources.databaseConn_Connected_Icon;
                    Logger.Log(AppDirectoryUtils.LogFiles.DbConnectionEvents, "Successfully Connected to MS Access Database");

                    if (AccessUtils.US_PRPO_TableExists && AccessUtils.MX_PRPO_TableExists)
                    {
                        NavigationLocked = true;
                        pnl_CountrySelector.BringToFront();
                    }
                    else if (AccessUtils.US_PRPO_TableExists)
                    {
                        lbl_Country.Text = "United States";
                        Overall.SelectedCountry = AccessInfo.MainTables.US_PRPO;
                        PRPO_DB_Utils.DataLoadProcessStarted = false;
                        PRPO_DB_Utils.DataLoaded = false;
                        PRPO_DB_Utils.CompletedDataLoads = 0;
                        PRPO_DB_Utils.ScheduledDataLoads = 0;
                        DataLoaderTimer.Start();
                    }
                    else // There is a Mexico table within the database.
                    {
                        lbl_Country.Text = "Mexico";
                        Overall.SelectedCountry = AccessInfo.MainTables.MX_PRPO;
                        PRPO_DB_Utils.DataLoadProcessStarted = false;
                        PRPO_DB_Utils.DataLoaded = false;
                        PRPO_DB_Utils.CompletedDataLoads = 0;
                        PRPO_DB_Utils.ScheduledDataLoads = 0;
                        DataLoaderTimer.Start();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Application load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                pnl_loadingScreen.Visible = false;
                tblpnl_DragDrop.BringToFront();
            }

        }






        /// <summary>
        /// This form prevents flickering of the UI when it repaints.
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                handleParam.Style &= ~0x2000000; // Turn off WS_CLIPCHILDREN
                return handleParam;
            }
        }






        /////////////////////////////////////////////////// UI DIALOGS //////////////////////////////////////////////////
        //
        //  here we can control the behavior of the form.
        // 
        //  These functions perform the following
        //  1) minimize the form into the taskbar.
        //  2) maximize the form to the size of the screen and min down to normal size.
        //  3) close the application.
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region UI_Dialogs
        /// <summary>
        /// This event will change the button background image while the user has their cursor over it.
        /// </summary>
        /// <param name="sender">The button</param>
        /// <param name="e">The Mouse Hover Event</param>
        private void btn_Expand_MouseHover(object sender, EventArgs e)
        {
            pnl_Maximize.BackgroundImage = Properties.Resources.Maximize_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave Event</param>
        private void btn_Expand_MouseLeave(object sender, EventArgs e)
        {
            pnl_Maximize.BackgroundImage = Properties.Resources.Maximize;
        }






        /// <summary>
        /// This event will trigger when the user clicks the expand button and the form will expand.
        /// </summary>
        /// <param name="sender">The expand button</param>
        /// <param name="e">The click event.</param>
        private void btn_Expand_Click(object sender, EventArgs e)
        {
            FormSizer();
        }






        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Enter Event</param>
        private void btn_Minimize_MouseEnter(object sender, EventArgs e)
        {
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize_Hover_Icon;
        }






        /// <summary>
        /// This event will change the background of the image back to the original image.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the Mouse Leave event</param>
        private void btn_Minimize_MouseLeave(object sender, EventArgs e)
        { 
            pnl_Minimize.BackgroundImage = Properties.Resources.Minimize;
        }






        /// <summary>
        /// This event will trigger when the user clicks the minimize button. The form will minimize into the taskbar.
        /// </summary>
        /// <param name="sender">The minimize button</param>
        /// <param name="e">The click event.</param>
        private void btn_Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;






        /// <summary>
        /// This event will change the background of the button when the user hovers over it.
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">The Mouse Over event</param>
        private void btn_Close_MouseHover(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close_Hover_icon;
        }






        /// <summary>
        /// This event will change the background of the button back to the original background image.
        /// </summary>
        /// <param name="sender">the close button</param>
        /// <param name="e">The MouseLeave event</param>
        private void btn_Close_MouseLeave(object sender, EventArgs e)
        {
            pnl_Close.BackgroundImage = Properties.Resources.Close;
        }






        /// <summary>
        /// This event will close the entire application (process)
        /// </summary>
        /// <param name="sender">The Close button</param>
        /// <param name="e">The click event</param>
        private void btn_Close_Click(object sender, EventArgs e) => Application.Exit();
        #endregion






        /////////////////////////////////////////////////// TOP PANEL //////////////////////////////////////////////////
        //
        //  Here we can control the behavior of the for with the top panel.
        // 
        //  These functions perform the following.
        //  1) size the form to the size of the screen when double clicked.
        //
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region Top_Panel
        /// <summary>
        /// This event will trigger when the user double clicks the top panel of the the UI. This will max out the size of 
        /// the screen based on the size of the working area of the computer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnl_TopPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormSizer();
        }








        /// <summary>
        /// This function will expand or minimize to original window size.
        /// </summary>
        private void FormSizer()
        {
            Screen screen = Screen.FromControl(this);

            if (Width == screen.WorkingArea.Width && Height == screen.WorkingArea.Height) // the form is maxed
            {
                Width = Constants.minFormWidth;
                Height = Constants.minFormHeight;
                Left = frmData.FrmX;
                Top = frmData.FrmY;
            }
            else // the form is its default size
            {
                frmData.FrmX = Left;
                frmData.FrmY = Top;
                Left = screen.WorkingArea.Left;
                Top = screen.WorkingArea.Top;
                Height = screen.WorkingArea.Height;
                Width = screen.WorkingArea.Width;

            }
            RefreshTemplate();
        }
        #endregion
    }
}