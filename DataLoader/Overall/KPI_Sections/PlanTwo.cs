using DataLoader.Templates;
using KPA_KPI_Analyzer.FilterFeeature;


namespace DataLoader.Overall.KPI_Sections
{
    public class PlanTwo
    {
        public PR_Plan_Date_vs_PR_2nd_Lvl_Rel prPlanDateVsPR2ndLvlRel;
        public Plan_Order_Creation_vs_2nd_Lvl_Rel planOrderCreatVs2ndLvlRel;

        // Default Constructor
        public PlanTwo()
        {
            prPlanDateVsPR2ndLvlRel = new PR_Plan_Date_vs_PR_2nd_Lvl_Rel();
            planOrderCreatVs2ndLvlRel = new Plan_Order_Creation_vs_2nd_Lvl_Rel();
        }
    }






    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PR_Plan_Date_vs_PR_2nd_Lvl_Rel
    {
        public TempFour data;

        public PR_Plan_Date_vs_PR_2nd_Lvl_Rel()
        {
            data = new TempFour();
        }
    }





    public class Plan_Order_Creation_vs_2nd_Lvl_Rel
    {
        public TempFour data;

        public Plan_Order_Creation_vs_2nd_Lvl_Rel()
        {
            data = new TempFour();
        }
    }
}
