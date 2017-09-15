using DataImporter.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        /// <summary>
        /// Triggered when the user clicks the US switch button. These controls are located
        /// on the Overall.SelectedCountry selector page.
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
        /// on the Overall.SelectedCountry selector page.
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
                Overall.SelectedCountry = AccessInfo.MainTables.US_PRPO;
            }
            else
            {
                Overall.SelectedCountry = AccessInfo.MainTables.MX_PRPO;
            }



            overallData = new Overall();
            PRPO_DB_Utils.DataLoadProcessStarted = false;
            PRPO_DB_Utils.DataLoaded = false;
            PRPO_DB_Utils.KPITablesLoaded = false;
            PRPO_DB_Utils.CompletedDataLoads = 0;
            PRPO_DB_Utils.ScheduledDataLoads = 0;
<<<<<<< HEAD
            RenewDataLoadTimer();
=======
            PRPO_DB_Utils.CompletedKpaDataLoads = 0;
            PRPO_DB_Utils.CompletedKpiDataLoads = 0;
            CreateThreads();
            DataLoaderTimer.Tick -= DataLoaderTimer_Tick;
            DataLoaderTimer.Tick += DataLoaderTimer_Tick;
>>>>>>> parent of bee2fda... Revert "- This was a revert"
            DataLoaderTimer.Start();
        }






        /// <summary>
        /// Triggered when the user clicks the cancel button located on the Overall.SelectedCountry selector panel.
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