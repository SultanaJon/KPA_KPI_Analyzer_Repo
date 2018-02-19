using DataAccessLibrary;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.DataLoading.KPI_Data.DataTableLoader
{
    public static class KpiDataTableLoader
    {
        private static DataTable dt;
        private static DataTable unconfirmed;


        public static class Plan
        {
            private static DataTable prPlanDateVsCurrPlanDt, 
                                     OrigPlan2ndLvlRel_CodedLeadTimeDt, 
                                     CurrPlan2ndLvlRel_CodedLeadTimeDt;



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrPlanDateVsCurrentPlanDateDataTable(int tag)
            {
                dt = KpiManager.KpiQueries.GetAllPOs();
                prPlanDateVsCurrPlanDt = new DataTable();
                prPlanDateVsCurrPlanDt = dt.Clone();


                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strPrPlanDate[2]);
                    int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));

                    DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);

                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int currPlanYear = int.Parse(strCurrPlanDate[2]);
                    int currPlanMonth = int.Parse(strCurrPlanDate[0]);
                    int currPlanDay = int.Parse(strCurrPlanDate[1]);

                    if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                    {
                        string[] strNewCurrConfDate = (dr["Delivery Date"].ToString()).Split('/');
                        currPlanYear = int.Parse(strNewCurrConfDate[2]);
                        currPlanMonth = int.Parse(strNewCurrConfDate[0].TrimStart('0'));
                        currPlanDay = int.Parse(strNewCurrConfDate[1].TrimStart('0'));
                    }
                    else
                    {
                        currPlanYear = int.Parse(strCurrPlanDate[2]);
                        currPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        currPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime reqDate = new DateTime(currPlanYear, currPlanMonth, currPlanDay);
                    double elapsedDays = (reqDate - prPlanDate).TotalDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;

                    switch (tag)
                    {
                        case 0:
                            prPlanDateVsCurrPlanDt.ImportRow(dr);
                            break;
                        case 1:
                            if (elapsedDays <= (-22))
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        case 2:
                            if (elapsedDays > (-22) && elapsedDays <= (-15))
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        case 3:
                            if (elapsedDays > (-15) && elapsedDays <= (-8))
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        case 4:
                            if (elapsedDays > (-8) && elapsedDays <= (-1))
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        case 5:
                            if (elapsedDays == 0)
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        case 6:
                            if (elapsedDays >= 1 && elapsedDays <= 7)
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        case 7:
                            if (elapsedDays >= 8 && elapsedDays <= 14)
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        case 8:
                            if (elapsedDays >= 15 && elapsedDays <= 21)
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        case 9:
                            if (elapsedDays >= 22)
                            {
                                prPlanDateVsCurrPlanDt.ImportRow(dr);
                            }
                            continue;
                        default:
                            continue;
                    }
                }
                DataViewerUtils.Data = prPlanDateVsCurrPlanDt.Copy();
                DataViewerUtils.DataLoaded = true;

                prPlanDateVsCurrPlanDt.Rows.Clear();
                prPlanDateVsCurrPlanDt = null;
                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadOrigPlanDate2ndLvlRelDate_CodedLeadDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPr2ndLevelRelease();
                    OrigPlan2ndLvlRel_CodedLeadTimeDt = new DataTable();
                    OrigPlan2ndLvlRel_CodedLeadTimeDt = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }


                        string[] strPrPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                        int delConfYear = int.Parse(strPrPlanDate[2]);
                        int delConfMonth = int.Parse(strPrPlanDate[0].TrimStart('0'));
                        int delConfDay = int.Parse(strPrPlanDate[1].TrimStart('0'));


                        // This is a tempory fix for MEXICO TAG_MEXICO_FIX
                        // DELETE the refion below this commented code and uncomment this code.


                        #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                        string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                        int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                        int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                        int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                        if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                        {
                            // This PR line or PR in general might have been delted
                            continue;
                        }

                        #endregion


                        DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                        DateTime prPlanDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                        int commCodeLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                        double elapsedDays = (prPlanDate - prFullyRelDt).TotalDays;
                        elapsedDays -= commCodeLeadTime;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        elapsedDays = (int)elapsedDays;

                        switch (tag)
                        {
                            case 0:
                                OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    OrigPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = OrigPlan2ndLvlRel_CodedLeadTimeDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    OrigPlan2ndLvlRel_CodedLeadTimeDt.Rows.Clear();
                    OrigPlan2ndLvlRel_CodedLeadTimeDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadCurrPlanDate2ndLvlRelDate_CodedLeadDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPr2ndLevelRelease();
                    CurrPlan2ndLvlRel_CodedLeadTimeDt = new DataTable();
                    CurrPlan2ndLvlRel_CodedLeadTimeDt = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                        string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                        int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                        int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                        int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                        if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                        {
                            // This PR line or PR in general might have been delted
                            continue;
                        }


                        #endregion

                        DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);



                        string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                        int currPlanYear = int.Parse(strCurrPlanDate[2]);
                        int currPlanMonth = int.Parse(strCurrPlanDate[0]);
                        int currPlanDay = int.Parse(strCurrPlanDate[1]);

                        if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                        {
                            string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                            currPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            currPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                            currPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                            if (currPlanYear == 0 && currPlanMonth == 0 && currPlanDay == 0)
                            {
                                string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                                currPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                                currPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                                currPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                            }
                            else
                            {
                                currPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                                currPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                                currPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                            }
                        }
                        else
                        {
                            currPlanYear = int.Parse(strCurrPlanDate[2]);
                            currPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                            currPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                        }

                        DateTime currPlanDate = new DateTime(currPlanYear, currPlanMonth, currPlanDay);
                        int commCodedLeadTime = int.Parse(dr["Pl# Deliv# Time"].ToString());

                        double elapsedDays = (currPlanDate - prFullyRelDt).TotalDays;
                        elapsedDays -= commCodedLeadTime;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        elapsedDays = (int)elapsedDays;

                        switch (tag)
                        {
                            case 0:
                                CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    CurrPlan2ndLvlRel_CodedLeadTimeDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = CurrPlan2ndLvlRel_CodedLeadTimeDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    CurrPlan2ndLvlRel_CodedLeadTimeDt.Rows.Clear();
                    CurrPlan2ndLvlRel_CodedLeadTimeDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static class Purch
        {
            private static DataTable initConfVsPrPlanDateDt;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadInitialConfVsPrPlanDateDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    initConfVsPrPlanDateDt = new DataTable();
                    unconfirmed = new DataTable();
                    initConfVsPrPlanDateDt = dt.Clone();
                    unconfirmed = dt.Clone();

                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }


                        string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                        int firstConfYear = int.Parse(strFirstConfDate[2]);
                        int firstConfMonth = int.Parse(strFirstConfDate[0]);
                        int firstConfDay = int.Parse(strFirstConfDate[1]);

                        if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                        {
                            if (tag == 10)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes
                            {
                                initConfVsPrPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        }
                        else
                        {
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
                        double elapsedDays = (int)(firstConfDate - prPlanDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                initConfVsPrPlanDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    initConfVsPrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = initConfVsPrPlanDateDt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }



                    if (initConfVsPrPlanDateDt != null)
                    {
                        initConfVsPrPlanDateDt.Rows.Clear();
                        initConfVsPrPlanDateDt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }


                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
        }


        public static class FollowUp
        {
            private static DataTable initConfVsCurrConf;
            private static DataTable finalConfDateVsFinalPlanDateDt;
            private static DataTable recDateVsCurrPlanDateDt;
            private static DataTable recDateVsOrigConfDateDt;
            private static DataTable recDateVsCurrConfDateDt;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadCurrConfVsInitConfDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    initConfVsCurrConf = new DataTable();
                    unconfirmed = new DataTable();
                    initConfVsCurrConf = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                        int firstConfYear = int.Parse(strFirstConfDate[2]);
                        int firstConfMonth = int.Parse(strFirstConfDate[0]);
                        int firstConfDay = int.Parse(strFirstConfDate[1]);


                        if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                        {
                            if (tag == 10)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes
                            {
                                initConfVsCurrConf.ImportRow(dr);
                            }
                            continue;
                        }
                        else
                        {
                            firstConfYear = int.Parse(strFirstConfDate[2]);
                            firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                            firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                        }

                        DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                        string[] strDdelConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                        int delConfYear = int.Parse(strDdelConfDate[2]);
                        int delConfMonth = int.Parse(strDdelConfDate[0].TrimStart('0'));
                        int delConfDay = int.Parse(strDdelConfDate[1].TrimStart('0'));

                        DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                        double elapsedDays = (delConfDate - firstConfDate).TotalDays;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                initConfVsCurrConf.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    initConfVsCurrConf.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = initConfVsCurrConf.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if(initConfVsCurrConf != null)
                    {
                        initConfVsCurrConf.Rows.Clear();
                        initConfVsCurrConf = null;
                    }

                    if(unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }


                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadFinalConfDateVsFinalPlanDateDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPoLinesReceivedComplete();
                    finalConfDateVsFinalPlanDateDt = new DataTable();
                    unconfirmed = new DataTable();
                    finalConfDateVsFinalPlanDateDt = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        string[] strDelConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                        int delConfYear = int.Parse(strDelConfDate[2]);
                        int delConfMonth = int.Parse(strDelConfDate[0]);
                        int delConfDay = int.Parse(strDelConfDate[1]);

                        if (delConfYear == 0 && delConfMonth == 0 && delConfDay == 0)
                        {
                            if (tag == 10)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes unconfirmed
                            {
                                finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                            }
                            continue;
                        }
                        else
                        {
                            delConfYear = int.Parse(strDelConfDate[2]);
                            delConfMonth = int.Parse(strDelConfDate[0].TrimStart('0'));
                            delConfDay = int.Parse(strDelConfDate[1].TrimStart('0'));
                        }

                        DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);


                        string[] strDelDate = (dr["Delivery Date"].ToString()).Split('/');
                        int delYear = int.Parse(strDelDate[2]);
                        int delMonth = int.Parse(strDelDate[0].TrimStart('0'));
                        int delDay = int.Parse(strDelDate[1].TrimStart('0'));

                        DateTime delDate = new DateTime(delYear, delMonth, delDay);
                        double elapsedDays = (delConfDate - delDate).TotalDays;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    finalConfDateVsFinalPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = finalConfDateVsFinalPlanDateDt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (finalConfDateVsFinalPlanDateDt != null)
                    {
                        finalConfDateVsFinalPlanDateDt.Rows.Clear();
                        finalConfDateVsFinalPlanDateDt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }


                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadRecDateVsCurrPlanDateDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPoLinesReceivedComplete();
                    recDateVsCurrPlanDateDt = new DataTable();
                    recDateVsCurrPlanDateDt = dt.Clone();

                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        #region EVASO_BUT_NO_REC_DATE_CHECK

                        string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                        int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                        int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                        int lastPORecDtDay = int.Parse(strLastPORecDate[1]);


                        if (lastPORecDtYear == 0 && lastPORecDtMonth == 0 && lastPORecDtDay == 0)
                        {
                            // this po line or po in general may have been deleted.
                            continue;
                        }

                        #endregion


                        DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

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

                        DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                        double elapsedDays = (lastPORecDate - currPlanDate).TotalDays;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                recDateVsCurrPlanDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    recDateVsCurrPlanDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    DataViewerUtils.Data = recDateVsCurrPlanDateDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    recDateVsCurrPlanDateDt.Rows.Clear();
                    recDateVsCurrPlanDateDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>s
            public static void LoadRecDateVsOrigConfDateDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPoLinesReceivedComplete();
                    recDateVsOrigConfDateDt = new DataTable();
                    unconfirmed = new DataTable();
                    recDateVsOrigConfDateDt = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        #region EVASO_BUT_NO_REC_DATE_CHECK

                        string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                        int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                        int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                        int lastPORecDtDay = int.Parse(strLastPORecDate[1]);


                        if (lastPORecDtYear == 0 && lastPORecDtMonth == 0 && lastPORecDtDay == 0)
                        {
                            // this po line or po in general may have been deleted.
                            continue;
                        }

                        #endregion


                        DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                        string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                        int firstConfYear = int.Parse(strFirstConfDate[2]);
                        int firstConfMonth = int.Parse(strFirstConfDate[0]);
                        int firstConfDay = int.Parse(strFirstConfDate[1]);

                        if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                        {
                            if (tag == 10)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes
                            {
                                recDateVsOrigConfDateDt.ImportRow(dr);
                            }
                            continue;
                        }
                        else
                        {
                            firstConfYear = int.Parse(strFirstConfDate[2]);
                            firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                            firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                        }

                        DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);
                        double elapsedDays = (lastPORecDate - firstConfDate).TotalDays;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                recDateVsOrigConfDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    recDateVsOrigConfDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = recDateVsOrigConfDateDt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (recDateVsOrigConfDateDt != null)
                    {
                        recDateVsOrigConfDateDt.Rows.Clear();
                        recDateVsOrigConfDateDt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadRecDateVsCurrConfDateDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPoLinesReceivedComplete();
                    recDateVsCurrConfDateDt = new DataTable();
                    unconfirmed = new DataTable();
                    recDateVsCurrConfDateDt = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }


                        #region EVASO_BUT_NO_REC_DATE_CHECK

                        string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                        int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                        int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                        int lastPORecDtDay = int.Parse(strLastPORecDate[1]);


                        if (lastPORecDtYear == 0 && lastPORecDtMonth == 0 && lastPORecDtDay == 0)
                        {
                            // this po line or po in general may have been deleted.
                            continue;
                        }

                        #endregion


                        DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                        string[] strCurrConfDate = (dr["Latest Conf#Dt"].ToString()).Split('/');
                        int currConfYear = int.Parse(strCurrConfDate[2]);
                        int currConfMonth = int.Parse(strCurrConfDate[0]);
                        int currConfDay = int.Parse(strCurrConfDate[1]);

                        if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                        {
                            if (tag == 10)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes
                            {
                                recDateVsCurrConfDateDt.ImportRow(dr);
                            }
                            continue;
                        }
                        else
                        {
                            currConfYear = int.Parse(strCurrConfDate[2]);
                            currConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                            currConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));
                        }
                        DateTime currConfDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                        double elapsedDays = (lastPORecDate - currConfDate).TotalDays;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        switch (tag)
                        {
                            case 0:
                                recDateVsCurrConfDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= (-22))
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays > (-22) && elapsedDays <= (-15))
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays > (-15) && elapsedDays <= (-8))
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays > (-8) && elapsedDays <= (-1))
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays == 0)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 1 && elapsedDays <= 7)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 22)
                                {
                                    recDateVsCurrConfDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 10)
                    {
                        DataViewerUtils.Data = recDateVsCurrConfDateDt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (recDateVsCurrConfDateDt != null)
                    {
                        recDateVsCurrConfDateDt.Rows.Clear();
                        recDateVsCurrConfDateDt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static class PlanTwo
        {
            private static DataTable MaterialDueOrigPlanDate;
            private static DataTable MaterialDueFinalPlannedDate;
            private static DataTable prRelDateVsPrCreateDateDt;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadMaterialDueOrigPlanDate(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPr2ndLevelRelease();
                    MaterialDueOrigPlanDate = new DataTable();
                    MaterialDueOrigPlanDate = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }



                        string[] strOrigPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                        int origPlanYear = int.Parse(strOrigPlanDate[2]);
                        int origPlanMonth = int.Parse(strOrigPlanDate[0]);
                        int origPlanDay = int.Parse(strOrigPlanDate[1]);


                        #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                        string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                        int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                        int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                        int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                        if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                        {
                            // This PR line or PR in general might have been delted
                            continue;
                        }


                        #endregion

                        DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                        DateTime origPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                        double elapsedDays = (origPlanDate - prFullyRelDt).TotalDays;

                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        elapsedDays = (int)elapsedDays;

                        switch (tag)
                        {
                            case 0:
                                MaterialDueOrigPlanDate.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    MaterialDueOrigPlanDate.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = MaterialDueOrigPlanDate.Copy();
                    DataViewerUtils.DataLoaded = true;

                    MaterialDueOrigPlanDate.Rows.Clear();
                    MaterialDueOrigPlanDate = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadMaterialDueFinalPlanDate(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    MaterialDueFinalPlannedDate = new DataTable();
                    MaterialDueFinalPlannedDate = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }



                        #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                        string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                        int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                        int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                        int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                        if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                        {
                            // This PR line or PR in general might have been delted
                            continue;
                        }


                        #endregion

                        DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);

                        string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                        int origPlanYear = int.Parse(strCurrPlanDate[2]);
                        int origPlanMonth = int.Parse(strCurrPlanDate[0]);
                        int origPlanDay = int.Parse(strCurrPlanDate[1]);

                        if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                        {
                            string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                            origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                            origPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                            if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                            {
                                string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                                origPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                                origPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                                origPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                            }
                            else
                            {
                                origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                                origPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                                origPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                            }
                        }
                        else
                        {
                            origPlanYear = int.Parse(strCurrPlanDate[2]);
                            origPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                        }

                        DateTime currPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                        double elapsedDays = (currPlanDate - prFullyRelDt).TotalDays;


                        if (elapsedDays < 0)
                            elapsedDays = Math.Floor(elapsedDays);

                        if (elapsedDays > 0)
                            elapsedDays = Math.Ceiling(elapsedDays);

                        elapsedDays = (int)elapsedDays;




                        switch (tag)
                        {
                            case 0:
                                MaterialDueFinalPlannedDate.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    MaterialDueFinalPlannedDate.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    DataViewerUtils.Data = MaterialDueFinalPlannedDate.Copy();
                    DataViewerUtils.DataLoaded = true;

                    MaterialDueFinalPlannedDate.Rows.Clear();
                    MaterialDueFinalPlannedDate = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrReleaseDateVsPrCreationDate(int tag)
            {
                dt = KpiManager.KpiQueries.GetFullyReleasedPRs();
                prRelDateVsPrCreateDateDt = new DataTable();
                prRelDateVsPrCreateDateDt = dt.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                    string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                    int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                    int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                    int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                    if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                    {
                        // This PR line or PR in general might have been deleted
                        continue;
                    }

                    #endregion

                    // Get the Requisition date and seperate the date into year, month, and day integers
                    string[] strReqCreateDate = (dr["Requisn Date"].ToString()).Split('/');
                    int reqCreateYear = int.Parse(strReqCreateDate[2]);
                    int reqCreateMonth = int.Parse(strReqCreateDate[0].TrimStart('0'));
                    int reqCreateDay = int.Parse(strReqCreateDate[1].TrimStart('0'));

                    // Create the date objects
                    DateTime reqCreateDate = new DateTime(reqCreateYear, reqCreateMonth, reqCreateDay);
                    DateTime prFullReleaseDate = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);

                    double elapsedDays = (prFullReleaseDate - reqCreateDate).TotalDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;

                    switch (tag)
                    {
                        case 0:
                            prRelDateVsPrCreateDateDt.ImportRow(dr);
                            break;
                        case 1:
                            if (elapsedDays <= 0)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 2:
                            if (elapsedDays >= 1 && elapsedDays <= 3)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 3:
                            if (elapsedDays >= 4 && elapsedDays <= 7)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 4:
                            if (elapsedDays >= 8 && elapsedDays <= 14)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 5:
                            if (elapsedDays >= 15 && elapsedDays <= 21)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 6:
                            if (elapsedDays >= 22 && elapsedDays <= 28)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 7:
                            if (elapsedDays >= 29 && elapsedDays <= 35)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 8:
                            if (elapsedDays >= 36 && elapsedDays <= 42)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 9:
                            if (elapsedDays >= 43 && elapsedDays <= 49)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 10:
                            if (elapsedDays >= 50 && elapsedDays <= 56)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        case 11:
                            if (elapsedDays >= 57)
                            {
                                prRelDateVsPrCreateDateDt.ImportRow(dr);
                            }
                            continue;
                        default:
                            continue;
                    }
                }
                DataViewerUtils.Data = prRelDateVsPrCreateDateDt.Copy();
                DataViewerUtils.DataLoaded = true;

                prRelDateVsPrCreateDateDt.Rows.Clear();
                prRelDateVsPrCreateDateDt = null;
                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
        }


        public static class PurchTwo
        {
            private static DataTable pr2ndLvlRelVsPoCreate;
            private static DataTable poCreateVsPORel;
            private static DataTable poRelVsPoConf;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPr2ndLvlRelVsPOCreationDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    pr2ndLvlRelVsPoCreate = new DataTable();
                    pr2ndLvlRelVsPoCreate = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
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

                        #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                        string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                        int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                        int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                        int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                        if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                        {
                            // This PR line or PR in general might have been delted
                            continue;
                        }


                        #endregion

                        DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                        double elapsedDays = (int)(poLineCreateDate - prFullyRelDt).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    pr2ndLvlRelVsPoCreate.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = pr2ndLvlRelVsPoCreate.Copy();
                    DataViewerUtils.DataLoaded = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    pr2ndLvlRelVsPoCreate.Rows.Clear();
                    pr2ndLvlRelVsPoCreate = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }


            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPoCreationVsPoReleaseDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    poCreateVsPORel = new DataTable();
                    poCreateVsPORel = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
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

                        if (poLine1stRelDtYear == 0 && poLine1stRelDtMonth == 0 && poLine1stRelDtDay == 0)
                        {
                            continue;
                        }
                        else
                        {
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
                        double elapsedDays = (int)(poLine1stRelDate - poCreateDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poCreateVsPORel.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poCreateVsPORel.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poCreateVsPORel.Copy();
                    DataViewerUtils.DataLoaded = true;

                    poCreateVsPORel.Rows.Clear();
                    poCreateVsPORel = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPoReleaseVsPoConfDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    poRelVsPoConf = new DataTable();
                    unconfirmed = new DataTable();
                    poRelVsPoConf = dt.Clone();
                    unconfirmed = dt.Clone();

                    foreach (DataRow dr in dt.Rows)
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

                        if (poLineFirstRelDateYear == 0 && poLineFirstRelDateMonth == 0 && poLineFirstRelDateDay == 0)
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


                        if (poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                        {
                            if (tag == 12)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes
                            {
                                poRelVsPoConf.ImportRow(dr);
                            }
                            continue;
                        }
                        else
                        {
                            poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                            poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0].TrimStart('0'));
                            poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1].TrimStart('0'));
                        }

                        DateTime poLineFirstConfCreateDt = new DateTime(poLineFirstConfCreateYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                        double elapsedDays = (int)(poLineFirstConfCreateDt - poLineFirstRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poRelVsPoConf.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poRelVsPoConf.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 12)
                    {
                        DataViewerUtils.Data = poRelVsPoConf.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (poRelVsPoConf != null)
                    {
                        poRelVsPoConf.Rows.Clear();
                        poRelVsPoConf = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static class FollowUpTwo
        {
            private static DataTable poReleaseToLastPoReceipt;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPoReleaseDateToLastPoReceiptDate(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPoLinesReceivedComplete();
                    poReleaseToLastPoReceipt = new DataTable();
                    unconfirmed = new DataTable();
                    poReleaseToLastPoReceipt = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        #region EVASO_BUT_NO_REC_DATE_CHECK

                        string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                        int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                        int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                        int lastPORecDtDay = int.Parse(strLastPORecDate[1]);


                        if (lastPORecDtYear == 0 && lastPORecDtMonth == 0 && lastPORecDtDay == 0)
                        {
                            // this po line or po in general may have been deleted.
                            continue;
                        }

                        #endregion


                        string[] strDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                        int poLine1stRelDateYear = int.Parse(strDate[2]);
                        int poLine1stRelDateMonth = int.Parse(strDate[0]);
                        int poLine1stRelDateDay = int.Parse(strDate[1]);

                        if (poLine1stRelDateYear == 0 && poLine1stRelDateMonth == 0 && poLine1stRelDateDay == 0)
                        {
                            // this po line or po in general may have been deleted.
                            continue;
                        }




                        string[] strPOLineFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                        int poLineFirstConfCreateYear = int.Parse(strPOLineFirstConfCreateDate[2]);
                        int poLineFirstConfCreateMonth = int.Parse(strPOLineFirstConfCreateDate[0]);
                        int poLineFirstConfCreateDay = int.Parse(strPOLineFirstConfCreateDate[1]);


                        if (poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                        {
                            if (tag == 12)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes
                            {
                                poReleaseToLastPoReceipt.ImportRow(dr);
                            }
                            continue;
                        }



                        DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);
                        DateTime firstRelDate = new DateTime(poLine1stRelDateYear, poLine1stRelDateMonth, poLine1stRelDateDay);

                        double elapsedDays = (int)(lastPORecDate - firstRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poReleaseToLastPoReceipt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poReleaseToLastPoReceipt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }


                    if (tag != 12)
                    {
                        DataViewerUtils.Data = poReleaseToLastPoReceipt.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (poReleaseToLastPoReceipt != null)
                    {
                        poReleaseToLastPoReceipt.Rows.Clear();
                        poReleaseToLastPoReceipt = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static class PurchSub
        {
            private static DataTable prRelVsPORel;
            private static DataTable poCreateVsConfEntry;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrRelVsPoRelDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    prRelVsPORel = new DataTable();
                    prRelVsPORel = dt.Clone();


                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }


                        string[] strPOLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                        int poLineFirstRelYear = int.Parse(strPOLineFirstRelDate[2]);
                        int poLineFirstRelMonth = int.Parse(strPOLineFirstRelDate[0]);
                        int poLineFirstRelDay = int.Parse(strPOLineFirstRelDate[1]);

                        if (poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                        {
                            continue;
                        }
                        else
                        {
                            poLineFirstRelYear = int.Parse(strPOLineFirstRelDate[2]);
                            poLineFirstRelMonth = int.Parse(strPOLineFirstRelDate[0].TrimStart('0'));
                            poLineFirstRelDay = int.Parse(strPOLineFirstRelDate[1].TrimStart('0'));
                        }

                        DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                        #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                        string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                        int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                        int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                        int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                        if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                        {
                            // This PR line or PR in general might have been delted
                            continue;
                        }


                        #endregion

                        DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                        double elapsedDays = (int)(poLineFirstRelDate - prFullyRelDt).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prRelVsPORel.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    prRelVsPORel.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prRelVsPORel.Copy();
                    DataViewerUtils.DataLoaded = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    prRelVsPORel.Rows.Clear();
                    prRelVsPORel = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }


            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPoCreationVsConfEntryDateDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    poCreateVsConfEntry = new DataTable();
                    unconfirmed = new DataTable();
                    poCreateVsConfEntry = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        string[] strFirstConCreatefDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                        int poLineFirstConCreatefYear = int.Parse(strFirstConCreatefDate[2]);
                        int poLineFirstConfCreateMonth = int.Parse(strFirstConCreatefDate[0]);
                        int poLineFirstConfCreateDay = int.Parse(strFirstConCreatefDate[1]);

                        if (poLineFirstConCreatefYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                        {
                            if (tag == 12)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes
                            {
                                poCreateVsConfEntry.ImportRow(dr);
                            }
                            continue;
                        }
                        else
                        {
                            poLineFirstConCreatefYear = int.Parse(strFirstConCreatefDate[2]);
                            poLineFirstConfCreateMonth = int.Parse(strFirstConCreatefDate[0]);
                            poLineFirstConfCreateDay = int.Parse(strFirstConCreatefDate[1]);
                        }


                        DateTime initialConfCreateDate = new DateTime(poLineFirstConCreatefYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                        string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int poLineCreateYear = int.Parse(strPOLineCreateDt[2]);
                        int poLineCreateMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                        int poLineCreateDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                        DateTime poLineItemCreateDate = new DateTime(poLineCreateYear, poLineCreateMonth, poLineCreateDay);

                        double elapsedDays = (int)(initialConfCreateDate - poLineItemCreateDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poCreateVsConfEntry.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poCreateVsConfEntry.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    if (tag != 12)
                    {
                        DataViewerUtils.Data = poCreateVsConfEntry.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }


                    if (poCreateVsConfEntry != null)
                    {
                        poCreateVsConfEntry.Rows.Clear();
                        poCreateVsConfEntry = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }

                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static class PurchTotal
        {
            private static DataTable prReleaseConfEntry;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrReleaseConfEntryDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    prReleaseConfEntry = new DataTable();
                    unconfirmed = new DataTable();
                    prReleaseConfEntry = dt.Clone();
                    unconfirmed = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }


                        string[] strfirstConfCreateDt = (dr["1st Conf Creation Da"].ToString()).Split('/');
                        int firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                        int firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0]);
                        int firstConfCreateDay = int.Parse(strfirstConfCreateDt[1]);

                        if (firstConfCreateYear == 0 && firstConfCreateMonth == 0 & firstConfCreateDay == 0)
                        {
                            if (tag == 12)
                            {
                                unconfirmed.ImportRow(dr);
                            }

                            if (tag == 0) // The user wants to view the total which also includes
                            {
                                prReleaseConfEntry.ImportRow(dr);
                            }
                            continue;
                        }
                        else
                        {
                            firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                            firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0].TrimStart('0'));
                            firstConfCreateDay = int.Parse(strfirstConfCreateDt[1].TrimStart('0'));
                        }

                        DateTime poLineConfCreateDate = new DateTime(firstConfCreateYear, firstConfCreateMonth, firstConfCreateDay);

                        #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                        string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                        int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                        int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                        int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                        if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                        {
                            // This PR line or PR in general might have been delted
                            continue;
                        }


                        #endregion

                        DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                        double elapsedDays = (int)(poLineConfCreateDate - prFullyRelDt).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                prReleaseConfEntry.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    prReleaseConfEntry.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }

                    if (tag != 12)
                    {
                        DataViewerUtils.Data = prReleaseConfEntry.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }
                    else
                    {
                        DataViewerUtils.Data = unconfirmed.Copy();
                        DataViewerUtils.DataLoaded = true;
                    }



                    if (prReleaseConfEntry != null)
                    {
                        prReleaseConfEntry.Rows.Clear();
                        prReleaseConfEntry = null;
                    }

                    if (unconfirmed != null)
                    {
                        unconfirmed.Rows.Clear();
                        unconfirmed = null;
                    }


                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static class PurchPlan
        {
            private static DataTable poRelVsPRDelDateDt;
            private static string[] strPoLineFirstRelDate;

            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPoRelVsPrDelDateDataTable(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    poRelVsPRDelDateDt = new DataTable();
                    poRelVsPRDelDateDt = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }


                        strPoLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                        int poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                        int poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0]);
                        int poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1]);

                        if (poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                        {
                            continue;
                        }
                        else
                        {
                            poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                            poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0].TrimStart('0'));
                            poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1].TrimStart('0'));
                        }

                        DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                        string[] strPRDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                        int prDelYear = int.Parse(strPRDelDate[2]);
                        int prDelMonth = int.Parse(strPRDelDate[0].TrimStart('0'));
                        int prDelDay = int.Parse(strPRDelDate[1].TrimStart('0'));

                        DateTime prDelDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                        double elapsedDays = (int)(prDelDate - poLineFirstRelDate).TotalDays;

                        switch (tag)
                        {
                            case 0:
                                poRelVsPRDelDateDt.ImportRow(dr);
                                break;
                            case 1:
                                if (elapsedDays <= 0)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (elapsedDays >= 1 && elapsedDays <= 3)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (elapsedDays >= 4 && elapsedDays <= 7)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (elapsedDays >= 8 && elapsedDays <= 14)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (elapsedDays >= 15 && elapsedDays <= 21)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (elapsedDays >= 22 && elapsedDays <= 28)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (elapsedDays >= 29 && elapsedDays <= 35)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (elapsedDays >= 36 && elapsedDays <= 42)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (elapsedDays >= 43 && elapsedDays <= 49)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (elapsedDays >= 50 && elapsedDays <= 56)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            case 11:
                                if (elapsedDays >= 57)
                                {
                                    poRelVsPRDelDateDt.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = poRelVsPRDelDateDt.Copy();
                    DataViewerUtils.DataLoaded = true;

                    poRelVsPRDelDateDt.Rows.Clear();
                    poRelVsPRDelDateDt = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        public static class Other
        {
            private static DataTable prsCreated;
            private static DataTable prReleased;
            private static DataTable totalSpend;
            private static DataTable prVsPOValue;
            private static DataTable hotJobPRs;


            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrsCreated(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllData();
                    prsCreated = new DataTable();
                    prsCreated = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        string[] strReqDate = (dr["Requisn Date"].ToString()).Split('/');
                        int reqDateYear = int.Parse(strReqDate[2]);
                        int reqDateMonth = int.Parse(strReqDate[0].TrimStart('0'));
                        int reqDateDay = int.Parse(strReqDate[1].TrimStart('0'));

                        DateTime prReqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);

                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (prReqDate - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                prsCreated.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    prsCreated.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prsCreated.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prsCreated.Rows.Clear();
                    prsCreated = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrsReleased(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetPr2ndLevelRelease();
                    prReleased = new DataTable();
                    prReleased = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        #region EVASO_BUT_NOT_FULLY_RELEASED_CHECK

                        string[] strPrFullyRelDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                        int prFullyRelYear = int.Parse(strPrFullyRelDate[2]);
                        int prFullyRelMonth = int.Parse(strPrFullyRelDate[0]);
                        int prFullyRelDay = int.Parse(strPrFullyRelDate[1]);


                        if (prFullyRelYear == 0 && prFullyRelMonth == 0 && prFullyRelDay == 0)
                        {
                            // This PR line or PR in general might have been delted
                            continue;
                        }


                        #endregion

                        DateTime prFullyRelDt = new DateTime(prFullyRelYear, prFullyRelMonth, prFullyRelDay);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (prFullyRelDt - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                prReleased.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    prReleased.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prReleased.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prReleased.Rows.Clear();
                    prReleased = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }




            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadTotalSpend(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    totalSpend = new DataTable();
                    totalSpend = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                        int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                        int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                        DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (poCreateDate - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                totalSpend.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    totalSpend.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = totalSpend.Copy();
                    DataViewerUtils.DataLoaded = true;

                    totalSpend.Rows.Clear();
                    totalSpend = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadPrVsPoValue(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllPOs();
                    prVsPOValue = new DataTable();
                    prVsPOValue = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        string[] strPoCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                        int poCreateDtYear = int.Parse(strPoCreateDt[2]);
                        int poCreateDtMonth = int.Parse(strPoCreateDt[0].TrimStart('0'));
                        int poCreateDtDay = int.Parse(strPoCreateDt[1].TrimStart('0'));

                        DateTime poCreateDate = new DateTime(poCreateDtYear, poCreateDtMonth, poCreateDtDay);

                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (poCreateDate - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                prVsPOValue.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    prVsPOValue.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = prVsPOValue.Copy();
                    DataViewerUtils.DataLoaded = true;

                    prVsPOValue.Rows.Clear();
                    prVsPOValue = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



            /// <summary>
            /// Loads the data into a datagrid view in the dataViewer UI depending on the button clicked in the template or the cell clicked in the overall page.
            /// </summary>
            /// <param name="tag">The tag of the button that was clicked on the template or the column number that was clicked on the overall DataGridView.</param>
            public static void LoadHotJobPrs(int tag)
            {
                try
                {
                    dt = KpiManager.KpiQueries.GetAllData();
                    hotJobPRs = new DataTable();
                    hotJobPRs = dt.Clone();



                    foreach (DataRow dr in dt.Rows)
                    {
                        //Check if the datarow meets the conditions of any applied filters.
                        if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                        {
                            // This datarow dos not meet the conditions of the filters applied.
                            continue;
                        }

                        if (dr["Purch# Group"].ToString() != "UHJ")
                            continue;

                        string[] strPrReqDt = (dr["Requisn Date"].ToString()).Split('/');
                        int reqDateYear = int.Parse(strPrReqDt[2]);
                        int reqDateMonth = int.Parse(strPrReqDt[0].TrimStart('0'));
                        int reqDateDay = int.Parse(strPrReqDt[1].TrimStart('0'));

                        DateTime reqDate = new DateTime(reqDateYear, reqDateMonth, reqDateDay);
                        DateTime today = DateTime.Now.Date;
                        double elapsedDays = (reqDate - today).TotalDays;
                        double weeks = Math.Floor(elapsedDays / 7);

                        switch (tag)
                        {
                            case 0:
                                hotJobPRs.ImportRow(dr);
                                break;
                            case 1:
                                if (weeks >= 0)
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 2:
                                if (weeks >= (-1) && weeks < 0)
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 3:
                                if (weeks >= (-2) && weeks < (-1))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 4:
                                if (weeks >= (-3) && weeks < (-2))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 5:
                                if (weeks >= (-4) && weeks < (-3))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 6:
                                if (weeks >= (-5) && weeks < (-4))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 7:
                                if (weeks >= (-6) && weeks < (-5))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 8:
                                if (weeks >= (-7) && weeks < (-6))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 9:
                                if (weeks >= (-8) && weeks < (-7))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            case 10:
                                if (weeks < (-8))
                                {
                                    hotJobPRs.ImportRow(dr);
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                    DataViewerUtils.Data = hotJobPRs.Copy();
                    DataViewerUtils.DataLoaded = true;

                    hotJobPRs.Rows.Clear();
                    hotJobPRs = null;
                    dt.Rows.Clear();
                    dt = null;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
