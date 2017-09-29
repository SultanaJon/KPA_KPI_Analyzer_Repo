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
            GreaterThanThreeWeeks
        }





        /// <summary>
        /// Clears the data stored in the template object
        /// </summary>
        public void ClearData()
        {
            Average  = 0;
            LessThanMinusThree  = 0;
            GreaterThanEqualMinusThree  = 0;
            GreaterThanEqualMinusTwo = 0;
            GreaterThanEqualMinusOne = 0;
            ZeroWeeks  = 0;
            LessThanEqualOneWeek = 0;
            LessThanEqualTwoWeeks = 0;
            LessThanEqualThreeWeeks = 0;
            GreaterThanThreeWeeks = 0;
            Total  = 0;
        }
    }
}
