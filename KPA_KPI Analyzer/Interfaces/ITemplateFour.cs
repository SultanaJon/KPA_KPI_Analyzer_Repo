using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Interfaces
{
    interface ITemplateFour
    {
        double Average { get; set; }
        int LessThanZero { get; set; }
        int One_Three { get; set; }
        int Four_Seven { get; set; }
        int Eight_Fourteen { get; set; }
        int Fifteen_TwentyOne { get; set; }
        int TwentyTwo_TwentyEight { get; set; }
        int TwentyNine_ThirtyFive { get; set; }
        int ThirtySix_FourtyTwo { get; set; }
        int FourtyThree_FourtyNine { get; set; }
        int Fifty_FiftySix { get; set; }
        int GreaterThanEqualFiftySeven { get; set; }
        int Total { get; set; }
        double PercentUnconf { get; set; }
        int PercentUnconfTotal { get; set; }





        /// <summary>
        /// Returns a list of string element contained within the tempFour overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within temptFour of overall data. returns null if an error occured and must be handled.</returns>
        List<string> GetData();
    }
}
