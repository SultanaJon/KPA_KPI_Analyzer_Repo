using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall
{
    public class Overall
    {
        public KPA kpa;
        public KPI kpi;



        /// <summary>
        /// Default Overall Constructor
        /// </summary>
        public Overall()
        {
            kpa = new KPA();
            kpi = new KPI();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetKpaTempOneData()
        {
            List<List<string>> results = null;
            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    null,
                    new List<string>(kpa.plan.prsAgingNotRel.data.GetData()),
                    new List<string>(kpa.plan.matDueDate.data.GetData()),
                    new List<string>(kpa.purch.prsAgingRel.data.GetData()),
                    new List<string>(kpa.purch.poFirstRel.data.GetData()),
                    new List<string>(kpa.purch.poPrevRel.data.GetData()),
                    new List<string>(kpa.purch.noConfirmation.data.GetData()),
                    new List<string>(kpa.purchSub.prRelToPORel.data.GetData()),
                    new List<string>(kpa.purchSub.POCreatToConfEntry.data.GetData()),
                    new List<string>(kpa.purchTotal.prRelConfEntry.data.GetData()),
                    null,
                    new List<string>(kpa.followUp.confDateVsPlanDate.data.GetData()),
                    new List<string>(kpa.followUp.ConfDateForUpcomingDel.data.GetData()),
                    new List<string>(kpa.followUp.LateToConfDate.data.GetData()),
                    null,
                    null,
                    null,
                    null,
                    new List<string>(kpa.hotJobs.prsNotOnPO.data.GetData()),
                    new List<string>(kpa.hotJobs.noConfirmation.data.GetData()),
                    new List<string>(kpa.hotJobs.lateToConfirmed.data.GetData()),
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                };

                results = new List<List<string>>(temp);
                temp.Clear();
                temp = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return results;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetKpaTempTwoData()
        {
            List<List<string>> results = null;

            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    new List<string>(kpa.currPlanVsActual.currPlanDateCurrConfDate.data.GetData()),
                    new List<string>(kpa.currPlanVsActual.currPlanDateCurrConfDateHotJobs.data.GetData())
                };

                results = new List<List<string>>(temp);
                temp.Clear();
                temp = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return results;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetKpiTempThreeData()
        {
            List<List<string>> results = null;

            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    new List<string>(kpi.plan.prPlanDateVsCurrPlan.data.GetData()),
                    new List<string>(kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.GetData()),
                    new List<string>(kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.GetData()),
                    new List<string>(kpi.purch.initConfVsPRPlanDate.data.GetData()),
                    new List<string>(kpi.followUp.initConfVsCurrConf.data.GetData()),
                    new List<string>(kpi.followUp.finalConfDateVsFinalPlan.data.GetData()),
                    new List<string>(kpi.followUp.receiptDateVsCurrPlanDate.data.GetData()),
                    new List<string>(kpi.followUp.receiptDateVsOrigConfDate.data.GetData()),
                    new List<string>(kpi.followUp.receiptDateVsCurrConfDate.data.GetData()),
                };

                results = new List<List<string>>(temp);
                temp.Clear();
                temp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return results;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetKpiTempFourData()
        {
            List<List<string>> results = null;

            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    null,
                    null,
                    new List<string>(kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.GetData()),
                    new List<string>(kpi.purchTwo.poCreationVsPORel.data.GetData()),
                    new List<string>(kpi.purchTwo.poRelVsPOConf.data.GetData()),
                    new List<string>(kpi.purchSub.prRelVsPORel.data.GetData()),
                    new List<string>(kpi.purchSub.poCreateVsConfEntry.data.GetData()),
                    new List<string>(kpi.purchTotal.prRelConfEntry.data.GetData()),
                    new List<string>(kpi.purchPlan.poRelVsPRDelDate.data.GetData()),
                    new List<string>(kpi.purchPlan.pr2ndLvlRelOrigPlanDelDate.data.GetData()),
                    null,

                };

                results = new List<List<string>>(temp);
                temp.Clear();
                temp = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return results;
        }





        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<List<string>> GetKpiTempFiveData()
        {
            List<List<string>> results = null;

            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    new List<string>(kpi.other.prsCreated.data.GetData()),
                    new List<string>(kpi.other.prsReleased.data.GetData()),
                    new List<string>(kpi.other.totalSpend.data.GetData()),
                    new List<string>(kpi.other.prVsPOValue.data.GetData()),
                    new List<string>(kpi.other.hotJobPrs.data.GetData()),
                };

                results = new List<List<string>>(temp);
                temp.Clear();
                temp = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return results;
        }
    }
}
