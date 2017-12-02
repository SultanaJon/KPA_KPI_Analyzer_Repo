using System;
using System.Collections.Generic;
using System.Windows;

namespace KPA_KPI_Analyzer.Templates
{
    public class TempTwo
    {
        public double Average { get; set; }
        public int LessThanMinusThree { get; set; }
        public int GreaterThanEqualMinusThree { get; set; }
        public int GreaterThanEqualMinusTwo { get; set; }
        public int GreaterThanEqualMinusOne { get; set; }
        public int ZeroWeeks { get; set; }
        public int LessThanEqualOneWeek { get; set; }
        public int LessThanEqualTwoWeeks { get; set; }
        public int LessThanEqualThreeWeeks { get; set; }
        public int GreaterThanThreeWeeks { get; set; }
        public int Total { get; set; }
        public double PercentFavorable { get; set; }



        /// <summary>
        /// Returns a list of string element contained within the temptwo overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within temptwo of overall data. returns null if an error occured and must be handled.</returns>
        public List<string> GetData()
        {
            List<string> results = null;
            try
            {
                List<string> temp = new List<string>();
                // Add the template elements to tempory storage and return it.
                temp.Add(Average.ToString());
                temp.Add(LessThanMinusThree.ToString());
                temp.Add(GreaterThanEqualMinusThree.ToString());
                temp.Add(GreaterThanEqualMinusTwo.ToString());
                temp.Add(GreaterThanEqualMinusOne.ToString());
                temp.Add(ZeroWeeks.ToString());
                temp.Add(LessThanEqualOneWeek.ToString());
                temp.Add(LessThanEqualTwoWeeks.ToString());
                temp.Add(LessThanEqualThreeWeeks.ToString());
                temp.Add(GreaterThanThreeWeeks.ToString());
                temp.Add(Total.ToString());
                temp.Add(PercentFavorable.ToString());

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
        /// Indexer to correspond with the tag number of the buttons in Template two templates
        /// </summary>
        public enum DataViews
        {
            Total,
            LessThanMinusThree,
            GreaterThanEqualMinusThree,
            GreaterThanEqualMinusTwo,
            GreaterThanEqualMinusOne,
            ZeroWeeks,
            LessThanEqualOneWeek,
            LessThanEqualTwoWeeks,
            LessThanEqualThreeWeeks,
            GreaterThanThreeWeeks,
        }
    }
}
