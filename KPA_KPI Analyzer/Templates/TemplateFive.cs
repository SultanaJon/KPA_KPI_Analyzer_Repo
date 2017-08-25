namespace KPA_KPI_Analyzer.Templates
{
    public class TempFive
    {
        public decimal TotalValue { get; set; }
        public int Zero { get; set; }
        public int LessOneWeek { get; set; }
        public int LessTwoWeeks { get; set; }
        public int LessThreeWeeks { get; set; }
        public int LessFourWeeks { get; set; }
        public int LessFiveWeeks { get; set; }
        public int LessSixWeeks { get; set; }
        public int LessSevenWeeks { get; set; }
        public int LessEightWeeks { get; set; }
        public int LessNinePlusWeeks { get; set; }
        public int Total { get; set; }



        /// <summary>
        /// Clears the data stored in the template object.
        /// </summary>
        public void ClearData()
        {
            TotalValue = 0;
            Zero = 0;
            LessOneWeek = 0;
            LessTwoWeeks = 0;
            LessThreeWeeks = 0;
            LessFourWeeks = 0;
            LessFiveWeeks = 0;
            LessSixWeeks = 0;
            LessSevenWeeks = 0;
            LessEightWeeks = 0;
            LessNinePlusWeeks = 0;
            Total = 0;
        }
    }
}
