
using KPA_KPI_Analyzer.Overall_Data.KPI_Sections;

namespace KPA_KPI_Analyzer.Overall_Data
{
    public class KPI
    {
        public Plan plan;
        public Purch purch;
        public FollowUp followUp;
        public PlanTwo planTwo;
        public PurchTwo purchTwo;
        public PurchSub purchSub;
        public PurchTotal purchTotal;
        public PurchPlan purchPlan;
        public Other other;






        /// <summary>
        /// Default KPI Constructor
        /// </summary>
        public KPI()
        {
            plan = new Plan();
            purch = new Purch();
            followUp = new FollowUp();
            planTwo = new PlanTwo();
            purchTwo = new PurchTwo();
            purchSub = new PurchSub();
            purchTotal = new PurchTotal();
            purchPlan = new PurchPlan();
            other = new Other();
        }
    }
}
