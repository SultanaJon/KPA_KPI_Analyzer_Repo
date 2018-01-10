using ApplicationIOLibarary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Overall_Data
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
        /// Gathers a multidimentional list of all the data contained within KPI Temp One DataGridView
        /// </summary>
        /// <returns>A multidimentional list</returns>
        public List<List<string>> GetKpaTempOneData()
        {
            List<List<string>> results = null;
            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    new List<string>(kpa.plan.prsAgingNotRel.data.GetData()),
                    new List<string>(kpa.plan.matDueDate.data.GetData()),
                    new List<string>(kpa.purch.prsAgingRel.data.GetData()),
                    new List<string>(kpa.purch.poFirstRel.data.GetData()),
                    new List<string>(kpa.purch.poPrevRel.data.GetData()),
                    new List<string>(kpa.purch.noConfirmation.data.GetData()),
                    new List<string>(kpa.purchSub.prRelToPORel.data.GetData()),
                    new List<string>(kpa.purchSub.POCreatToConfEntry.data.GetData()),
                    new List<string>(kpa.purchTotal.prRelConfEntry.data.GetData()),
                    new List<string>(kpa.followUp.confDateVsPlanDate.data.GetData()),
                    new List<string>(kpa.followUp.ConfDateForUpcomingDel.data.GetData()),
                    new List<string>(kpa.followUp.LateToConfDate.data.GetData()),
                    new List<string>(kpa.hotJobs.prsNotOnPO.data.GetData()),
                    new List<string>(kpa.hotJobs.noConfirmation.data.GetData()),
                    new List<string>(kpa.hotJobs.lateToConfirmed.data.GetData()),
                    new List<string>(kpa.excessStockStock.prsAgingNotRel.data.GetData()),
                    new List<string>(kpa.excessStockStock.prsAgingRel.data.GetData()),
                    new List<string>(kpa.excessStockStock.PoCreationThruDeliv.data.GetData()),
                    new List<string>(kpa.excessStockOpenOrders.prsAgingNotRel.data.GetData()),
                    new List<string>(kpa.excessStockOpenOrders.prsAgingRel.data.GetData()),
                    new List<string>(kpa.excessStockOpenOrders.PoCreationThruDeliv.data.GetData()),
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
        /// Gathers a multidimentional list of all the data contained within KPI Temp Two DataGridView
        /// </summary>
        /// <returns>A multidimentional list</returns>
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
        /// Gathers a multidimentional list of all the data contained within KPI Temp Three DataGridView
        /// </summary>
        /// <returns>A multidimentional list</returns>
        public List<List<string>> GetKpiTempThreeData()
        {
            List<List<string>> results = null;

            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    new List<string>(kpi.plan.currPlanDateVsPrPlanDate.data.GetData()),
                    new List<string>(kpi.plan.origPlanDateMinus2ndLvlRelDateVsCodedLead.data.GetData()),
                    new List<string>(kpi.plan.currPlanDateMinus2ndLvlRelDateVsCodedLead.data.GetData()),
                    new List<string>(kpi.purch.initConfVsPRPlanDate.data.GetData()),
                    new List<string>(kpi.followUp.currConfVsInitConf.data.GetData()),
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
        /// Gathers a multidimentional list of all the data contained within KPI Temp Four DataGridView
        /// </summary>
        /// <returns>A multidimentional list</returns>
        public List<List<string>> GetKpiTempFourData()
        {
            List<List<string>> results = null;

            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    new List<string>(kpi.planTwo.materialDueOrigPlanDate.data.GetData()),
                    new List<string>(kpi.planTwo.materialDueFinalPlanDate.data.GetData()),
                    new List<string>(kpi.purchTwo.pr2ndLvlRelVsPOCreation.data.GetData()),
                    new List<string>(kpi.purchTwo.poCreationVsPORel.data.GetData()),
                    new List<string>(kpi.purchTwo.poRelVsPOConf.data.GetData()),
                    new List<string>(kpi.purchSub.prRelVsPORel.data.GetData()),
                    new List<string>(kpi.purchSub.poCreateVsConfEntry.data.GetData()),
                    new List<string>(kpi.purchTotal.prRelConfEntry.data.GetData()),
                    new List<string>(kpi.purchPlan.poRelVsPRDelDate.data.GetData()),
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
        /// Gathers a multidimentional list of all the data contained within KPI Temp Five DataGridView
        /// </summary>
        /// <returns>A multidimentional list</returns>
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




        /// <summary>
        /// Loads the Overall object from JSON file.kpa 
        /// </summary>
        public void Load(ref Overall overallData)
        {
            //try
            //{
            //    if (Values.Globals.TargetCountry == Values.Countries.Country.UnitedStates)
            //        dataJSONString = File.ReadAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.US_Overall]);
            //    else
            //        dataJSONString = File.ReadAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.MX_Overall]);

            //    overallData = ser.Deserialize<Overall>(dataJSONString);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Overall DataReader Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }




        /// <summary>
        /// Saves the overall data to a JSON file.
        /// </summary>
        public void Save()
        {
            //try
            //{
            //    dataJSONString = ser.Serialize(this);
            //    if (Values.Globals.TargetCountry == Values.Countries.Country.UnitedStates)
            //    {
            //        File.WriteAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.US_Overall], dataJSONString);
            //    }
            //    else
            //    {
            //        File.WriteAllText(ApplicationIOLibarary.ApplicationFiles.FileUtils.overallFiles[(int)ApplicationIOLibarary.ApplicationFiles.OverallFile.MX_Overall], dataJSONString);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Overall DataReader Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}