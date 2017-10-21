
using KPA_KPI_Analyzer.Templates;


namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class Excess_Stock_Stock
    {
        public PRs_Aging_Not_Rel prsAgingNotRel;
        public PRs_Aging_Rel prsAgingRel;
        public PoCreateDate_ConfirmationEntry poCreateToConfEntryDate;


        // Default Constructor
        public Excess_Stock_Stock()
        {
            prsAgingNotRel = new PRs_Aging_Not_Rel();
            prsAgingRel = new PRs_Aging_Rel();
            poCreateToConfEntryDate = new PoCreateDate_ConfirmationEntry();
        }





        public string Name { get { return "Excess Stock - Stock"; } }


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






        public class PoCreateDate_ConfirmationEntry
        {
            public TempOne data;

            public PoCreateDate_ConfirmationEntry()
            {
                data = new TempOne();
            }
        }
    }
}
