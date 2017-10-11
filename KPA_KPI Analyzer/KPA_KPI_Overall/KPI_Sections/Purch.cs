using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class Purch
    {
        public Init_Conf_vs_PR_Plan_Date initConfVsPRPlanDate;
        private double totalDays = 0;




        // Default Constructor
        public Purch()
        {
            initConfVsPRPlanDate = new Init_Conf_vs_PR_Plan_Date();
        }


        public string Name { get { return "Purch"; } }


        public enum CategorNames
        {
            initConfVsPRPlanDate

        }

        public string[] categoryNames =
        {
            "Initial Confirmation Date vs PR Plan Date",
        };




        /// <summary>
        /// Loads the data for the specific KPI
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Initial Confirmation vs PR Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                
                foreach (DataRow dr in PRPO_DB_Utils.prsOnPOsDt.Rows)
                {
                    if (Filters.FilterByPrDateRange)
                    {
                        if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                        {
                            // The PR Date was not in range of the filter the user applied.
                            continue;
                        }
                    }

                    if (Filters.FilterByPoDateRange)
                    {
                        if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                        {
                            // The PO Date was not in range of the filter the user applied.
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
                    initConfVsPRPlanDate.data.PercentUnconf = Math.Round(((double)initConfVsPRPlanDate.data.PercentUnconfTotal / (initConfVsPRPlanDate.data.Total + initConfVsPRPlanDate.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(initConfVsPRPlanDate.data.PercentUnconf))
                        initConfVsPRPlanDate.data.PercentUnconf = 0;

                    if (double.IsInfinity(initConfVsPRPlanDate.data.PercentUnconf))
                        initConfVsPRPlanDate.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    initConfVsPRPlanDate.data.PercentUnconf = 0;
                }
                totalDays = 0;

                PRPO_DB_Utils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
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
