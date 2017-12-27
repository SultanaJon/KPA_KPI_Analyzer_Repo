using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.KeyPerformanceActions.Plan
{
    internal class MaterialDue : KeyPerformanceAction
    {
        public MaterialDue()
        {
            ActionSection = ReportingSections.kpaReportingSections[(int)ReportingSections.KpaReportingSection.Plan];
            ActionCategory = "Material Due";
        }

        public override void CalculateSelectiveReport(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
