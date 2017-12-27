using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    public class ReportingCategories
    {
        public static string[][] kpaReportingCategories =
        {
            // Plan
            new string[] { "PRs Aging (Not Released)", "Material Due" },
            // Purch
            new string[] { "PRs Aging (Released)", "PO First Release", "PO Prev Release", "No Confirmations" },
            // Purch Sub
            new string[] { "PR Release to PO Release", "PO Creation to Confirmation Entry" },
            // Purch Total
            new string[] { "PR Release to Confirmation Entry" },
            // Follow Up
            new string[] { "Confirmed Date vs Plan Date", "Confirmed Date for Upcoming Deliveries", "Due Today or Late to Confirmed" },
            // Hot Jobs
            new string[] { "PRs (Not on PO)", "No Confirmations", "Late to Confirmed" },
            // Excess Stock - Stock
            new string[] { "PRs Aging (Not Released)", "PRs Aging (Released)", "PO Creation Thru Delivery" },
            // Excess Stock - Open Orders
            new string[] { "PRs Aging (Not Released)", "PRs Aging (Released)", "PO Creation Thru Delivery" },
            // Current Plan vs Actual
            new string[] { "Current Plan Date vs Current Confirmation Date", "Current Plan Date vs Current Confirmation Date For Hot Jobs" },
        };

        public static string[][] kpiReportingCategories =
        {
            // Plan
            new string[] { "Current Plan Date vs PR Plan Date", "(Original Plan Date - PR Fully Released Date) vs Coded Lead-Time", "(Current Plan Date - PR Fully Released Date) vs Coded Lead-Time" },
            // Purch
            new string[] { "Initial Confirmation Date vs PR Plan Date"},
            // Follow Up
            new string[] { "Current Confirmation Date vs Initial Confirmation Date", "Final Confirmation Date vs Final Plan Date", "Receipt Date vs Current Plan Date", "Receipt Date vs Original Confirmation Date", "Receipt Date vs Current Confirmation Date" },
            // Plan II
            new string[] { "Material Due (Original Planned Date)", "Material Due (Final Planned Date)" },
            // Purch II
            new string[] { "PR Fully Released Date vs PO Creation Date", "PO Creation Date vs PO Release Date", "PO Release Date vs PO Confirmation Date" },
            // Purch Sub
            new string[] { "PR Release Date vs PO Release Date", "PO Creation Date vs Confirmation Entry Date" },
            // Purch Total
            new string[] { "PR Release Date to Confirmation Entry Date" },
            // Purch Plan
            new string[] { "PO Release vs PR Delivery Date" },
            // Other
            new string[] { "PRs Created", "PRs Released", "Total Spend", "PR Value vs PO Value", "Hot Job PRs" },
        };
    }
}
