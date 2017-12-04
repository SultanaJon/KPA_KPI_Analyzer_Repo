using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.HotJobs;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections
{
    public class HotJobs : ILoadable
    {
        public PrsNotOnPo prsNotOnPo = new PrsNotOnPo();
        public NoConfirmations noConfirmations = new NoConfirmations();
        public LateToConfirmed lateToConfirmed = new LateToConfirmed();




        /// <summary>
        /// Default Constructor
        /// </summary>
        public HotJobs() { }




        #region ILoadable Interface Methods

        /// <summary>
        /// Starts the calculations for this KPA
        /// </summary>
        public void LoadData()
        {

        }

        #endregion
    }
}
