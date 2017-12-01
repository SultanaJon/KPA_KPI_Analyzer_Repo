using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class PurchTwo
    {
        public PR_2nd_Lvl_Rel_Vs_PO_Creation pr2ndLvlRelVsPOCreation;
        public PO_Creation_vs_PO_Release poCreationVsPORel;
        public PO_Release_Vs_PO_Conf poRelVsPOConf;
        private double totalDays = 0;




        // Default Constructor
        public PurchTwo()
        {
            pr2ndLvlRelVsPOCreation = new PR_2nd_Lvl_Rel_Vs_PO_Creation();
            poCreationVsPORel = new PO_Creation_vs_PO_Release();
            poRelVsPOConf = new PO_Release_Vs_PO_Conf();
        }


        public string Name { get { return "Purch"; } }


        public enum CategorNames
        {
            pr2ndLvlRelVsPOCreation,
            poCreationVsPORel,
            poRelVsPOConf,
        }

        public string[] categoryNames =
        {
            "PR 2nd Lvl Release Date vs PO Creation Date",
            "PO Creation Date vs PO Release Date",
            "PO Release Date vs PO Confirmation Date",
        };






        /// <summary>
        /// Loads the data for the specific KPI
        /// </summary>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR 2nd Level Release vs PO Creation
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseUtils.prsOnPOsDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strPOLineCreateDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poCreateDtYear = int.Parse(strPOLineCreateDate[2]);
                    int poCreateDtMonth = int.Parse(strPOLineCreateDate[0].TrimStart('0'));
                    int poCreateDtDay = int.Parse(strPOLineCreateDate[1].TrimStart('0'));

                    DateTime poLineCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

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

                    DateTime pr2ndLvlRelDate = new DateTime(pr2ndLvlRelYear, pr2ndLvlRelMonth, pr2ndLvlRelDay);
                    double elapsedDays = (poLineCreateDate - pr2ndLvlRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    pr2ndLvlRelVsPOCreation.data.Total++;


                    if (elapsedDays <= 0)
                    {
                        pr2ndLvlRelVsPOCreation.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        pr2ndLvlRelVsPOCreation.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        pr2ndLvlRelVsPOCreation.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        pr2ndLvlRelVsPOCreation.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        pr2ndLvlRelVsPOCreation.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        pr2ndLvlRelVsPOCreation.data.TwentyTwo_TwentyEight++;
                    }
                    else if(elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        pr2ndLvlRelVsPOCreation.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        pr2ndLvlRelVsPOCreation.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        pr2ndLvlRelVsPOCreation.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        pr2ndLvlRelVsPOCreation.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        pr2ndLvlRelVsPOCreation.data.GreaterThanEqualFiftySeven++;
                    }
                }

                try
                {
                    pr2ndLvlRelVsPOCreation.data.Average = Math.Round(totalDays / pr2ndLvlRelVsPOCreation.data.Total, 2);
                    if (double.IsNaN(pr2ndLvlRelVsPOCreation.data.Average))
                        pr2ndLvlRelVsPOCreation.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    pr2ndLvlRelVsPOCreation.data.Average = 0;
                }


                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Creation vs PO Release
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseUtils.prsOnPOsDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strPOLine1stRelDt = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                    int poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0]);
                    int poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1]);

                    if(poLine1stRelDtYear == 0 && poLine1stRelDtMonth == 0 && poLine1stRelDtDay == 0)
                    {
                        
                        continue;
                    }
                    else
                    {
                        poCreationVsPORel.data.Total++;
                        poLine1stRelDtYear = int.Parse(strPOLine1stRelDt[2]);
                        poLine1stRelDtMonth = int.Parse(strPOLine1stRelDt[0].TrimStart('0'));
                        poLine1stRelDtDay = int.Parse(strPOLine1stRelDt[1].TrimStart('0'));
                    }

                    DateTime poLine1stRelDate = new DateTime(poLine1stRelDtYear, poLine1stRelDtMonth, poLine1stRelDtDay);

                    string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poOLineCreateDtYear = int.Parse(strPOLineCreateDt[2]);
                    int poOLineCreateDtMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                    int poOLineCreateDtDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                    DateTime poCreateDate = new DateTime(poOLineCreateDtYear, poOLineCreateDtMonth, poOLineCreateDtDay);
                    double elapsedDays = (poLine1stRelDate - poCreateDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        poCreationVsPORel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poCreationVsPORel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poCreationVsPORel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poCreationVsPORel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poCreationVsPORel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poCreationVsPORel.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        poCreationVsPORel.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        poCreationVsPORel.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        poCreationVsPORel.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        poCreationVsPORel.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        poCreationVsPORel.data.GreaterThanEqualFiftySeven++;
                    }
                }


                try
                {
                    poCreationVsPORel.data.Average = Math.Round(totalDays / poCreationVsPORel.data.Total, 2);
                    if (double.IsNaN(poCreationVsPORel.data.Average))
                        poCreationVsPORel.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poCreationVsPORel.data.Average = 0;
                }


                totalDays = 0;





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Release vs PO Confirm
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseUtils.prsOnPOsDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    string[] strPOLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLineFirstRelDateYear = int.Parse(strPOLineFirstRelDate[2]);
                    int poLineFirstRelDateMonth = int.Parse(strPOLineFirstRelDate[0]);
                    int poLineFirstRelDateDay = int.Parse(strPOLineFirstRelDate[1]);

                    if(poLineFirstRelDateYear == 0 && poLineFirstRelDateMonth == 0 && poLineFirstRelDateDay == 0)
                    {
                        continue;
                    }
                    else
                    {
                        poLineFirstRelDateYear = int.Parse(strPOLineFirstRelDate[2]);
                        poLineFirstRelDateMonth = int.Parse(strPOLineFirstRelDate[0].TrimStart('0'));
                        poLineFirstRelDateDay = int.Parse(strPOLineFirstRelDate[1].TrimStart('0'));
                    }

                    DateTime poLineFirstRelDate = new DateTime(poLineFirstRelDateYear, poLineFirstRelDateMonth, poLineFirstRelDateDay);

                    string[] strPOLineFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                    int poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0]);
                    int poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1]);


                    if(poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                    {
                        poRelVsPOConf.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                        poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0].TrimStart('0'));
                        poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1].TrimStart('0'));
                    }

                    poRelVsPOConf.data.Total++;

                    DateTime poLineFirstConfCreateDt = new DateTime(poLineFirstConfCreateYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                    double elapsedDays = (poLineFirstConfCreateDt - poLineFirstRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        poRelVsPOConf.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poRelVsPOConf.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poRelVsPOConf.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poRelVsPOConf.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poRelVsPOConf.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poRelVsPOConf.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        poRelVsPOConf.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        poRelVsPOConf.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        poRelVsPOConf.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        poRelVsPOConf.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        poRelVsPOConf.data.GreaterThanEqualFiftySeven++;
                    }
                }


                try
                {
                    poRelVsPOConf.data.Average = Math.Round(totalDays / poRelVsPOConf.data.Total, 2);
                    if (double.IsNaN(poRelVsPOConf.data.Average))
                        poRelVsPOConf.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poRelVsPOConf.data.Average = 0;
                }

                try
                {
                    poRelVsPOConf.data.PercentUnconf = Math.Round(((double)poRelVsPOConf.data.PercentUnconfTotal / (poRelVsPOConf.data.Total + poRelVsPOConf.data.PercentUnconfTotal)) * 100, 2);

                    if (double.IsNaN(poRelVsPOConf.data.PercentUnconf))
                        poRelVsPOConf.data.PercentUnconf = 0;

                    if (double.IsInfinity(poRelVsPOConf.data.PercentUnconf))
                        poRelVsPOConf.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    poRelVsPOConf.data.PercentUnconf = 0;
                }


                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Two Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class PR_2nd_Lvl_Rel_Vs_PO_Creation
    {
        public TempFour data;

        public PR_2nd_Lvl_Rel_Vs_PO_Creation()
        {
            data = new TempFour();
        }
    }






    public class PO_Creation_vs_PO_Release
    {
        public TempFour data;

        public PO_Creation_vs_PO_Release()
        {
            data = new TempFour();
        }
    }






    public class PO_Release_Vs_PO_Conf
    {
        public TempFour data;

        public PO_Release_Vs_PO_Conf()
        {
            data = new TempFour();
        }
    }
}
