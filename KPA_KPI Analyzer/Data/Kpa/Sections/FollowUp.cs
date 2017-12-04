using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.FollowUp;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections
{
    public class FollowUp : ILoadable
    {
        public ConfirmedVsPlan confirmedVsPlan = new ConfirmedVsPlan();
        public ConfirrmedForUpcomingDeliveries confirmedForUpcomingDeliveries = new ConfirrmedForUpcomingDeliveries();
        public DueTodayOrLateToConfrimed dueTodayOrLateToConfirmed = new DueTodayOrLateToConfrimed();


        /// <summary>
        /// Default Constructor
        /// </summary>
        public FollowUp() { }




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
