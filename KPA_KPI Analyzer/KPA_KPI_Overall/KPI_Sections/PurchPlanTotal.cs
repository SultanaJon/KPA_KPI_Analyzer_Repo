using KPA_KPI_Analyzer.Templates;
using KPA_KPI_Analyzer.FilterFeeature;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class PurchPlanTotal
    {
        public Plan_Order_Creation_vs_Conf_Entry planOrderCreationVsConfEntry;

        // Default Constructor
        public PurchPlanTotal()
        {
            planOrderCreationVsConfEntry = new Plan_Order_Creation_vs_Conf_Entry();
        }



        public string Name { get { return "Purch Plan Total"; } }


        public enum CategorNames
        {
            planOrderCreationVsConfEntry
        }

        public string[] categoryNames =
        {
            "Planned Order Creation Date vs Confirmation Entry Date",
        };
    }







    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Plan_Order_Creation_vs_Conf_Entry
    {
        public TempFour data;

        public Plan_Order_Creation_vs_Conf_Entry()
        {
            data = new TempFour();
        }
    }
}
