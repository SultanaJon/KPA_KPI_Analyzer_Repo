using DataImporter.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Windows.Forms;
using KPA_KPI_Analyzer.Diagnostics;
using System.IO;
using KPA_KPI_Analyzer.FilterFeeature;

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
                lbl_Country.Text = "United States";
                Values.Globals.SelectedCountry = AccessInfo.MainTables.US_PRPO;

                if (AppDirectoryUtils.DataFileExists(AppDirectoryUtils.OverallFiles.US_Overall))
                {
                    // the file exists
                    if (new FileInfo(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFiles.US_Overall]).Length > 0)
                    {
                        DataReader.LoadOverallData(ref overallData);
                        FilterUtils.FiltersLoaded = false;
                        FilterUtils.FilterLoadProcessStarted = false;
                        FiltersTimer.Start();
                    }
                    else // the file might be empty
                    {
                        InitializeDataLoadProcess();
                        RenewDataLoadTimer();
                        DataLoaderTimer.Start();
                    }
                }
                else
                {
                    InitializeDataLoadProcess();
                    RenewDataLoadTimer();
                    DataLoaderTimer.Start();
                }
            }
            else
            {
                lbl_Country.Text = "Mexico";
                Values.Globals.SelectedCountry = AccessInfo.MainTables.MX_PRPO;

                if (AppDirectoryUtils.DataFileExists(AppDirectoryUtils.OverallFiles.MX_Overall))
                {
                    // the file exists
                    if (new FileInfo(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFiles.MX_Overall]).Length > 0)
                    {
                        DataReader.LoadOverallData(ref overallData);
                        FilterUtils.FiltersLoaded = false;
                        FilterUtils.FilterLoadProcessStarted = false;
                        FiltersTimer.Start();
                    }
                    else // the file might be empty
                    {
                        InitializeDataLoadProcess();
                        RenewDataLoadTimer();
                        DataLoaderTimer.Start();
                    }
                }
                else
                {
                    InitializeDataLoadProcess();
                    RenewDataLoadTimer();
                    DataLoaderTimer.Start();
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
            ShowPage(Pages.DragDropDash);
        }
    }
}