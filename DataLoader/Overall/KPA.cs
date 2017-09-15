
using KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall
{
    public class KPA
    {
        public Plan plan;
        public Purch purch;
        public Purch_Sub purchSub;
        public Purch_Total purchTotal;
        public Purch_Plan_Total purchPlanTotal;
        public Follow_Up followUp;
        public Cancellations cancellations;
        public NCRs ncrs;
        public Hot_Jobs hotJobs;
        public Excess_Stock_Stock excessStockStock;
        public Excess_Stock_Open_Order excessStockOpenOrders;
        public Current_Plan_vs_Actual currPlanVsActual;
        public MTC mtc;




        /// <summary>
        /// Default KPA Constructor
        /// </summary>
        public KPA()
        {
            plan = new Plan();
            purch = new Purch();
            purchSub = new Purch_Sub();
            purchTotal = new Purch_Total();
            purchPlanTotal = new Purch_Plan_Total();
            followUp = new Follow_Up();
            cancellations = new Cancellations();
            ncrs = new NCRs();
            hotJobs = new Hot_Jobs();
            excessStockStock = new Excess_Stock_Stock();
            excessStockOpenOrders = new Excess_Stock_Open_Order();
            currPlanVsActual = new Current_Plan_vs_Actual();
            mtc = new MTC();
        }
    }
}
