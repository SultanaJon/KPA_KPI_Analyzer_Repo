using KPA_KPI_Analyzer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KPA_KPI_Analyzer.PerformanceData.Performances.Kpas;
using KPA_KPI_Analyzer.PerformanceData.Packages;

namespace KPA_KPI_Analyzer.PerformanceData.Performances.Kpas.Sections
{
    public class CurrentPlanVsActual
    {

        // The kpa included in this Section
        private Categories.CurrentPlanVsActual.CurrentPlanVsCurrentConfirmationDate currentPlanVsCurrentConfirmationDate = new Categories.CurrentPlanVsActual.CurrentPlanVsCurrentConfirmationDate();
        private Categories.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDateForHotJobs CurrentPlanVsCurrentConfirmationDateForHotJobs = new Categories.CurrentPlanVsActual.CurrentPlanDateVsCurrentConfirmationDateForHotJobs();



        /// <summary>
        /// Starts the process of loading the Kpas included in this section.
        /// </summary>
        public void LoadKpis()
        {
            try
            {
                // Start loading the Kpas.
                currentPlanVsCurrentConfirmationDate.Load();
                CurrentPlanVsCurrentConfirmationDateForHotJobs.Load();

                // Update the data load progress.
                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Current Plan vs Actual Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
            }
            finally
            {
                GC.Collect();
            }
        }




        /// <summary>
        /// Get the KPA Data.
        /// </summary>
        /// <returns></returns>
        public TemplateTwoPackage GetCurrentPlanVsCurrentConfirmationPackage()
        {
            return currentPlanVsCurrentConfirmationDate;
        }
    }
}
