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
    public partial class CorrelationConfiguration : Form
    {
        public CorrelationConfiguration()
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
            DialogResult = DialogResult.Cancel;
        }
        #endregion






        /// <summary>
        /// This event will fire when the user clicks the start correlation button.
        /// </summary>
        /// <param name="sender">The start correltion button</param>
        /// <param name="e">Thes click event</param>
        private void btn_startCorrelation_Click(object sender, EventArgs e)
        {
            if(chkBox_PrDateRange.Checked)
            {
                DateTime from = dp_PRFromDate.Value;
                DateTime to = dp_PRToDate.Value;
                if(from > to)
                {
                    MessageBox.Show("You have entered an invalid PR date range.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    CorrelationSettings.FilterByPrDate = true;
                    CorrelationSettings.PrFromDate = from;
                    CorrelationSettings.PrToDate = to;
                }
            }
            else
            {
                CorrelationSettings.FilterByPrDate = false;
            }

            if (chkBox_PoDateRange.Checked)
            {
                DateTime from = dp_POFromDate.Value;
                DateTime to = dp_POToDate.Value;

                if(from > to)
                {
                    MessageBox.Show("You have entered an invalid PO date range.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    CorrelationSettings.FilterbyPoDate = true;
                    CorrelationSettings.PoFromDate = from;
                    CorrelationSettings.PoToDate = to;
                }
            }
            else
            {
                CorrelationSettings.FilterbyPoDate = false;
            }


            // Here we want to hide this window and show the correlation window.
            using (CorrelationTool corrWind = new CorrelationTool())
            {
                Hide();
                if(corrWind.ShowDialog() == DialogResult.Cancel)
                {
                    corrWind.Close();
                    Close();
                }
            }
        }
    }
}
