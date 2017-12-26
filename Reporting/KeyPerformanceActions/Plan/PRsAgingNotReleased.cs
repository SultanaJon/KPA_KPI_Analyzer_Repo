using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessDatabaseLibrary;

namespace Reporting.KeyPerformanceActions.Plan
{
    internal class PRsAgingNotReleased : KeyPerformanceAction
    {
        public PRsAgingNotReleased()
        {
            ActionSection = ReportingSections.reportingSections[(int)ReportingSections.ReportingSection.Plan];
            ActionCategory = ReportingCategories.reportingCategories[(int)ReportingCategories.ReportingCategory.PRsAgingNotReleased];
        }


        public override void CalculateSelectiveReport(string fitler)
        {
            
        }
    }
}
