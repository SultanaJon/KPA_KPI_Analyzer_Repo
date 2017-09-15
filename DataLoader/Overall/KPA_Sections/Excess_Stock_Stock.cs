
using DataLoader.Templates;


namespace DataLoader.Overall.KPA_Sections
{
    public class Excess_Stock_Stock
    {
        public PRs_Aging_Not_Rel prsAgingNotRel;
        public PRs_Aging_Rel prsAgingRel;
        public Conf_vs_Plan_Date confVsPlanDate;
        public Conf_Date_Upcoming_Del ConfDateUpcomingDel;

        // Default Constructor
        public Excess_Stock_Stock()
        {
            prsAgingNotRel = new PRs_Aging_Not_Rel();
            prsAgingRel = new PRs_Aging_Rel();
            confVsPlanDate = new Conf_vs_Plan_Date();
            ConfDateUpcomingDel = new Conf_Date_Upcoming_Del();
        }





        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //
        //  The below classes act as a specific KPA category that fall under a specific KPA section.
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class PRs_Aging_Not_Rel
        {
            public TempOne data;

            public PRs_Aging_Not_Rel()
            {
                data = new TempOne();
            }
        }






        public class PRs_Aging_Rel
        {
            public TempOne data;

            public PRs_Aging_Rel()
            {
                data = new TempOne();
            }
        }






        public class Conf_vs_Plan_Date
        {
            public TempOne data;

            public Conf_vs_Plan_Date()
            {
                data = new TempOne();
            }
        }






        public class Conf_Date_Upcoming_Del
        {
            public TempOne data;

            public Conf_Date_Upcoming_Del()
            {
                data = new TempOne();
            }
        }
    }
}
