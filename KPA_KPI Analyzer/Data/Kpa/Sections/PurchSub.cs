using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.PurchSub;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections
{
    public class PurchSub : ILoadable
    {
        public PrReleaseToPoRelease prReleaseToPoRelease = new PrReleaseToPoRelease();
        public PoCreationToConfirmationEntry poCreationToConfirmationEntry = new PoCreationToConfirmationEntry();




        /// <summary>
        /// Default Constructor
        /// </summary>
        public PurchSub() { }




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
