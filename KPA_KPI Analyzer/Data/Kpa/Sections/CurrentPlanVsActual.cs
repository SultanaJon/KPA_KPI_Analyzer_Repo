using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.CurrentPlanVsActual;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections
{
    public class CurrentPlanVsActual :  ILoadable
    {
        public CurrentPlanVsCurrentConfirmed currentPlanVsCurrentConfirmed = new CurrentPlanVsCurrentConfirmed();
        public CurrentPlanVsCurrentConfirmedHotJobs currentPlanVsCurrentConfirmedHotJobs = new CurrentPlanVsCurrentConfirmedHotJobs();


        /// <summary>
        /// Default Constructor
        /// </summary>
        public CurrentPlanVsActual() { }



        #region ILoadable Interface Methods

        /// <summary>
        /// 
        /// </summary>
        public void LoadData()
        {

        }

        #endregion
    }
}
