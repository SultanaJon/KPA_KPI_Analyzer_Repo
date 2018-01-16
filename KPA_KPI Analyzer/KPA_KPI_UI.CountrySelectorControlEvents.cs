using ApplicationIOLibarary.ApplicationFiles;
using KPA_KPI_Analyzer.Values;
using Reporting;
using Reporting.Reports;
using System;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer
{
    public partial class KPA_KPI_UI : Form
    {
        #region EVENTS

        /// <summary>
        /// Triggered when the user clicks the US switch button. These controls are located
        /// on the SelectedCountry selector page.
        /// </summary>
        /// <param name="sender">The United States Switch</param>
        /// <param name="e">The click event</param>
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
        /// <param name="sender">The Mexico switch</param>
        /// <param name="e">The click event</param>
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
        /// <param name="sender">The load data button</param>
        /// <param name="e">The click event</param>
        private void btn_LoadData_Click(object sender, EventArgs e)
        {
            if (btn_usSwitch.Value)
            {
                ConfigureToUnitedStates();

                if (FileUtils.DataFileExists(OverallFile.US_KPA_Overall) || FileUtils.DataFileExists(OverallFile.US_KPI_Overall))
                {
                    // the file exists
                    if (new FileInfo(FileUtils.overallFiles[(int)OverallFile.US_KPA_Overall]).Length > 0 && new FileInfo(FileUtils.overallFiles[(int)OverallFile.US_KPI_Overall]).Length > 0)
                    {
                        DateTime dt = GetLastLoadedUsPrpoReportDate();
                        if (dt == DateTime.Today.Date)
                        {
                            // Load the KPA Overall data from local file
                            (reports[ReportingType.KpaOverall] as KpaOverallReport).Load();

                            // Load the KPA Overall data from local file
                            (reports[ReportingType.KpiOverall] as KpiOverallReport).Load();


                            dt = GetLoadedUsPrpoReportDate();
                            lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                            Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                            InitializeFilterLoadProcess();
                        }
                        else
                        {
                            BeginDataLoadProcess();
                        }
                    }
                    else
                    {
                        BeginDataLoadProcess();
                    }
                }
                else // the file does not exist
                {
                    if (!FileUtils.DataFileExists(OverallFile.US_KPA_Overall))
                    {
                        FileUtils.CreateFile(OverallFile.US_KPA_Overall);
                    }

                    if (!FileUtils.DataFileExists(OverallFile.US_KPI_Overall))
                    {
                        FileUtils.CreateFile(OverallFile.US_KPI_Overall);
                    }

                    BeginDataLoadProcess();
                }
            }
            else
            {
                ConfigureToMexico();

                if (FileUtils.DataFileExists(OverallFile.MX_KPA_Overall) && FileUtils.DataFileExists(OverallFile.MX_KPI_Overall))
                {
                    // the file exists
                    if (new FileInfo(FileUtils.overallFiles[(int)OverallFile.MX_KPA_Overall]).Length > 0 && new FileInfo(FileUtils.overallFiles[(int)OverallFile.MX_KPI_Overall]).Length > 0)
                    {
                        DateTime dt = GetLastLoadedMxPrpoReportDate();
                        if (dt == DateTime.Today.Date)
                        {
                            // Load the KPA Overall data from local file
                            (reports[ReportingType.KpaOverall] as KpaOverallReport).Load();

                            // Load the KPA Overall data from local file
                            (reports[ReportingType.KpiOverall] as KpiOverallReport).Load();

                            dt = GetLoadedMxPrpoReportDate();
                            lbl_topPanelNavPrpoDate.Text = dt.ToString("MMMM dd, yyyy");
                            Values.Globals.PrpoGenerationDate = lbl_topPanelNavPrpoDate.Text;
                            InitializeFilterLoadProcess();
                        }
                        else
                        {
                            BeginDataLoadProcess();
                        }
                    }
                    else
                    {
                        BeginDataLoadProcess();
                    }
                }
                else // the file does not exist
                {
                    if (!FileUtils.DataFileExists(OverallFile.MX_KPA_Overall))
                    {
                        FileUtils.CreateFile(OverallFile.MX_KPA_Overall);
                    }

                    if (!FileUtils.DataFileExists(OverallFile.MX_KPI_Overall))
                    {
                        FileUtils.CreateFile(OverallFile.MX_KPI_Overall);
                    }


                    BeginDataLoadProcess();
                }
            }
        }



        /// <summary>
        /// Triggered when the user clicks the cancel button located on the SelectedCountry selector panel.
        /// The application will then be put in a cold start state waiting for the user to 
        /// drop some PRPO file(s).
        /// </summary>
        /// <param name="sender">The cancel button.</param>
        /// <param name="e">The click event</param>
        private void btn_dashboardCancel_Click(object sender, EventArgs e)
        {
            NavigationLocked = true;
            ms_applicaitonMenuStrip.Enabled = false;
            ShowPage(Pages.DragDropDash);
        }

        #endregion
    }
}