namespace KPA_KPI_Analyzer.Navigation
{
    public enum Functionality : byte
    {
        Locked,
        Unlocked
    }

    public enum Visibility : byte
    {
        Open,
        Closed
    }


    public enum MainNavigationTag : byte
    {
        Dashboard,
        KPA,
        KPI,
        Correlation,
        Filters,
        Reports
    }


    public enum SectionNavigationTag : byte
    {
        None = 0,
        Overall,
        Plan,
        PlanII,
        Purch,
        PurchII,
        PurchSub,
        PurchTotal,
        PurchPlan,
        FollowUp,
        HotJobs,
        ExcessStockStock,
        ExcessStockOpenOrders,
        CurrentPlanVsActual,
        Other
    }





    public class NavigationSettings : INavigationSettings
    {
        private Functionality status = default(Functionality);
        private Visibility visible = default(Visibility);

        /// <summary>
        /// Boolean to indicate whether or not the navigation windows is locked
        /// </summary>
        public Functionality Status
        {
            get { return status; }
            set { status = value; }
        }



        /// <summary>
        /// Boolean to indicate whether or not the navigation is in front of all other controls or not.
        /// </summary>
        public Visibility Visible
        {
            get { return visible; }
            set { visible = value; }
        }


        /// <summary>
        /// Defatault Constructor
        /// </summary>
        public NavigationSettings()
        {
            this.Status = Functionality.Locked;
            this.Visible = Visibility.Closed;
        }
    }
}
