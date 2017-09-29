﻿namespace KPA_KPI_Analyzer.Templates
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
