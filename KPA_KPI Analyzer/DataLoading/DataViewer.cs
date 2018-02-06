using DataExporter;
using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.DataLoading
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

        #endregion



        #region CONSTRUCTORS
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataViewer()
        {
            InitializeComponent();
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

            tmr_waitTimer.Start();
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
            thrd = new Thread(() =>
            {
                DataLoader(ColumnTag);
            });
            thrd.Start();
        }





        /// <summary>
        /// Orders the columns for viewing in the data viewer.
        /// </summary>
        private void OrderColumns()
        {
            try
            {
                dgv_dataViewerDgv.Columns["Material Group"].DisplayIndex = 0;
                dgv_dataViewerDgv.Columns["Commodity category"].DisplayIndex = 1;
                dgv_dataViewerDgv.Columns["Bid Package"].DisplayIndex = 2;
                dgv_dataViewerDgv.Columns["Material"].DisplayIndex = 3;
                dgv_dataViewerDgv.Columns["Material Description"].DisplayIndex = 4;
                dgv_dataViewerDgv.Columns["Mfr Part Number"].DisplayIndex = 5;
                dgv_dataViewerDgv.Columns["Purch# Group"].DisplayIndex = 6;
                dgv_dataViewerDgv.Columns["Purchase Req#"].DisplayIndex = 7;
                dgv_dataViewerDgv.Columns["Deletion Ind#"].DisplayIndex = 8;
                dgv_dataViewerDgv.Columns["PR Item"].DisplayIndex = 9;
                dgv_dataViewerDgv.Columns["Release status"].DisplayIndex = 10;
                dgv_dataViewerDgv.Columns["Open PR Qty"].DisplayIndex = 11;
                dgv_dataViewerDgv.Columns["Requisn Date"].DisplayIndex = 12;
                dgv_dataViewerDgv.Columns["PR Delivery Date"].DisplayIndex = 13;
                dgv_dataViewerDgv.Columns["PR Fully Rel Date"].DisplayIndex = 14;
                dgv_dataViewerDgv.Columns["WBS Element"].DisplayIndex = 15;
                dgv_dataViewerDgv.Columns["POPurcGroup"].DisplayIndex = 16;
                dgv_dataViewerDgv.Columns["Purchasing Doc#"].DisplayIndex = 17;
                dgv_dataViewerDgv.Columns["Item"].DisplayIndex = 18;
                dgv_dataViewerDgv.Columns["PO Deletion"].DisplayIndex = 19;
                dgv_dataViewerDgv.Columns["PO Doc# Type"].DisplayIndex = 20;
                dgv_dataViewerDgv.Columns["Escaped"].DisplayIndex = 21;
                dgv_dataViewerDgv.Columns["Vendor"].DisplayIndex = 22;
                dgv_dataViewerDgv.Columns["Vendor Description"].DisplayIndex = 23;
                dgv_dataViewerDgv.Columns["PO Qty"].DisplayIndex = 24;
                dgv_dataViewerDgv.Columns["PO Unit"].DisplayIndex = 25;
                dgv_dataViewerDgv.Columns["PO Date"].DisplayIndex = 26;
                dgv_dataViewerDgv.Columns["PO LIne Creat#DT"].DisplayIndex = 27;
                dgv_dataViewerDgv.Columns["PO Line 1st Rel Dt"].DisplayIndex = 28;
                dgv_dataViewerDgv.Columns["GR Posting Date"].DisplayIndex = 29;
                dgv_dataViewerDgv.Columns["PO Sign Date"].DisplayIndex = 30;
                dgv_dataViewerDgv.Columns["Delivery Date"].DisplayIndex = 31;
                dgv_dataViewerDgv.Columns["Rescheduling date"].DisplayIndex = 32;
                dgv_dataViewerDgv.Columns["Latest Conf#Dt"].DisplayIndex = 33;
                dgv_dataViewerDgv.Columns["1st Conf Date"].DisplayIndex = 34;
                dgv_dataViewerDgv.Columns["1st Conf Creation Da"].DisplayIndex = 35;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Column Order Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }








        /// <summary>
        /// Once the datagridviews source is changed, this event will hide the loading screen and present the 
        /// datagridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_dataViewerDgv_DataSourceChanged(object sender, EventArgs e)
        {
            if (dgv_dataViewerDgv.DataSource != null)
            {
                OrderColumns();
            }
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
            Exporter exporter = new Exporter();

            // Exporting to excel
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel | *.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    thrd = new Thread(() => {
                        exporter.ExportData(ExportUtils.Data, new RawDataExcelFile(sfd.FileName, true));
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
        /// Once the user wants to export the data contained within the datagridview, this function
        /// will order the data to the specified column order.
        /// </summary>
        private void OrderDataTable()
        {
            try
            {
                DataViewerUtils.Data.Columns["Material Group"].SetOrdinal(0);
                DataViewerUtils.Data.Columns["Commodity category"].SetOrdinal(1);
                DataViewerUtils.Data.Columns["Bid Package"].SetOrdinal(2);
                DataViewerUtils.Data.Columns["Material"].SetOrdinal(3);
                DataViewerUtils.Data.Columns["Material Description"].SetOrdinal(4);
                DataViewerUtils.Data.Columns["Mfr Part Number"].SetOrdinal(5);
                DataViewerUtils.Data.Columns["Purch# Group"].SetOrdinal(6);
                DataViewerUtils.Data.Columns["Purchase Req#"].SetOrdinal(7);
                DataViewerUtils.Data.Columns["Deletion Ind#"].SetOrdinal(8);
                DataViewerUtils.Data.Columns["PR Item"].SetOrdinal(9);
                DataViewerUtils.Data.Columns["Release status"].SetOrdinal(10);
                DataViewerUtils.Data.Columns["Open PR Qty"].SetOrdinal(11);
                DataViewerUtils.Data.Columns["Requisn Date"].SetOrdinal(12);
                DataViewerUtils.Data.Columns["PR Delivery Date"].SetOrdinal(13);
                DataViewerUtils.Data.Columns["PR Fully Rel Date"].SetOrdinal(14);
                DataViewerUtils.Data.Columns["WBS Element"].SetOrdinal(15);
                DataViewerUtils.Data.Columns["POPurcGroup"].SetOrdinal(16);
                DataViewerUtils.Data.Columns["Purchasing Doc#"].SetOrdinal(17);
                DataViewerUtils.Data.Columns["Item"].SetOrdinal(18);
                DataViewerUtils.Data.Columns["PO Deletion"].SetOrdinal(19);
                DataViewerUtils.Data.Columns["PO Doc# Type"].SetOrdinal(20);
                DataViewerUtils.Data.Columns["Escaped"].SetOrdinal(21);
                DataViewerUtils.Data.Columns["Vendor"].SetOrdinal(22);
                DataViewerUtils.Data.Columns["Vendor Description"].SetOrdinal(23);
                DataViewerUtils.Data.Columns["PO Qty"].SetOrdinal(24);
                DataViewerUtils.Data.Columns["PO Unit"].SetOrdinal(25);
                DataViewerUtils.Data.Columns["PO Date"].SetOrdinal(26);
                DataViewerUtils.Data.Columns["PO LIne Creat#DT"].SetOrdinal(27);
                DataViewerUtils.Data.Columns["PO Line 1st Rel Dt"].SetOrdinal(28);
                DataViewerUtils.Data.Columns["GR Posting Date"].SetOrdinal(29);

                // Delivery Document seems to have been removed from the PRPO report.
                //dgv_dataViewerDgv.Columns["Delivery Document"].DisplayIndex = 30;

                DataViewerUtils.Data.Columns["PO Sign Date"].SetOrdinal(30);
                DataViewerUtils.Data.Columns["Delivery Date"].SetOrdinal(31);
                DataViewerUtils.Data.Columns["Rescheduling date"].SetOrdinal(32);
                DataViewerUtils.Data.Columns["Latest Conf#Dt"].SetOrdinal(33);
                DataViewerUtils.Data.Columns["1st Conf Date"].SetOrdinal(34);
                DataViewerUtils.Data.Columns["1st Conf Creation Da"].SetOrdinal(35);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Column Order Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                OrderDataTable();
                ExportUtils.DataLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
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
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Data Viewer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
