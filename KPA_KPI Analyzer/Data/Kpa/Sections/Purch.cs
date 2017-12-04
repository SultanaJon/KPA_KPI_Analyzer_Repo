using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;
using KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.Purch;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections
{
    public class Purch : ILoadable
    {
        public PrsAgingReleased prAgingReleased = new PrsAgingReleased();
        public PoFirstRelease poFirstRelease = new PoFirstRelease();
        public PoPreviousRelease poPreviousRelease = new PoPreviousRelease();
        public NoConfirmations noConfirmations = new NoConfirmations();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Purch() { }




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
