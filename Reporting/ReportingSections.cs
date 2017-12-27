using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    public class ReportingSections
    {
        public enum KpaReportingSection
        {
            Plan,
            Purch,
            PurchSub,
            PurchTotal,
            FollowUp,
            HotJobs,
            ExcessStockStock,
            ExcessStockOpenOrders,
            CurrentPlanVsActual
        }


        public enum KpiReportingSection
        {
            Plan,
            Purch,
            FollowUp,
            PlanTwo,
            PurchTwo,
            PurchSub,
            PurchTotal,
            PurchPlan,
            Other
        }



        public static string[] kpaReportingSections =
        {
            "Plan",
            "Purch",
            "Purch Sub",
            "Purch Total",
            "Follow Up",
            "Hot Jobs",
            "Excess Stock - Stock",
            "Excess Stock - Open Orders",
            "Current Plan vs Actual",
        };


        public static string[] kpiReportingSections =
        {
            "Plan",
            "Purch",
            "Follow Up",
            "Plan II",
            "Purch II",
            "Purch Sub",
            "Purch Total",
            "Purch Plan",
            "Other",
        };
    }
}
