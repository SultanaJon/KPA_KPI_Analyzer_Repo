using System.Collections.Generic;

namespace Reporting.Overall
{
    public interface ITemplateTwo
    {
        double Average { get; set; }
        int TotalRecords { get; set; }
        int LessthanNegThreeWeeks { get; set; }
        int GreaterThanEqualToNegThreeWeeks { get; set; }
        int GreaterThanEqualToNegTwoWeeks { get; set; }
        int GreaterThanEqualNegOneWeek { get; set; }
        int ZeroWeeks { get; set; }
        int LessThanEqualToOneWeek { get; set; }
        int LessThanEqualToTwoWeeks { get; set; }
        int LessThanEqualToThreeWeeks { get; set; }
        int GreaterThanThreeWeeks { get; set; }



        /// <summary>
        /// Method to return the template data of the function
        /// </summary>
        /// <returns></returns>
        List<string> GetTemplateData();
    }
}
