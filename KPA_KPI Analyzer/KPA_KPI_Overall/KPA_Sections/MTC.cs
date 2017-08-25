
using KPA_KPI_Analyzer.Templates;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class MTC
    {
        public Material_Status currPlanDateCurrConfDate;

        // Default Constructor
        public MTC()
        {
            currPlanDateCurrConfDate = new Material_Status();
        }
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Material_Status
    {
        public TempOne data;

        public Material_Status()
        {
            data = new TempOne();
        }
    }
}
