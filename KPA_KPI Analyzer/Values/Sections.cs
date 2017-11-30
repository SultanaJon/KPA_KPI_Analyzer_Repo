namespace KPA_KPI_Analyzer.Values
{
    public static class Sections
    {
        /// <summary>
        /// Index values of the sections contained within KPAs
        /// </summary>
        public enum KpaSection
        {
            Plan,
            Purch,
            PurchSub,
            PurchTotal,
            FollowUp,
            HotJobs,
            ExcessStock_Stock,
            ExcessStock_OpenOrders,
            CurrPlanActual
        }


        /// <summary>
        /// Array of the names of KPA sections
        /// </summary>
        public static string[] kpaSections = {
            "Plan",
            "Purch",
            "Purch Sub",
            "Purch Total",
            "Follow Up",
            "Hot Jobs",
            "Excess Stock - Stock",
            "Excess Stock - Open Orders",
            "Current Plan vs Actual"
        };


        /// <summary>
        /// Index values of the sections contained within KPAs
        /// </summary>
        public enum KpiSection
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


        /// <summary>
        /// Array of the names of KPI sections
        /// </summary>
        public static string[] kpiections =
        {
            "Plan",
            "Purch",
            "Follow Up",
            "Plan",
            "Purch",
            "Purch Sub",
            "Purch Total",
            "Purch Plan",
            "Other",
        };
    }
}
