﻿using KPA_KPI_Analyzer.DatabaseUtils;
using DataLoader.Templates;
using System;
using System.Data;
using System.Windows.Forms;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Diagnostics;

namespace DataLoader.Overall.KPI_Sections
{
    public class PurchSub
    {
        public PR_Rel_Vs_PO_Rel prRelVsPORel;
        public PO_Create_Vs_Conf_Entry poCreateVsConfEntry;
        private double totalDays = 0;



        public delegate void ReportProgressHandler(string mesage);
        public event ReportProgressHandler ReportPogress;





        // Default Constructor
        public PurchSub()
        {
            prRelVsPORel = new PR_Rel_Vs_PO_Rel();
            poCreateVsConfEntry = new PO_Create_Vs_Conf_Entry();
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
                // PR Release vs PO Release
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



                    string[] strPOLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLineFirstRelYear = int.Parse(strPOLineFirstRelDate[2]);
                    int poLineFirstRelMonth = int.Parse(strPOLineFirstRelDate[0]);
                    int poLineFirstRelDay = int.Parse(strPOLineFirstRelDate[1]);

                    if(poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                    {
                        continue;
                    }
                    else
                    {
                        prRelVsPORel.data.Total++;
                        poLineFirstRelYear = int.Parse(strPOLineFirstRelDate[2]);
                        poLineFirstRelMonth = int.Parse(strPOLineFirstRelDate[0].TrimStart('0'));
                        poLineFirstRelDay = int.Parse(strPOLineFirstRelDate[1].TrimStart('0'));
                    }

                    DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                    string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int secLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                    int secLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                    int secLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));

                    DateTime pr2ndLvlRelDate = new DateTime(secLvlRelYear, secLvlRelMonth, secLvlRelDay);
                    double elapsedDays = (poLineFirstRelDate - pr2ndLvlRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        prRelVsPORel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        prRelVsPORel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        prRelVsPORel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prRelVsPORel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prRelVsPORel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        prRelVsPORel.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        prRelVsPORel.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        prRelVsPORel.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        prRelVsPORel.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        prRelVsPORel.data.Fifty_FiftySix++;
                    }
                    else // elapsed days >= 57
                    {
                        prRelVsPORel.data.greaterThanEqualFiftySeven++;
                    }
                }

                try
                {
                    prRelVsPORel.data.Average = Math.Round(totalDays / prRelVsPORel.data.Total, 2);
                    if (double.IsNaN(prRelVsPORel.data.Average))
                        prRelVsPORel.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    prRelVsPORel.data.Average = 0;
                }
                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Creation vs Confirmation Entry
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                int tempTotal = 0;

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



                    tempTotal++;
                    string[] strFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int poLineFirstConfCreateYear = int.Parse(strFirstConfCreateDate[2]);
                    int poLineFirstConfCreateMonth = int.Parse(strFirstConfCreateDate[0]);
                    int poLineFirstConfCreateDay = int.Parse(strFirstConfCreateDate[1]);

                    if(poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                    {
                        poCreateVsConfEntry.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        poLineFirstConfCreateYear = int.Parse(strFirstConfCreateDate[2]);
                        poLineFirstConfCreateMonth = int.Parse(strFirstConfCreateDate[0]);
                        poLineFirstConfCreateDay = int.Parse(strFirstConfCreateDate[1]);
                    }
                    

                    DateTime initialConfCreateDate = new DateTime(poLineFirstConfCreateYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                    string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poLineCreateYear = int.Parse(strPOLineCreateDt[2]);
                    int poLineCreateMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                    int poLineCreateDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                    DateTime poLineItemCreateDate = new DateTime(poLineCreateYear, poLineCreateMonth, poLineCreateDay);

                    double elapsedDays = (initialConfCreateDate - poLineItemCreateDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    poCreateVsConfEntry.data.Total++;


                    if (elapsedDays <= 0)
                    {
                        poCreateVsConfEntry.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poCreateVsConfEntry.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poCreateVsConfEntry.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poCreateVsConfEntry.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poCreateVsConfEntry.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poCreateVsConfEntry.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        poCreateVsConfEntry.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        poCreateVsConfEntry.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        poCreateVsConfEntry.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        poCreateVsConfEntry.data.Fifty_FiftySix++;
                    }
                    else // elapsed days >= 57
                    {
                        poCreateVsConfEntry.data.greaterThanEqualFiftySeven++;
                    }
                }


                try
                {
                    poCreateVsConfEntry.data.Average = Math.Round(totalDays / poCreateVsConfEntry.data.Total, 2);
                    if (double.IsNaN(poCreateVsConfEntry.data.Average))
                        poCreateVsConfEntry.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poCreateVsConfEntry.data.Average = 0;
                }


                try
                {
                    poCreateVsConfEntry.data.PercentUnconf = Math.Round(((double)poCreateVsConfEntry.data.PercentUnconfTotal / tempTotal) * 100, 2);
                    if (double.IsNaN(poCreateVsConfEntry.data.PercentUnconf))
                        poCreateVsConfEntry.data.PercentUnconf = 0;
                }
                catch (DivideByZeroException)
                {
                    poCreateVsConfEntry.data.PercentUnconf = 0;
                }


                totalDays = 0;

                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
                ReportPogress("KPI - Purch Sub Completed " + PRPO_DB_Utils.CompletedDataLoads);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Sub Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class PR_Rel_Vs_PO_Rel
    {
        public TempFour data;

        public PR_Rel_Vs_PO_Rel()
        {
            data = new TempFour();
        }
    }






    public class PO_Create_Vs_Conf_Entry
    {
        public TempFour data;

        public PO_Create_Vs_Conf_Entry()
        {
            data = new TempFour();
        }
    }


}