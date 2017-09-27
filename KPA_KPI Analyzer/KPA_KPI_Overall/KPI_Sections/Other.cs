using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Diagnostics;

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



        // Default Constructor
        public Other()
        {
            prsCreated = new PRs_Created();
            prsReleased = new PRs_Released();
            totalSpend = new Total_Spend();
            prVsPOValue = new PR_vs_PO_Value();
            hotJobPrs = new Hot_Job_PRs();
        }






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
                        prsCreated.data.GreaterThanZeroWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        prsCreated.data.GreaterThanMinusOneWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        prsCreated.data.GreaterThanMinusTwoWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        prsCreated.data.GreaterThanMinusThreeWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-4) && weeks < (-3))
                    {
                        prsCreated.data.GreaterThanMinusFourWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-5) && weeks < (-4))
                    {
                        prsCreated.data.GreaterThanMinusFiveWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-6) && weeks < (-5))
                    {
                        prsCreated.data.GreaterThanMinusSixWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-7) && weeks < (-6))
                    {
                        prsCreated.data.GreaterThanMinusSevenWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-8) && weeks < (-7))
                    {
                        prsCreated.data.GreaterThanMinusEightWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks < (-8))
                    {
                        prsCreated.data.LessThanEightWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
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



                    string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int pr2ndLvlRelDtYear = int.Parse(strPr2ndLvlRelDt[2]);
                    int pr2ndLvlRelDtMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                    int pr2ndLvlRelDtDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));

                    DateTime pr2ndLvlRelDt = new DateTime(pr2ndLvlRelDtYear, pr2ndLvlRelDtMonth, pr2ndLvlRelDtDay);

                    totalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (pr2ndLvlRelDt - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);


                    prsReleased.data.Total++;


                    if (weeks >= 0)
                    {
                        prsReleased.data.GreaterThanZeroWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        prsReleased.data.GreaterThanMinusOneWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        prsReleased.data.GreaterThanMinusTwoWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        prsReleased.data.GreaterThanMinusThreeWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-4) && weeks < (-3))
                    {
                        prsReleased.data.GreaterThanMinusFourWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-5) && weeks < (-4))
                    {
                        prsReleased.data.GreaterThanMinusFiveWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-6) && weeks < (-5))
                    {
                        prsReleased.data.GreaterThanMinusSixWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-7) && weeks < (-6))
                    {
                        prsReleased.data.GreaterThanMinusSevenWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-8) && weeks < (-7))
                    {
                        prsReleased.data.GreaterThanMinusEightWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks < (-8))
                    {
                        prsReleased.data.LessThanEightWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
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



                    string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                    int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                    int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                    DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                    totalValue += (decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString()));

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - poCreateDate).TotalDays;
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
                        hotJobPrs.data.GreaterThanZeroWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        hotJobPrs.data.GreaterThanMinusOneWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-2) && weeks < (-1))
                    {
                        hotJobPrs.data.GreaterThanMinusTwoWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-3) && weeks < (-2))
                    {
                        hotJobPrs.data.GreaterThanMinusThreeWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-4) && weeks < (-3))
                    {
                        hotJobPrs.data.GreaterThanMinusFourWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-5) && weeks < (-4))
                    {
                        hotJobPrs.data.GreaterThanMinusFiveWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-6) && weeks < (-5))
                    {
                        hotJobPrs.data.GreaterThanMinusSixWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-7) && weeks < (-6))
                    {
                        hotJobPrs.data.GreaterThanMinusSevenWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks >= (-8) && weeks < (-7))
                    {
                        hotJobPrs.data.GreaterThanMinusEightWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                    else if (weeks < (-8))
                    {
                        hotJobPrs.data.LessThanEightWeeks += decimal.Parse(dr["PR Pos#Value"].ToString());
                    }
                }

                hotJobPrs.data.TotalValue = totalValue;
                totalValue = 0;




                PRPO_DB_Utils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Other Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
