using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Interfaces
{
    interface ITemplateFive
    {
        decimal TotalValue { get; set; }
        decimal GreaterThanZeroWeeks { get; set; }
        decimal GreaterThanMinusOneWeeks { get; set; }
        decimal GreaterThanMinusTwoWeeks { get; set; }
        decimal GreaterThanMinusThreeWeeks { get; set; }
        decimal GreaterThanMinusFourWeeks { get; set; }
        decimal GreaterThanMinusFiveWeeks { get; set; }
        decimal GreaterThanMinusSixWeeks { get; set; }
        decimal GreaterThanMinusSevenWeeks { get; set; }
        decimal GreaterThanMinusEightWeeks { get; set; }
        decimal LessThanEightWeeks { get; set; }
        int Total { get; set; }




        /// <summary>
        /// Returns a list of string element contained within the tempFour overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within temptFour of overall data. returns null if an error occured and must be handled.</returns>
        List<string> GetData();
    }
}
