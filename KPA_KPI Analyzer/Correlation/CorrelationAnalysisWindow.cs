using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Correlation
{
    public partial class CorrelationAnalysisWindow : Form
    {
        FormData frmData = new FormData();

        public CorrelationAnalysisWindow()
        {
            InitializeComponent();
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
        private void btn_Close_Click(object sender, EventArgs e) => Close();
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
                Width = Values.Constants.minFormWidth;
                Height = Values.Constants.minFormHeight;
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
        }
        #endregion

        private void CorrelationAnalysisWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bunifu.DataViz.Canvas canvas = new Bunifu.DataViz.Canvas();
            Bunifu.DataViz.DataPoint dp = new Bunifu.DataViz.DataPoint(Bunifu.DataViz.BunifuDataViz._type.Bunifu_scatter);
            Random r = new Random();


            for (int i = 0; i <= 30; ++i)
            {
                dp.addxy(r.Next(0, 100).ToString(), r.Next(0, 100).ToString());
            }


            canvas.addData(dp);
            dataViz_scatterPlot.Render(canvas);
        }
    }
}
