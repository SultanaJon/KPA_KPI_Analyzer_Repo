
using KPA_KPI_Analyzer.Templates;


namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class Purch_Plan_Total
    {
        public Plan_Order_Conf_Entry PlanOrderConfEntry;

        // Default Constructor
        public Purch_Plan_Total()
        {
            PlanOrderConfEntry = new Plan_Order_Conf_Entry();
        }
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Plan_Order_Conf_Entry
    {
        public TempOne data;

        public Plan_Order_Conf_Entry()
        {
            data = new TempOne();
        }
    }
}
