using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class Other
    {
        public PRs_Created prsCreated;
        public PRs_Released prsReleased;
        public Total_Spend totalSpend;
        public PR_vs_PO_Value prVsPOValue;
        public Hot_Job_PRs hotJobPrs;
        private decimal totalValue = 0;



        public string Name { get { return "Other"; } }


        public enum CategorNames
        {
            prsCreated,
            prsReleased,
            totalSpend,
            prVsPOValue,
            hotJobPrs
        }

        public string[] categoryNames =
        {
            "PRs Created",
            "PRs Released",
            "Total Spend",
            "PR Value vs PO Value",
            "Hot Job PRs"
        };





        // Default Constructor
        public Other()
        {
            prsCreated = new PRs_Created();
            prsReleased = new PRs_Released();
            totalSpend = new Total_Spend();
            prVsPOValue = new PR_vs_PO_Value();
            hotJobPrs = new Hot_Job_PRs();
        }










        /// <summary>
        /// Loads the data of a specific KPI
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR Created
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                
                foreach (DataRow dr in PRPO_DB_Utils.AllDt.Rows)
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

                    if (Filters.FilterByFinalReceiptDate)
                    {
                        if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                        {
                            // The final receipt date was not in range of the filter the user applied
                            continue;
                        }
                    }

                    string[] strReqDate = (dr["Requisn Date"].ToString()).Split('/');
                    int reqDateYear = int.Parse(strReqDate[2]);
                    int reqDateMonth = int.Parse(strReqDate[0].TrimStart('0'));
                    int reqDateDay = int.Parse(strReqDate[1].TrimStart('0'));

                    DateTime requiDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                    totalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (requiDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    prsCreated.data.Total++;


                    if (weeks >= 0)
                    {
                        prsCreated.data.GreaterThanZeroWeeks++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        prsCreated.data.GreaterThanMinusOneWeeks++;
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        prsCreated.data.GreaterThanMinusTwoWeeks++;
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        prsCreated.data.GreaterThanMinusThreeWeeks++;
                    }
                    else if (weeks >= (-4) && weeks < (-3))
                    {
                        prsCreated.data.GreaterThanMinusFourWeeks++;
                    }
                    else if (weeks >= (-5) && weeks < (-4))
                    {
                        prsCreated.data.GreaterThanMinusFiveWeeks++;
                    }
                    else if (weeks >= (-6) && weeks < (-5))
                    {
                        prsCreated.data.GreaterThanMinusSixWeeks++;
                    }
                    else if (weeks >= (-7) && weeks < (-6))
                    {
                        prsCreated.data.GreaterThanMinusSevenWeeks++;
                    }
                    else if (weeks >= (-8) && weeks < (-7))
                    {
                        prsCreated.data.GreaterThanMinusEightWeeks++;
                    }
                    else if (weeks < (-8))
                    {
                        prsCreated.data.LessThanEightWeeks++;
                    }
                }

                prsCreated.data.TotalValue = totalValue;
                totalValue = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PRs Released
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                

                foreach (DataRow dr in PRPO_DB_Utils.pr2ndLvlRelDateDt.Rows)
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

                    if (Filters.FilterByFinalReceiptDate)
                    {
                        if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                        {
                            // The final receipt date was not in range of the filter the user applied
                            continue;
                        }
                    }

                    // This is a tempory fix for MEXICO TAG_MEXICO_FIX
                    // DELETE the refion below this commented code and uncomment this code.

                    //string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    //int pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                    //int pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                    //int pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));

                    #region MEXICOs TEMP FIX

                    string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                    int pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0]);
                    int pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1]);

                    if (pr2ndLvlRelYear == 0 && pr2ndLvlRelMonth == 0 && pr2ndLvlRelDay == 0)
                    {
                        // just ignore this bad Mexico data.
                        continue;
                    }
                    else
                    {
                        pr2ndLvlRelYear = int.Parse(strPr2ndLvlRelDt[2]);
                        pr2ndLvlRelMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                        pr2ndLvlRelDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));
                    }

                    #endregion

                    DateTime pr2ndLvlRelDt = new DateTime(pr2ndLvlRelYear, pr2ndLvlRelMonth, pr2ndLvlRelDay);

                    totalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (pr2ndLvlRelDt - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);


                    prsReleased.data.Total++;


                    if (weeks >= 0)
                    {
                        prsReleased.data.GreaterThanZeroWeeks++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        prsReleased.data.GreaterThanMinusOneWeeks++;
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        prsReleased.data.GreaterThanMinusTwoWeeks++;
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        prsReleased.data.GreaterThanMinusThreeWeeks++;
                    }
                    else if (weeks >= (-4) && weeks < (-3))
                    {
                        prsReleased.data.GreaterThanMinusFourWeeks++;
                    }
                    else if (weeks >= (-5) && weeks < (-4))
                    {
                        prsReleased.data.GreaterThanMinusFiveWeeks++;
                    }
                    else if (weeks >= (-6) && weeks < (-5))
                    {
                        prsReleased.data.GreaterThanMinusSixWeeks++;
                    }
                    else if (weeks >= (-7) && weeks < (-6))
                    {
                        prsReleased.data.GreaterThanMinusSevenWeeks++;
                    }
                    else if (weeks >= (-8) && weeks < (-7))
                    {
                        prsReleased.data.GreaterThanMinusEightWeeks++;
                    }
                    else if (weeks < (-8))
                    {
                        prsReleased.data.LessThanEightWeeks++;
                    }
                }

                prsReleased.data.TotalValue = totalValue;
                totalValue = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Total Spend
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

                    if (Filters.FilterByFinalReceiptDate)
                    {
                        if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                        {
                            // The final receipt date was not in range of the filter the user applied
                            continue;
                        }
                    }

                    string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                    int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                    int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                    DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                    totalValue += decimal.Parse(dr["PO Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (poCreateDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    totalSpend.data.Total++;


                    if (weeks >= 0)
                    {
                        totalSpend.data.GreaterThanZeroWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        totalSpend.data.GreaterThanMinusOneWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        totalSpend.data.GreaterThanMinusTwoWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        totalSpend.data.GreaterThanMinusThreeWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks >= (-4) && weeks < (-3))
                    {
                        totalSpend.data.GreaterThanMinusFourWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks >= (-5) && weeks < (-4))
                    {
                        totalSpend.data.GreaterThanMinusFiveWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks >= (-6) && weeks < (-5))
                    {
                        totalSpend.data.GreaterThanMinusSixWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks >= (-7) && weeks < (-6))
                    {
                        totalSpend.data.GreaterThanMinusSevenWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks >= (-8) && weeks < (-7))
                    {
                        totalSpend.data.GreaterThanMinusEightWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                    else if (weeks < (-8))
                    {
                        totalSpend.data.LessThanEightWeeks += decimal.Parse(dr["PO Value"].ToString());
                    }
                }

                totalSpend.data.TotalValue = totalValue;
                totalValue = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR vs PO Value
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

                    if (Filters.FilterByFinalReceiptDate)
                    {
                        if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                        {
                            // The final receipt date was not in range of the filter the user applied
                            continue;
                        }
                    }

                    string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                    int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                    int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                    DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                    totalValue += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (poCreateDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);


                    prVsPOValue.data.Total++;


                    if (weeks >= 0)
                    {
                        prVsPOValue.data.GreaterThanZeroWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        prVsPOValue.data.GreaterThanMinusOneWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        prVsPOValue.data.GreaterThanMinusTwoWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        prVsPOValue.data.GreaterThanMinusThreeWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks >= (-4) && weeks < (-3))
                    {
                        prVsPOValue.data.GreaterThanMinusFourWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks >= (-5) && weeks < (-4))
                    {
                        prVsPOValue.data.GreaterThanMinusFiveWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks >= (-6) && weeks < (-5))
                    {
                        prVsPOValue.data.GreaterThanMinusSixWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks >= (-7) && weeks < (-6))
                    {
                        prVsPOValue.data.GreaterThanMinusSevenWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks >= (-8) && weeks < (-7))
                    {
                        prVsPOValue.data.GreaterThanMinusEightWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                    else if (weeks < (-8))
                    {
                        prVsPOValue.data.LessThanEightWeeks += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));
                    }
                }

                prVsPOValue.data.TotalValue = totalValue;
                totalValue = 0;





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Hot Job PRs
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                

                foreach (DataRow dr in PRPO_DB_Utils.AllDt.Rows)
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

                    if (Filters.FilterByFinalReceiptDate)
                    {
                        if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                        {
                            // The final receipt date was not in range of the filter the user applied
                            continue;
                        }
                    }

                    if (dr["Purch# Group"].ToString() != "UHJ")
                        continue;
                    else
                        hotJobPrs.data.Total++;


                    string[] strPrReqDt = (dr["Requisn Date"].ToString()).Split('/');
                    int reqDateYear = int.Parse(strPrReqDt[2]);
                    int reqDateMonth = int.Parse(strPrReqDt[0].TrimStart('0'));
                    int reqDateDay = int.Parse(strPrReqDt[1].TrimStart('0'));

                    DateTime prReqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                    totalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (prReqDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    if (weeks >= 0)
                    {
                        hotJobPrs.data.GreaterThanZeroWeeks++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        hotJobPrs.data.GreaterThanMinusOneWeeks++;
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        hotJobPrs.data.GreaterThanMinusTwoWeeks++;
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        hotJobPrs.data.GreaterThanMinusThreeWeeks++;
                    }
                    else if (weeks >= (-4) && weeks < (-3))
                    {
                        hotJobPrs.data.GreaterThanMinusFourWeeks++;
                    }
                    else if (weeks >= (-5) && weeks < (-4))
                    {
                        hotJobPrs.data.GreaterThanMinusFiveWeeks++;
                    }
                    else if (weeks >= (-6) && weeks < (-5))
                    {
                        hotJobPrs.data.GreaterThanMinusSixWeeks++;
                    }
                    else if (weeks >= (-7) && weeks < (-6))
                    {
                        hotJobPrs.data.GreaterThanMinusSevenWeeks++;
                    }
                    else if (weeks >= (-8) && weeks < (-7))
                    {
                        hotJobPrs.data.GreaterThanMinusEightWeeks++;
                    }
                    else if (weeks < (-8))
                    {
                        hotJobPrs.data.LessThanEightWeeks++;
                    }
                }

                hotJobPrs.data.TotalValue = totalValue;
                totalValue = 0;


                PRPO_DB_Utils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Other Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class PRs_Created
    {
        public TempFive data;

        public PRs_Created()
        {
            data = new TempFive();
        }
    }






    public class PRs_Released
    {
        public TempFive data;

        public PRs_Released()
        {
            data = new TempFive();
        }
    }






    public class Total_Spend
    {
        public TempFive data;

        public Total_Spend()
        {
            data = new TempFive();
        }
    }






    public class PR_vs_PO_Value
    {
        public TempFive data;

        public PR_vs_PO_Value()
        {
            data = new TempFive();
        }
    }






    public class Hot_Job_PRs
    {
        public TempFive data;

        public Hot_Job_PRs()
        {
            data = new TempFive();
        }
    }
}
