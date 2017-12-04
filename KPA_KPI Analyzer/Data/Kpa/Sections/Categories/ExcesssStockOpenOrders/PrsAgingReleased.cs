using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Interfaces;

namespace KPA_KPI_Analyzer.Data.Kpa.Sections.Categories.ExcesssStockOpenOrders
{
    public class PrsAgingReleased : ITemplateOne, ICalculatable
    {
        #region ITemplateOne Interface Properties

        public int Total { get; set; }
        public int LessThanZero { get; set; }
        public int One_Three { get; set; }
        public int Four_Seven { get; set; }
        public int Eight_Fourteen { get; set; }
        public int Fifteen_TwentyOne { get; set; }
        public int TwentyTwo_TwentyEight { get; set; }
        public int TwentyNinePlus { get; set; }
        public double Average { get; set; }

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PrsAgingReleased() { }

        #region ITemplateOne Interface Methods

        public List<string> GetData()
        {
            return new List<string>();
        }

        #endregion

        #region ICalculatable Interface Methods

        public void Calculate()
        {

        }

        #endregion
    }
}
