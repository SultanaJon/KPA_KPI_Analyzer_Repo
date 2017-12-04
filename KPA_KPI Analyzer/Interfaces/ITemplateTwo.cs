using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Interfaces
{
    interface ITemplateTwo
    {
        double Average { get; set; }
        int LessThanMinusThree { get; set; }
        int GreaterThanEqualMinusThree { get; set; }
        int GreaterThanEqualMinusTwo { get; set; }
        int GreaterThanEqualMinusOne { get; set; }
        int ZeroWeeks { get; set; }
        int LessThanEqualOneWeek { get; set; }
        int LessThanEqualTwoWeeks { get; set; }
        int LessThanEqualThreeWeeks { get; set; }
        int GreaterThanThreeWeeks { get; set; }
        int Total { get; set; }



        /// <summary>
        /// Returns a list of string element contained within the temptwo overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within temptwo of overall data. returns null if an error occured and must be handled.</returns>
        List<string> GetData();
    }
}
