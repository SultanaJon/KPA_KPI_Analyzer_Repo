using KPA_KPI_Analyzer.Values;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class DataViewer : Form
    {
        private FormData frmData = new FormData();


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





        /// <summary>
        /// The data that was retrieved from the database
        /// </summary>
        public DataTable Data { get; set; }

        


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






        /// <summary>
        /// This form prevents flickering of the UI when it repaints.
        /// </summary>
        /// <remarks>
        ///     06/25/2017 - Created
        /// </remarks>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                //handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
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
        private void btn_Close_Click(object sender, EventArgs e)
        {
            dgv_dataViewerDgv.DataSource = null;
            Data.Rows.Clear();
            Data = null;
            dgv_dataViewerDgv.Rows.Clear();
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
        public void LoadData()
        {
            dgv_dataViewerDgv.DataSource = Data;
            dgv_dataViewerDgv.Refresh();
        }
    }
}
