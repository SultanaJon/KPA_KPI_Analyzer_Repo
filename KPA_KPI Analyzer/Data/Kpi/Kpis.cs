using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPA_KPI_Analyzer.Data.Kpi.Sections;

namespace KPA_KPI_Analyzer.Data.Kpi
{
    public class Kpis
    {
        public Plan plan = new Plan();
        public Purch purch = new Purch();
        public FollowUp followUp = new FollowUp();
        public PlanTwo planTwo = new PlanTwo();
        public PurchTwo purchTwo = new PurchTwo();
        public PurchSub purchSub = new PurchSub();
        public PurchTotal purchTotal = new PurchTotal();
        public PurchPlan purchPlan = new PurchPlan();
        public Other other = new Other();


        /// <summary>
        /// Default Constructor
        /// </summary>
        public Kpis()
        {

        }
    }
}
