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
        /// Clears the data stored in the template object
        /// </summary>
        public void ClearData()
        {
            LessThanZero = 0;
            One_Three = 0;
            Four_Seven = 0;
            Eight_Fourteen = 0;
            Fifteen_TwentyOne = 0;
            TwentyTwo_TwentyEight = 0;
            TwentyTwo_TwentyEight = 0;
            TwentyNinePlus = 0;
            Average = 0;
            Total = 0;
        }
    }
}
