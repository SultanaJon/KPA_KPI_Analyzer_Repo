
using KPA_KPI_Analyzer.Templates;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class Cancellations
    {
        public Cancellation_Count cancellationCount;
        public Cancellation_Value cancellationValue;

        // Default Constructor
        public Cancellations()
        {
            cancellationCount = new Cancellation_Count();
            cancellationValue = new Cancellation_Value();
        }


        public string Name { get { return "Cancellations"; } }


        public enum CategorNames
        {
            CancellationCount,
            CancellationValue,
        }

        public string[] categoryNames =
        {
            "Cancellation Count",
            "Cancellation Value",
        };
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class Cancellation_Count
    {
        public TempOne data;

        public Cancellation_Count()
        {
            data = new TempOne();
        }
    }





    public class Cancellation_Value
    {
        public TempOne data;

        public Cancellation_Value()
        {
            data = new TempOne();
        }
    }
}
