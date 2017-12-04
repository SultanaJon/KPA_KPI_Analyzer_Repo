using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.Plan;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections
{
    public class Plan : ILoadable
    {
        public PrsAgingNotReleased prAgingNotReleased = new PrsAgingNotReleased();
        public MaterialDue materialDue = new MaterialDue();




        /// <summary>
        /// Default Constructor
        /// </summary>
        public Plan() { }

        
        
        
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
