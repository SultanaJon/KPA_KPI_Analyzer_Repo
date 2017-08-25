using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;


namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class Plan
    {
        public PR_Plan_Date_Curr_Plan prPlanDateVsCurrPlan;
        public Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead origPlanDateMinus2ndLvlRelDateVsCodedLead;
        public Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead currPlanDateMinus2ndLvlRelDateVsCodedLead;
        private double totalDays = 0;

        // Default Constructor
        public Plan()
        {
            prPlanDateVsCurrPlan = new PR_Plan_Date_Curr_Plan();
            origPlanDateMinus2ndLvlRelDateVsCodedLead = new Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead();
            currPlanDateMinus2ndLvlRelDateVsCodedLead = new Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead();
        }





        /// <summary>
        /// Loads the data of a specific KPI
        /// </summary>
        /// <param name="Overall.SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR Plan Date vs Current Plan Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                prPlanDateVsCurrPlan.data.Total = Overall.prsOnPOsDt.Rows.Count;

                foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                {
                    string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strPrPlanDate[2]);
                    int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));

                    DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);

                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int currConfYear = int.Parse(strCurrPlanDate[2]);
                    int currConfMonth = int.Parse(strCurrPlanDate[0]);
                    int currConfDay = int.Parse(strCurrPlanDate[1]);

                    if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                    {
                        string[] strNewCurrConfDate = (dr["Delivery Date"].ToString()).Split('/');
                        currConfYear = int.Parse(strNewCurrConfDate[2]);
                        currConfMonth = int.Parse(strNewCurrConfDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strNewCurrConfDate[1].TrimStart('0'));
                    }
                    else
                    {
                        currConfYear = int.Parse(strCurrPlanDate[2]);
                        currConfMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime reqDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (reqDate - prPlanDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= (-22))
                    {
                        prPlanDateVsCurrPlan.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        prPlanDateVsCurrPlan.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-14) && elapsedDays <= (-8))
                    {
                        prPlanDateVsCurrPlan.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-7) && elapsedDays <= (-1))
                    {
                        prPlanDateVsCurrPlan.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        prPlanDateVsCurrPlan.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        prPlanDateVsCurrPlan.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prPlanDateVsCurrPlan.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prPlanDateVsCurrPlan.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        prPlanDateVsCurrPlan.data.TwentyTwo++;
                    }
                }



                try
                {
                    prPlanDateVsCurrPlan.data.Average = Math.Round(totalDays / prPlanDateVsCurrPlan.data.Total, 2);
                }
                catch (DivideByZeroException)
                {
                    prPlanDateVsCurrPlan.data.Average = 0;
                }


                totalDays = 0;
                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Plan Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }




    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PR_Plan_Date_Curr_Plan
    {
        public TempThree data;

        public PR_Plan_Date_Curr_Plan()
        {
            data = new TempThree();
        }
    }





    public class Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead
    {
        public TempThree data;

        public Orig_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead()
        {
            data = new TempThree();
        }
    }





    public class Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead
    {
        public TempThree data;

        public Curr_Plan_Date_Minus_2nd_Lvl_Rel_Date_vs_CodedLead()
        {
            data = new TempThree();
        }
    }
}
