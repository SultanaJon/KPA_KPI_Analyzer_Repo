using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.ExcesssStockOpenOrders;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections
{
    public class ExcessStockOpenOrders : ILoadable
    {
        public PrsAgingNotReleased prAgingNotReleased = new PrsAgingNotReleased();
        public PrsAgingReleased prAgingReleased = new PrsAgingReleased();
        public PoCreationThruDelivery poCreationThruDelivery = new PoCreationThruDelivery();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ExcessStockOpenOrders() { }




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
