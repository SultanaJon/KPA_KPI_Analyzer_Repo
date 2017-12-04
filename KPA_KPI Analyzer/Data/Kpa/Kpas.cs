using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Data.Kpa.Sections;


namespace KPA_KPI_Analyzer.Data.Kpa
{
    public class Kpas
    {
        public Plan plan = new Plan();
        public Purch purch = new Purch();
        public PurchSub purchSub = new PurchSub();
        public PurchTotal purchTotal = new PurchTotal();
        public FollowUp followUp = new FollowUp();
        public HotJobs hotJobs = new HotJobs();
        public ExcessStockStock excessStockStock = new ExcessStockStock();
        public ExcessStockOpenOrders excessStockOpenOrders = new ExcessStockOpenOrders();
        public CurrentPlanVsActual currPlanVsActual = new CurrentPlanVsActual();


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Kpas()
        {
        }
    }
}
