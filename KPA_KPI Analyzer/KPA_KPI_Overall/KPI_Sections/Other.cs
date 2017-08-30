using KPA_KPI_Analyzer.DatabaseUtils;
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
        /// <param name="Overall.SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR Created
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                

                foreach (DataRow dr in Overall.AllDt.Rows)
                {
                    string[] strReqDate = (dr["Requisn Date"].ToString()).Split('/');
                    int reqDateYear = int.Parse(strReqDate[2]);
                    int reqDateMonth = int.Parse(strReqDate[0].TrimStart('0'));
                    int reqDateDay = int.Parse(strReqDate[1].TrimStart('0'));

                    DateTime requiDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                    totalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (requiDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);

                    if (weeks == 0)
                    {
                        prsCreated.data.Zero++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        prsCreated.data.LessOneWeek++;
                    }
                    else if (weeks >= (-2) && weeks > (-1))
                    {
                        prsCreated.data.LessTwoWeeks++;
                    }
                    else if (weeks >= (-3) && weeks > (-2))
                    {
                        prsCreated.data.LessThreeWeeks++;
                    }
                    else if (weeks >= (-4) && weeks > (-3))
                    {
                        prsCreated.data.LessFourWeeks++;
                    }
                    else if (weeks >= (-5) && weeks > (-4))
                    {
                        prsCreated.data.LessFiveWeeks++;
                    }
                    else if (weeks >= (-6) && weeks > (-5))
                    {
                        prsCreated.data.LessSixWeeks++;
                    }
                    else if (weeks >= (-7) && weeks > (-6))
                    {
                        prsCreated.data.LessSevenWeeks++;
                    }
                    else if (weeks >= (-8) && weeks > (-7))
                    {
                        prsCreated.data.LessEightWeeks++;
                    }
                    else if (weeks < (-8))
                    {
                        prsCreated.data.LessNinePlusWeeks++;
                    }
                }

                prsCreated.data.TotalValue = totalValue;
                prsCreated.data.Total = Overall.AllDt.Rows.Count;
                totalValue = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PRs Released
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                

                foreach (DataRow dr in Overall.pr2ndLvlRelDateDt.Rows)
                {
                    string[] strPr2ndLvlRelDt = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int pr2ndLvlRelDtYear = int.Parse(strPr2ndLvlRelDt[2]);
                    int pr2ndLvlRelDtMonth = int.Parse(strPr2ndLvlRelDt[0].TrimStart('0'));
                    int pr2ndLvlRelDtDay = int.Parse(strPr2ndLvlRelDt[1].TrimStart('0'));

                    DateTime pr2ndLvlRelDt = new DateTime(pr2ndLvlRelDtYear, pr2ndLvlRelDtMonth, pr2ndLvlRelDtDay);

                    totalValue += decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (pr2ndLvlRelDt - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);


                    if (weeks == 0)
                    {
                        prsReleased.data.Zero++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        prsReleased.data.LessOneWeek++;
                    }
                    else if (weeks >= (-2) && weeks > (-1))
                    {
                        prsReleased.data.LessTwoWeeks++;
                    }
                    else if (weeks >= (-3) && weeks > (-2))
                    {
                        prsReleased.data.LessThreeWeeks++;
                    }
                    else if (weeks >= (-4) && weeks > (-3))
                    {
                        prsReleased.data.LessFourWeeks++;
                    }
                    else if (weeks >= (-5) && weeks > (-4))
                    {
                        prsReleased.data.LessFiveWeeks++;
                    }
                    else if (weeks >= (-6) && weeks > (-5))
                    {
                        prsReleased.data.LessSixWeeks++;
                    }
                    else if (weeks >= (-7) && weeks > (-6))
                    {
                        prsReleased.data.LessSevenWeeks++;
                    }
                    else if (weeks >= (-8) && weeks > (-7))
                    {
                        prsReleased.data.LessEightWeeks++;
                    }
                    else if (weeks < (-8))
                    {
                        prsReleased.data.LessNinePlusWeeks++;
                    }
                }

                prsReleased.data.TotalValue = totalValue;
                prsReleased.data.Total = Overall.pr2ndLvlRelDateDt.Rows.Count;
                totalValue = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Total Spend
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                

                foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                {
                    string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                    int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                    int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                    DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                    totalValue += decimal.Parse(dr["PO Value"].ToString());
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (poCreateDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);


                    if (weeks == 0)
                    {
                        totalSpend.data.Zero++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        totalSpend.data.LessOneWeek++;
                    }
                    else if (weeks >= (-2) && weeks > (-1))
                    {
                        totalSpend.data.LessTwoWeeks++;
                    }
                    else if (weeks >= (-3) && weeks > (-2))
                    {
                        totalSpend.data.LessThreeWeeks++;
                    }
                    else if (weeks >= (-4) && weeks > (-3))
                    {
                        totalSpend.data.LessFourWeeks++;
                    }
                    else if (weeks >= (-5) && weeks > (-4))
                    {
                        totalSpend.data.LessFiveWeeks++;
                    }
                    else if (weeks >= (-6) && weeks > (-5))
                    {
                        totalSpend.data.LessSixWeeks++;
                    }
                    else if (weeks >= (-7) && weeks > (-6))
                    {
                        totalSpend.data.LessSevenWeeks++;
                    }
                    else if (weeks >= (-8) && weeks > (-7))
                    {
                        totalSpend.data.LessEightWeeks++;
                    }
                    else if (weeks < (-8))
                    {
                        totalSpend.data.LessNinePlusWeeks++;
                    }
                }

                totalSpend.data.TotalValue = totalValue;
                totalSpend.data.Total = Overall.prsOnPOsDt.Rows.Count;
                totalValue = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR vs PO Value
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                

                foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                {
                    string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                    int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                    int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                    DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                    totalValue += decimal.Parse(dr["PO Value"].ToString()) - decimal.Parse(dr["PR Pos#Value"].ToString());

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (poCreateDate - today).TotalDays;
                    double weeks = Math.Floor(elapsedDays / 7);


                    if (weeks == 0)
                    {
                        prVsPOValue.data.Zero++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        prVsPOValue.data.LessOneWeek++;
                    }
                    else if (weeks >= (-2) && weeks > (-1))
                    {
                        prVsPOValue.data.LessTwoWeeks++;
                    }
                    else if (weeks >= (-3) && weeks > (-2))
                    {
                        prVsPOValue.data.LessThreeWeeks++;
                    }
                    else if (weeks >= (-4) && weeks > (-3))
                    {
                        prVsPOValue.data.LessFourWeeks++;
                    }
                    else if (weeks >= (-5) && weeks > (-4))
                    {
                        prVsPOValue.data.LessFiveWeeks++;
                    }
                    else if (weeks >= (-6) && weeks > (-5))
                    {
                        prVsPOValue.data.LessSixWeeks++;
                    }
                    else if (weeks >= (-7) && weeks > (-6))
                    {
                        prVsPOValue.data.LessSevenWeeks++;
                    }
                    else if (weeks >= (-8) && weeks > (-7))
                    {
                        prVsPOValue.data.LessEightWeeks++;
                    }
                    else if (weeks < (-8))
                    {
                        prVsPOValue.data.LessNinePlusWeeks++;
                    }
                }

                prVsPOValue.data.TotalValue = totalValue;
                prVsPOValue.data.Total = Overall.prsOnPOsDt.Rows.Count;
                totalValue = 0;





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Hot Job PRs
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                

                foreach (DataRow dr in Overall.AllDt.Rows)
                {
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


                    if (weeks == 0)
                    {
                        hotJobPrs.data.Zero++;
                    }
                    else if (weeks >= (-1) && weeks < 0)
                    {
                        hotJobPrs.data.LessOneWeek++;
                    }
                    else if (weeks >= (-2) && weeks > (-1))
                    {
                        hotJobPrs.data.LessTwoWeeks++;
                    }
                    else if (weeks >= (-3) && weeks > (-2))
                    {
                        hotJobPrs.data.LessThreeWeeks++;
                    }
                    else if (weeks >= (-4) && weeks > (-3))
                    {
                        hotJobPrs.data.LessFourWeeks++;
                    }
                    else if (weeks >= (-5) && weeks > (-4))
                    {
                        hotJobPrs.data.LessFiveWeeks++;
                    }
                    else if (weeks >= (-6) && weeks > (-5))
                    {
                        hotJobPrs.data.LessSixWeeks++;
                    }
                    else if (weeks >= (-7) && weeks > (-6))
                    {
                        hotJobPrs.data.LessSevenWeeks++;
                    }
                    else if (weeks >= (-8) && weeks > (-7))
                    {
                        hotJobPrs.data.LessEightWeeks++;
                    }
                    else if (weeks < (-8))
                    {
                        hotJobPrs.data.LessNinePlusWeeks++;
                    }
                }

                hotJobPrs.data.TotalValue = totalValue;
                totalValue = 0;




                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "KPI -> Other Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
