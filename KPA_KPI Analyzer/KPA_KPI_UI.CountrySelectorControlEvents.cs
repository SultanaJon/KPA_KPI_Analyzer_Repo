using KPA_KPI_Analyzer.Diagnostics;
using System;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        /// <summary>
        /// Triggered when the user clicks the US switch button. These controls are located
        /// on the SelectedCountry selector page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_usSwitch_Click(object sender, EventArgs e)
        {
            if (btn_usSwitch.Value)
                btn_mxSwitch.Value = false;
            else
                btn_mxSwitch.Value = true;
        }






        /// <summary>
        /// Triggered when the user clicks the MX switch button. These controls are located
        /// on the SelectedCountry selector page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_mxSwitch_Click(object sender, EventArgs e)
        {
            if (btn_mxSwitch.Value)
                btn_usSwitch.Value = false;
            else
                btn_usSwitch.Value = true;
        }





        /// <summary>
        /// Triggered when the user clicks the load data button. Once this button is clicked, the data timer
        /// will be triggered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            if (btn_usSwitch.Value)
            {
                ConfigureToUnitedStates();

                if (AppDirectoryUtils.DataFileExists(AppDirectoryUtils.OverallFiles.US_Overall))
                {
                    // the file exists
                    if (new FileInfo(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFiles.US_Overall]).Length > 0)
                    {
                        DateTime dt = GetLastLoadedUsPrpoReportDate();
                        if (dt == DateTime.Today.Date)
                        {
                            DataReader.LoadOverallData(ref overallData);
                            dt = GetLoadedUsPrpoReportDate();
                            lbl_dashboardDate.Text = dt.ToString("MMMM dd, yyyy");
                            lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                            Values.Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                            InitializeFilterLoadProcess();
                        }
                        else
                        {
                            InitializeDataLoadProcess();
                        }
                    }
                    else
                    {
                        InitializeDataLoadProcess();
                    }
                }
                else // the file does not exist
                {
                    AppDirectoryUtils.CreateFile(AppDirectoryUtils.OverallFiles.US_Overall);
                    InitializeDataLoadProcess();
                }
            }
            else
            {
                ConfigureToMexico();

                if (AppDirectoryUtils.DataFileExists(AppDirectoryUtils.OverallFiles.MX_Overall))
                {
                    // the file exists
                    if (new FileInfo(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFiles.MX_Overall]).Length > 0)
                    {
                        DateTime dt = GetLastLoadedMxPrpoReportDate();
                        if (dt == DateTime.Today.Date)
                        {
                            DataReader.LoadOverallData(ref overallData);
                            dt = GetLoadedMxPrpoReportDate();
                            lbl_dashboardDate.Text = dt.ToString("MMMM dd, yyyy");
                            lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                            Values.Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                            InitializeFilterLoadProcess();
                        }
                        else
                        {
                            InitializeDataLoadProcess();
                        }
                    }
                    else
                    {
                        InitializeDataLoadProcess();
                    }
                }
                else // the file does not exist
                {
                    AppDirectoryUtils.CreateFile(AppDirectoryUtils.OverallFiles.MX_Overall);
                    InitializeDataLoadProcess();
                }
            }
        }






        /// <summary>
        /// Triggered when the user clicks the cancel button located on the SelectedCountry selector panel.
        /// The application will then be put in a cold start state waiting for the user to 
        /// drop some PRPO file(s).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dashboardCancel_Click(object sender, EventArgs e)
        {
            NavigationLocked = true;
            ms_applicaitonMenuStrip.Enabled = false;
            ShowPage(Pages.DragDropDash);
        }
    }
}