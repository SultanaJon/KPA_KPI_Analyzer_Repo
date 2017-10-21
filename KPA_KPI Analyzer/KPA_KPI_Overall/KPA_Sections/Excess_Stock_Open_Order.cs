
using KPA_KPI_Analyzer.Templates;


namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class Excess_Stock_Open_Order
    {
        public PRs_Aging_Not_Rel prsAgingNotRel;
        public PRs_Aging_Rel prsAgingRel;
        public PoCreateToConfEntry poCreateConfEntry;

        // Default Constructor
        public Excess_Stock_Open_Order()
        {
            prsAgingNotRel = new PRs_Aging_Not_Rel();
            prsAgingRel = new PRs_Aging_Rel();
            poCreateConfEntry = new PoCreateToConfEntry();
        }


        public string Name { get { return "Excess Stock - Open Orders"; } }


        public enum CategorNames
        {
            PrsAgingNotReleased,
            PrsAgingReleased,
            PoCreationToConfirmationEntry
        }

        public string[] categoryNames =
        {
            "Prs Aging (Not Released)",
            "PRs Aging (Released)",
            "PO Creation to Confirmation Entry"
        };
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


    public class PoCreateToConfEntry
    {
        public TempOne data;

        public PoCreateToConfEntry()
        {
            data = new TempOne();
        }
    }
}
