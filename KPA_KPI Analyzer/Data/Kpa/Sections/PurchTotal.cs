using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.PurchTotal;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections
{
    public class PurchTotal : ILoadable
    {
        public PrReleaseToConfirmationEntry prReleaseToConfirmationEntry = new PrReleaseToConfirmationEntry();


        /// <summary>
        /// Default Constructor
        /// </summary>
        public PurchTotal() { }




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
