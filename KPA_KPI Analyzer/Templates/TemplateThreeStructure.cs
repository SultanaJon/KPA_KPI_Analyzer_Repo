using System;
using System.Collections.Generic;
using System.Windows;

namespace KPA_KPI_Analyzer.Templates
{
    public class TempThree
    {
        public double Average { get; set; }
        public int Minus_TwentyTwo { get; set; }
        public int Minus_Fifteen_TwentyOne { get; set; }
        public int Minus_Eight_Fourteen { get; set; }
        public int Minus_One_Seven { get; set; }
        public int Zero { get; set; }
        public int One_Seven { get; set; }
        public int Eight_Fourteen { get; set; }
        public int Fifteen_TwentyOne { get; set; }
        public int TwentyTwo { get; set; }
        public int Total { get; set; }
        public double PercentUnconf { get; set; }
        public int PercentUnconfTotal { get; set; }







        /// <summary>
        /// Returns a list of string element contained within the tempThree overall data.
        /// </summary>
        /// <returns>Returns the list of string values contained within tempThree of overall data. returns null if an error occured and must be handled.</returns>
        public List<string> GetData()
        {
            List<string> results = null;
            try
            {
                List<string> temp = new List<string>();
                // Add the template elements to tempory storage and return it.
                temp.Add(Average.ToString());
                temp.Add(Minus_TwentyTwo.ToString());
                temp.Add(Minus_Fifteen_TwentyOne.ToString());
                temp.Add(Minus_Eight_Fourteen.ToString());
                temp.Add(Minus_One_Seven.ToString());
                temp.Add(Zero.ToString());
                temp.Add(One_Seven.ToString());
                temp.Add(Eight_Fourteen.ToString());
                temp.Add(Fifteen_TwentyOne.ToString());
                temp.Add(TwentyTwo.ToString());
                temp.Add(Total.ToString());
                temp.Add(PercentUnconf.ToString());

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
            Minus_TwentyTwo,
            Minus_Fifteen_TwentyOne,
            Minus_Eight_Fourteen,
            Minus_One_Seven,
            Zero,
            One_Seven,
            Eight_Fourteen,
            Fifteen_TwentyOne,
            TwentyTwo,
            PercentUnconf
        }






        /// <summary>
        /// Clears the data stored in the template object.
        /// </summary>
        public void ClearData()
        {
            Average  = 0;
            Minus_TwentyTwo  = 0;
            Minus_Fifteen_TwentyOne  = 0;
            Minus_Eight_Fourteen  = 0;
            Minus_One_Seven  = 0;
            Zero  = 0;
            One_Seven  = 0;
            Eight_Fourteen  = 0;
            Fifteen_TwentyOne  = 0;
            TwentyTwo  = 0;
            Total  = 0;
            PercentUnconf = 0;
            PercentUnconfTotal = 0;
         }
    }
}
