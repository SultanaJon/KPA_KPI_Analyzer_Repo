namespace DataLoader.Templates
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
        public int greaterThanEqualFiftySeven { get; set; }
        public int Total { get; set; }
        public double PercentUnconf { get; set; }
        public int PercentUnconfTotal { get; set; }






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
             greaterThanEqualFiftySeven = 0;
             Total = 0;
             PercentUnconf = 0;
            PercentUnconfTotal = 0;
        }
    }
}
