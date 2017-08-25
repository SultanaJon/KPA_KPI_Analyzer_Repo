
using KPA_KPI_Analyzer.Templates;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class NCRs
    {
        public Open_NCRs openNCRs;
        public Open_NCR_Value openNCRValues;

        // Default Constructor
        public NCRs()
        {
            openNCRs = new Open_NCRs();
            openNCRValues = new Open_NCR_Value();
        }
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Open_NCRs
    {
        public TempOne data;

        public Open_NCRs()
        {
            data = new TempOne();
        }
    }






    public class Open_NCR_Value
    {
        public TempOne data;

        public Open_NCR_Value()
        {
            data = new TempOne();
        }
    }
}
