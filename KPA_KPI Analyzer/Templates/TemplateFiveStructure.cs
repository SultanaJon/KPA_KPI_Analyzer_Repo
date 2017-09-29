﻿namespace KPA_KPI_Analyzer.Templates
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
