using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Interfaces
{
    interface ITemplateThree
    {
        double Average { get; set; }
        int Minus_TwentyTwo { get; set; }
        int Minus_Fifteen_TwentyOne { get; set; }
        int Minus_Eight_Fourteen { get; set; }
        int Minus_One_Seven { get; set; }
        int Zero { get; set; }
        int One_Seven { get; set; }
        int Eight_Fourteen { get; set; }
        int Fifteen_TwentyOne { get; set; }
        int TwentyTwo { get; set; }
        int Total { get; set; }
        double PercentUnconf { get; set; }
        int PercentUnconfTotal { get; set; }







        /// <summary>
        /// Returns a list of string element contained within the tempThree overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within tempThree of overall data. returns null if an error occured and must be handled.</returns>
        List<string> GetData();
    }
}
