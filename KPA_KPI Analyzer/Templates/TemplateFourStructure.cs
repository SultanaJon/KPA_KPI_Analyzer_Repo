using System;
using System.Collections.Generic;
using System.Windows;

namespace KPA_KPI_Analyzer.Templates
{
    public class TempFour
    {
        public double Average { get; set; }
        public int LessThanZero { get; set; }
        public int One_Three { get; set; }
        public int Four_Seven { get; set; }
        public int Eight_Fourteen { get; set; }
        public int Fifteen_TwentyOne { get; set; }
        public int TwentyTwo_TwentyEight { get; set; }
        public int TwentyNine_ThirtyFive { get; set; }
        public int ThirtySix_FourtyTwo { get; set; }
        public int FourtyThree_FourtyNine { get; set; }
        public int Fifty_FiftySix { get; set; }
        public int GreaterThanEqualFiftySeven { get; set; }
        public int Total { get; set; }
        public double PercentUnconf { get; set; }
        public int PercentUnconfTotal { get; set; }





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
                temp.Add(Average.ToString());
                temp.Add(LessThanZero.ToString());
                temp.Add(One_Three.ToString());
                temp.Add(Four_Seven.ToString());
                temp.Add(Eight_Fourteen.ToString());
                temp.Add(Fifteen_TwentyOne.ToString());
                temp.Add(TwentyTwo_TwentyEight.ToString());
                temp.Add(TwentyNine_ThirtyFive.ToString());
                temp.Add(ThirtySix_FourtyTwo.ToString());
                temp.Add(FourtyThree_FourtyNine.ToString());
                temp.Add(Fifty_FiftySix.ToString());
                temp.Add(GreaterThanEqualFiftySeven.ToString());
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
             LessThanZero,
             One_Three,
             Four_Seven,
             Eight_Fourteen,
             Fifteen_TwentyOne,
             TwentyTwo_TwentyEight,
             TwentyNine_ThirtyFive,
             ThirtySix_FourtyTwo,
             FourtyThree_FourtyNine,
             Fifty_FiftySix,
             GreaterThanEqualFiftySeven,
             PercentUnconf
        }






        /// <summary>
        /// Clears the data stored in the template object
        /// </summary>
        public void ClearData()
        {
             Average  = 0;
             LessThanZero  = 0;
             One_Three  = 0;
             Four_Seven  = 0;
             Eight_Fourteen  = 0;
             Fifteen_TwentyOne  = 0;
             TwentyTwo_TwentyEight  = 0;
             TwentyNine_ThirtyFive  = 0;
             ThirtySix_FourtyTwo  = 0;
             FourtyThree_FourtyNine  = 0;
             Fifty_FiftySix = 0;
            GreaterThanEqualFiftySeven = 0;
             Total = 0;
             PercentUnconf = 0;
            PercentUnconfTotal = 0;
        }
    }
}
