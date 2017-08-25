namespace KPA_KPI_Analyzer.Templates
{
    public class TempTwo
    {
        public double Average { get; set; }
        public int LessThanMinusFourWeeks { get; set; }
        public int LessThanMinusThreeWeeks { get; set; }
        public int LessThanMinusTwoWeeks { get; set; }
        public int LessThanMinusOneWeeks { get; set; }
        public int ZeroWeeks { get; set; }
        public int OneWeek { get; set; }
        public int TwoWeeks { get; set; }
        public int ThreeWeeks { get; set; }
        public int FourWeeksPlus { get; set; }
        public int Total { get; set; }






        /// <summary>
        /// Clears the data stored in the template object
        /// </summary>
        public void ClearData()
        {
            Average  = 0;
            LessThanMinusFourWeeks  = 0;
            LessThanMinusThreeWeeks  = 0;
            LessThanMinusTwoWeeks  = 0;
            LessThanMinusOneWeeks  = 0;
            ZeroWeeks  = 0;
            OneWeek  = 0;
            TwoWeeks  = 0;
            ThreeWeeks  = 0;
            FourWeeksPlus  = 0;
            Total  = 0;
        }
    }
}
