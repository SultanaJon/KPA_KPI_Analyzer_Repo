using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting
{
    public class ReportingSections
    {
        public enum ReportingSection
        {
            Plan,
            Purch,
            PurchSub,
            PurchTotal,
            FollowUp,
            ExcessStockStock,
            ExcessStockOpenOrders,
            CurrentPlanVsActual,
            Plantwo,
            PurchTwo,
            PurchPlan,
            Other
        }


        public static string[] reportingSections =
        {
            "Plan",
            "Purch",
            "Purch Sub",
            "Purch Total",
            "Follow Up",
            "Excess Stock - Stock",
            "Excess Stock - Open Orders",
            "Current Plan vs Actual",
            "Plan II",
            "Purch II",
            "Purch Plan",
            "Other",
        };
    }
}
