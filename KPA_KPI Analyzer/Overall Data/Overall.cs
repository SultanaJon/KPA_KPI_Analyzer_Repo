﻿using KPA_KPI_Analyzer.Diagnostics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Overall_Data
{
    public class Overall : IStorable, ILoadable<Overall>
    {
        public KPA kpa;
        public KPI kpi;



        private JavaScriptSerializer ser;
        private string dataJSONString;



        /// <summary>
        /// Default Overall Constructor
        /// </summary>
        public Overall()
        {
            kpa = new KPA();
            kpi = new KPI();
            ser = new JavaScriptSerializer();
            dataJSONString = string.Empty;
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

            // Need to append dollar signs onto total spend and pr vs po value counts because they are values rather than counts.
            List<string> totalSpendList = new List<string>(kpi.other.totalSpend.data.GetData());

            for(int i = 0; i < totalSpendList.Count; ++i)
            {
                totalSpendList[i] = totalSpendList[i].Insert(0, "$");
            }

            List<string> prVsPoValueList = new List<string>(kpi.other.prVsPOValue.data.GetData());
            for (int i = 0; i < prVsPoValueList.Count; ++i)
            {
                prVsPoValueList[i] = prVsPoValueList[i].Insert(0, "$");
            }



            try
            {
                List<List<string>> temp = new List<List<string>>
                {
                    new List<string>(kpi.other.prsCreated.data.GetData()),
                    new List<string>(kpi.other.prsReleased.data.GetData()),
                    totalSpendList,
                    prVsPoValueList,
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
        /// <returns>Boolean value indicating whether or not he load operation was successful.</returns>
        public void Load(ref Overall overallData)
        {
            try
            {
                if (Values.Globals.TargetCountry == Values.Countries.Country.UnitedStates)
                    dataJSONString = File.ReadAllText(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFile.US_Overall]);
                else
                    dataJSONString = File.ReadAllText(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFile.MX_Overall]);

                overallData = ser.Deserialize<Overall>(dataJSONString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Overall DataReader Loading Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        /// <summary>
        /// Saves the overall data to a JSON file.
        /// </summary>
        /// <returns>A boolean value indicating whether or not the save operation was successful.</returns>
        public void Save()
        {
            try
            {
                dataJSONString = ser.Serialize(this);
                if (Values.Globals.TargetCountry == Values.Countries.Country.UnitedStates)
                {
                    File.WriteAllText(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFile.US_Overall], dataJSONString);
                }
                else
                {
                    File.WriteAllText(AppDirectoryUtils.overallFiles[(int)AppDirectoryUtils.OverallFile.MX_Overall], dataJSONString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Overall DataReader Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}