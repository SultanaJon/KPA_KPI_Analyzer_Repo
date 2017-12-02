using System;
using System.Collections.Generic;
using System.Windows;

namespace KPA_KPI_Analyzer.Templates
{
    public class TempOne
    {
        public int Total { get; set; }
        public int LessThanZero { get; set; }
        public int One_Three { get; set; }
        public int Four_Seven { get; set; }
        public int Eight_Fourteen { get; set; }
        public int Fifteen_TwentyOne { get; set; }
        public int TwentyTwo_TwentyEight { get; set; }
        public int TwentyNinePlus { get; set; }
        public double Average { get; set; }
        public double PercentFavorable { get; set; }



        /// <summary>
        /// Indexer to correspond with the tag number of the buttons in TemplateOne templates
        /// </summary>
        public enum DataViews
        {
            Total,
            LessThanZero,
            One_Three,
            Four_Seven,
            Eight_Fourteen,
            Fifteen_TwentyOne,
            TwentyTwo_TwentyEight,
            TwentyNinePlus
        }




        /// <summary>
        /// Returns a list of string element contained within the tempone overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within tempone of overall data. returns null if an error occured and must be handled.</returns>
        public List<string> GetData()
        {
            List<string> results = null;
            try
            {
                List<string> temp = new List<string>();
                // Add the template elements to tempory storage and return it.
                temp.Add(LessThanZero.ToString());
                temp.Add(One_Three.ToString());
                temp.Add(Four_Seven.ToString());
                temp.Add(Eight_Fourteen.ToString());
                temp.Add(Fifteen_TwentyOne.ToString());
                temp.Add(TwentyTwo_TwentyEight.ToString());
                temp.Add(TwentyNinePlus.ToString());
                temp.Add(Average.ToString());
                temp.Add(Total.ToString());
                temp.Add(PercentFavorable.ToString());

                results = new List<string>(temp);
                temp.Clear();
                temp = null;               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return results;
        }
    }
}
