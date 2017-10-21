using KPA_KPI_Analyzer.Values;
using System;
using System.Data;
using System.Windows.Forms;
using KPA_KPI_Analyzer.DataLoading;
using System.Threading;
using System.Diagnostics;
using DataExporter;

namespace KPA_KPI_Analyzer
{
    public partial class DataViewer : Form
    {
        #region MEMBERS

        private FormData frmData = new FormData();
        Thread thrd;

        // Call back used to load the data into the data viewer
        public delegate void LoadDataGridHandler(int _tag);
        public event LoadDataGridHandler DataLoader;
        #endregion



        #region PROPERTIES
        /// <summary>
        /// 
        /// </summary>
        public int ColumnTag { get; set; }



        /// <summary>
        /// Current selected country to display in the data viewer
        /// </summary>
        public string Country { set { lbl_Country.Text = value; } }
        

        /// <summary>
        /// Current selected performance to display in the data viewer
        /// </summary>
        public string Performance { set { lbl_Performance.Text = value; } }


        /// <summary>
        /// Current selected section to display in the data viewer
        /// </summary>
        public string Section { set { lbl_Section.Text = value; } }



        /// <summary>
        /// Current selected category to display in the data viewer
        /// </summary>
        public string Category { set { lbl_Category.Text = value; } }


        #endregion



        #region CONSTRUCTORS
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataViewer()
        {
            InitializeComponent();
            lbl_Country.Text = Globals.CurrCountry;
            lbl_date.Text = Globals.PrpoGenerationDate;
            dgv_dataViewerDgv.DoubleBuffered = true;
        }
        #endregion







        /// <summary>
        /// The load event is triggered once the form is created
        /// </summary>
        /// <param name="sender">The form</param>
        /// <param name="e">The load event</param>
        private void DataViewer_Load(object sender, EventArgs e)
        {
            DataViewerUtils.DataLoaded = false;
            DataViewerUtils.DataLoadProcessStarted = false;

            lbl_Performance.Text = Globals.CurrPerformance;
            lbl_Section.Text = Globals.CurrSection;
            lbl_Category.Text = Globals.CurrCategory;

            tmr_waitTimer.Start();
        }










        ///// <summary>
        ///// This form prevents flickering of the UI when it repaints.
        ///// </summary>
        ///// <remarks>
        /////     06/25/2017 - Created
        ///// </remarks>
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams handleParam = base.CreateParams;
        //        //handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
        //        handleParam.Style &= ~0x2000000; // Turn off WS_CLIPCHILDREN
        //        return handleParam;
        //    }
        //}








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
        private void btn_Close_Click(object sender, EventArgs e)
        {
            CleanUpData();

            dgv_dataViewerDgv.DataSource = null;


            // Close this form
            Close();
        }
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

            if (Width == screen.WorkingArea.Width && Height == screen.WorkingArea.Height)
            {
                Width = Values.Constants.minFormWidth;
                Height = Values.Constants.minFormHeight;
                WindowState = FormWindowState.Normal;
                Left = frmData.FrmX;
                Top = frmData.FrmY;
            }
            else
            {
                frmData.FrmX = Left;
                frmData.FrmY = Top;
                Left = screen.WorkingArea.Left;
                Top = screen.WorkingArea.Top;
                Width = screen.WorkingArea.Width;
                Height = screen.WorkingArea.Height;
            }
        }
        #endregion








        /// <summary>
        /// Loads the data into the datagridview for viewing
        /// </summary>
        private void LoadData()
        {
            thrd = new System.Threading.Thread(() =>
            {
                DataLoader(ColumnTag);
            });
            thrd.Start();
        }









        /// <summary>
        /// Once the datagridviews source is changed, this event will hide the loading screen and present the 
        /// datagridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_dataViewerDgv_DataSourceChanged(object sender, EventArgs e)
        {
            HideLoadingScreen();
        }











        /// <summary>
        /// Event triggered when the user clicks the export evenet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ShowLoadingScreen("Exporting Data...");
                CleanUpData();
                ExportUtils.DataLoaded = false;
                Exporter.ExportProcessCompleted = false;
                tmr_ExportTimer.Start();

                Thread exportThread = new Thread(() => {
                    GatherDataTable();
                });
                exportThread.IsBackground = true;
                exportThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }







        /// <summary>
        /// Get rid of data stored in memory when not needed.
        /// </summary>
        private void CleanUpData()
        {
            if(ExportUtils.Data != null)
            {
                ExportUtils.Data.Rows.Clear();
                ExportUtils.Data = null;
                GC.Collect();
            }

        }





        /// <summary>
        /// Open teh save as dialog box and allow the user to save the data to excel to the location of their choosing.
        /// </summary>
        private void OpenSaveAsDialog()
        {
            // Exporting to excel
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel | *.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thrd = new Thread(() => {
                        Exporter.ExportData(ExportUtils.Data, new ExcelFile(sfd.FileName, true));
                    });
                    thrd.Start();
                }
                else
                {
                    tblpnl_loadingScreen.Visible = false;
                    dgv_dataViewerDgv.BringToFront();
                }
            }
        }







        /// <summary>
        /// Gather the data from the datagridview and store it in a datatable.
        /// </summary>
        private void GatherDataTable()
        {
            try
            {
                ExportUtils.Data = (DataTable)dgv_dataViewerDgv.DataSource;
                ExportUtils.DataLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //dt.Rows.Clear();
                //dt = null;
                GC.Collect();
            }
        }







        /// <summary>
        /// Timer ticks until the handle is created. Once the handle is created, the data load
        /// pricess will be started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_waitTimer_Tick(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                if(!DataViewerUtils.DataLoadProcessStarted)
                {
                    DataViewerUtils.DataLoadProcessStarted = true;
                    LoadData();
                }

                if(DataViewerUtils.DataLoaded)
                {
                    DataViewerUtils.DataLoaded = false;
                    tmr_waitTimer.Stop();
                    dgv_dataViewerDgv.DataSource = DataViewerUtils.Data;
                    CleanUpData();
                    ms_topPanelMenuStrip.Enabled = true;
                }
            }
        }






        /// <summary>
        /// While the data is being exported to excel. This time will tick waiting for the data to be loaded into a datatable.
        /// The timer will also check when the export process has completed and the data has been saved to the desired location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_ExportTimer_Tick(object sender, EventArgs e)
        {
            if(ExportUtils.DataLoaded)
            {
                ExportUtils.DataLoaded = false;
                OpenSaveAsDialog();
            }


            if(Exporter.ExportProcessCompleted)
            {
                Exporter.ExportProcessCompleted = false;
                tmr_ExportTimer.Stop();
                HideLoadingScreen();
            }
        }






        /// <summary>
        /// Hide the loading screen and present the datagridview
        /// </summary>
        private void HideLoadingScreen()
        {
            tblpnl_loadingScreen.Visible = false;
            pnl_datagridview.BringToFront();
            ms_topPanelMenuStrip.Enabled = true;
        }




        /// <summary>
        /// Show the loading screen while a load process is occuring.
        /// </summary>
        /// <param name="message"></param>
        private void ShowLoadingScreen(string message)
        {
            cpb_loadingScreenCircProgBar.Text = message;
            tblpnl_loadingScreen.Visible = true;
            pnl_datagridview.SendToBack();
            ms_topPanelMenuStrip.Enabled = false;
        }
    }
}
