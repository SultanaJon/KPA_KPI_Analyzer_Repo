using System.Collections.Generic;

namespace Reporting.Overall
{
    public interface ITemplateFour
    {
        double Average { get; set; }
        int TotalRecords { get; set; }
        int LessThanEqualToZeroDays { get; set; }
        int OneToThreeDays { get; set; }
        int FourToSevenDays { get; set; }
        int EightToFourteenDays { get; set; }
        int FifteenToTwentyOneDays { get; set; }
        int TwentyTwoToTwentyEightDays { get; set; }
        int TwentyNineToThirtyFiveDays { get; set; }
        int ThirtySixtoFourtyTwoDays { get; set; }
        int FourtyThreeToFourtyNineDays { get; set; }
        int FiftyToFiftySixDays { get; set; }
        int FiftySevenPlusDays { get; set; }



        /// <summary>
        /// Method to return the template data of the function
        /// </summary>
        /// <returns></returns>
        List<string> GetTemplateData();
    }
}
