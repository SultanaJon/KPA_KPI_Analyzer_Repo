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
    public partial class CorrelationConfigurationWindow : Form
    {
        public CorrelationConfigurationWindow()
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
        private void btn_Close_Click(object sender, EventArgs e) => Close();
        #endregion




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxGroupBox_OnChange(object sender, EventArgs e)
        {

            Bunifu.Framework.UI.BunifuCheckbox chkBox = (Bunifu.Framework.UI.BunifuCheckbox)sender;
            int tag = int.Parse(chkBox.Tag.ToString());

            switch(tag)
            {
                case 0:
                    if (chkdBox_DateRanges.Checked)
                    {
                        groupBox_dateRange.Enabled = true;
                    }
                    else
                    {
                        DisableDateRangeGroupBox();
                    }
                    break;
                case 1:
                    if(chkdBox_AddFeatGroupBox.Checked)
                    {
                        groupBox_Variables.Enabled = true;
                    }
                    else
                    {
                        DisableAddFeatureGroupBox();
                    }
                    break;
            }
        }



        /// <summary>
        /// 
        /// </summary>
        private void DisableDateRangeGroupBox()
        {
            chkBox_PrDateRange.Enabled = false;
            chkBox_PoDateRange.Enabled = false;
            UpdateCorrelationStart();
        }



        /// <summary>
        /// 
        /// </summary>
        private void DisableAddFeatureGroupBox()
        {
            chkdListBox_addFeatures.Enabled = false;
            UpdateCorrelationStart();
        }



        /// <summary>
        /// Checks whether the user has chosen date ranges or additional feature to start a correlation run.
        /// If the user has not the program will not enable the start correlation button. There are also additional
        /// checks to make sure the date ranges are the correct condition for operating use and items within variable
        /// and additional features are checked.
        /// </summary>
        private void UpdateCorrelationStart()
        {

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorrelationConfigurationWindow_Load(object sender, EventArgs e)
        {
            CheckAllVariables();
            CheckAllAddFeatures();
        }



        

        /// <summary>
        /// Sets all the variables items to a checked state so the user can uncheck what they dont want at runtime.
        /// </summary>
        private void CheckAllVariables()
        {
            for(int i = 0; i < chkdListBox_variables.Items.Count; ++i)
            {
                chkdListBox_variables.SetItemChecked(i, true);
            }
        }




        /// <summary>
        /// Sets all the additional features to a checked state so the user can uncheck what they dont want at runtime.
        /// </summary>
        private void CheckAllAddFeatures()
        {
            for(int i = 0; i < chkdListBox_addFeatures.Items.Count; ++i)
            {
                chkdListBox_addFeatures.SetItemChecked(i, true);
            }
        }

        private void btn_StartCorrelation_Click(object sender, EventArgs e)
        {
            using (Correlation.CorrelationAnalysisWindow wind = new CorrelationAnalysisWindow())
            {
                wind.ShowDialog();
            }
        }
    }
}
