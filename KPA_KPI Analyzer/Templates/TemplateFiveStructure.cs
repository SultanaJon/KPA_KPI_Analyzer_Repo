using System;
using System.Collections.Generic;
using System.Windows;

namespace KPA_KPI_Analyzer.Templates
{
    public class TempFive
    {
        public decimal TotalValue { get; set; }
        public decimal GreaterThanZeroWeeks { get; set; }
        public decimal GreaterThanMinusOneWeeks { get; set; }
        public decimal GreaterThanMinusTwoWeeks { get; set; }
        public decimal GreaterThanMinusThreeWeeks { get; set; }
        public decimal GreaterThanMinusFourWeeks { get; set; }
        public decimal GreaterThanMinusFiveWeeks { get; set; }
        public decimal GreaterThanMinusSixWeeks { get; set; }
        public decimal GreaterThanMinusSevenWeeks { get; set; }
        public decimal GreaterThanMinusEightWeeks { get; set; }
        public decimal LessThanEightWeeks { get; set; }
        public int Total { get; set; }






        /// <summary>
        /// Returns a list of string element contained within the tempFour overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within temptFour of overall data. returns null if an error occured and must be handled.</returns>
        public List<string> GetData()
        {
            List<string> results = null;
            try
            {
                List<string> temp = new List<string>();
                // Add the template elements to tempory storage and return it.
                temp.Add(TotalValue.ToString());
                temp.Add(GreaterThanZeroWeeks.ToString());
                temp.Add(GreaterThanMinusOneWeeks.ToString());
                temp.Add(GreaterThanMinusTwoWeeks.ToString());
                temp.Add(GreaterThanMinusThreeWeeks.ToString());
                temp.Add(GreaterThanMinusFourWeeks.ToString());
                temp.Add(GreaterThanMinusFiveWeeks.ToString());
                temp.Add(GreaterThanMinusSixWeeks.ToString());
                temp.Add(GreaterThanMinusSevenWeeks.ToString());
                temp.Add(GreaterThanMinusEightWeeks.ToString());
                temp.Add(LessThanEightWeeks.ToString());
                temp.Add(Total.ToString());

                results = new List<string>(temp);
                temp.Clear();
                temp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return results;
        }




        /// <summary>
        /// 
        /// </summary>
        public enum DataViews
        {
            Total,
            GreaterThanZeroWeeks,
            GreaterThanMinusOneWeeks,
            GreaterThanMinusTwoWeeks,
            GreaterThanMinusThreeWeeks,
            GreaterThanMinusFourWeeks,
            GreaterThanMinusFiveWeeks,
            GreaterThanMinusSixWeeks,
            GreaterThanMinusSevenWeeks,
            GreaterThanMinusEightWeeks,
            LessThanEightWeeks,
        }


        /// <summary>
        /// Clears the data stored in the template object.
        /// </summary>
        public void ClearData()
        {
            TotalValue = 0;
            GreaterThanZeroWeeks = 0;
            GreaterThanMinusOneWeeks = 0;
            GreaterThanMinusTwoWeeks = 0;
            GreaterThanMinusThreeWeeks = 0;
            GreaterThanMinusFourWeeks = 0;
            GreaterThanMinusFiveWeeks = 0;
            GreaterThanMinusSixWeeks = 0;
            GreaterThanMinusSevenWeeks = 0;
            GreaterThanMinusEightWeeks = 0;
            LessThanEightWeeks = 0;
            Total = 0;
        }
    }
}
