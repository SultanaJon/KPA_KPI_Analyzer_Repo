using System.Collections.Generic;

namespace Reporting.Overall
{
    public interface ITemplateFive
    {
        decimal TotalValue { get; set; }
        int TotalRecords { get; set; }
        decimal GreaterThanEqualToZeroWeeks { get; set; }
        decimal GreaterThanEqualToNegOneWeek { get; set; }
        decimal GreaterThanEqualToNegTwoWeeks { get; set; }
        decimal GreaterThanEqualToNegThreeWeeks { get; set; }
        decimal GreaterThanEqualToNegFourWeeks { get; set; }
        decimal GreaterThanEqualToNegFiveWeeks { get; set; }
        decimal GreaterThanEqualToNegSixWeeks { get; set; }
        decimal GreaterThanEqualToNegSevenWeeks { get; set; }
        decimal GreaterThanEqualToNegEightWeeks { get; set; }
        decimal LessThanNegEightWeeks { get; set; }



        /// <summary>
        /// Method to return the template data of the function
        /// </summary>
        /// <returns></returns>
        List<string> GetTemplateData();
    }
}
