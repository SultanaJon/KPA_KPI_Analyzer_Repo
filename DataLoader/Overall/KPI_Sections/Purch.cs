using KPA_KPI_Analyzer.DatabaseUtils;
using DataLoader.Templates;
using System;
using System.Data;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Diagnostics;

namespace DataLoader.Overall.KPI_Sections
{
    public class Purch
    {
        public Init_Conf_vs_PR_Plan_Date initConfVsPRPlanDate;
        private double totalDays = 0;



        public delegate void ReportProgressHandler(string mesage);
        public event ReportProgressHandler ReportPogress;





        // Default Constructor
        public Purch()
        {
            initConfVsPRPlanDate = new Init_Conf_vs_PR_Plan_Date();
        }




        /// <summary>
        /// Loads the data for the specific KPI
        /// </summary>
        /// <param name="Overall.SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Initial Confirmation vs PR Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                
                foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                {
                    if (Filters.FilterByPrDateRange)
                    {
                        // The user wants to filter by PR date range
                        string[] requisnDate = (dr["Requisn Date"].ToString()).Split('/');
                        int reqYear = int.Parse(requisnDate[2]);
                        int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
                        int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
                        DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

                        if (reqTestDate < Filters.PrFromDate || reqTestDate > Filters.PrToDate)
                        {
                            // The PR date is not within the PR date range.
                            continue;
                        }
                    }

                    if (Filters.FilterByPoDateRange)
                    {
                        // The user wnats to filter by PO date range
                        string[] strPODate = (dr["PO Date"].ToString()).Split('/');
                        int poYear = int.Parse(strPODate[2]);
                        int poMonth = int.Parse(strPODate[0]);
                        int poDay = int.Parse(strPODate[1]);

                        if (poYear == 0 && poMonth == 0 && poDay == 0)
                        {
                            // This record is not a PO so we dont care about it
                            continue;
                        }
                        else
                        {
                            poYear = int.Parse(strPODate[2]);
                            poMonth = int.Parse(strPODate[0].TrimStart('0'));
                            poDay = int.Parse(strPODate[1].TrimStart('0'));
                        }

                        DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

                        if (poTestDate < Filters.PoFromDate || poTestDate > Filters.PoToDate)
                        {
                            // The PO date is not within the PO date range.
                            continue;
                        }
                    }



                    string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                    int firstConfYear = int.Parse(strFirstConfDate[2]);
                    int firstConfMonth = int.Parse(strFirstConfDate[0]);
                    int firstConfDay = int.Parse(strFirstConfDate[1]);

                    if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                    {
                        initConfVsPRPlanDate.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        initConfVsPRPlanDate.data.Total++;
                        firstConfYear = int.Parse(strFirstConfDate[2]);
                        firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                        firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                    }

                    DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                    string[] strPRPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int prDelYear = int.Parse(strPRPlanDate[2]);
                    int prDelMonth = int.Parse(strPRPlanDate[0].TrimStart('0'));
                    int prDelDay = int.Parse(strPRPlanDate[1].TrimStart('0'));

                    DateTime prPlanDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                    double elapsedDays = (firstConfDate - prPlanDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    initConfVsPRPlanDate.data.Total++;


                    if (elapsedDays <= (-22))
                    {
                        initConfVsPRPlanDate.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        initConfVsPRPlanDate.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        initConfVsPRPlanDate.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        initConfVsPRPlanDate.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        initConfVsPRPlanDate.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        initConfVsPRPlanDate.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        initConfVsPRPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        initConfVsPRPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        initConfVsPRPlanDate.data.TwentyTwo++;
                    }
                }



                try
                {
                    initConfVsPRPlanDate.data.Average = Math.Round(totalDays / initConfVsPRPlanDate.data.Total, 2);
                    if (double.IsNaN(initConfVsPRPlanDate.data.Average))
                        initConfVsPRPlanDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    initConfVsPRPlanDate.data.Average = 0;
                }




                try
                {
                    initConfVsPRPlanDate.data.PercentUnconf = Math.Round(((double)initConfVsPRPlanDate.data.PercentUnconfTotal / initConfVsPRPlanDate.data.Total) * 100, 2);
                    if (double.IsNaN(initConfVsPRPlanDate.data.PercentUnconf))
                        initConfVsPRPlanDate.data.PercentUnconf = 0;
                }
                catch (DivideByZeroException)
                {
                    initConfVsPRPlanDate.data.PercentUnconf = 0;
                }




                totalDays = 0;

                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
                ReportPogress("KPI- Purch Completed " + PRPO_DB_Utils.CompletedDataLoads);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class Init_Conf_vs_PR_Plan_Date
    {
        public TempThree data;

        public Init_Conf_vs_PR_Plan_Date()
        {
            data = new TempThree();
        }
    }
}
