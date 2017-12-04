using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Interfaces
{
    interface ITemplateOne
    {
        int Total { get; set; }
        int LessThanZero { get; set; }
        int One_Three { get; set; }
        int Four_Seven { get; set; }
        int Eight_Fourteen { get; set; }
        int Fifteen_TwentyOne { get; set; }
        int TwentyTwo_TwentyEight { get; set; }
        int TwentyNinePlus { get; set; }
        double Average { get; set; }




        /// <summary>
        /// Returns a list of string element contained within the tempone overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within tempone of overall data. returns null if an error occured and must be handled.</returns>
        List<string> GetData();
    }
}
