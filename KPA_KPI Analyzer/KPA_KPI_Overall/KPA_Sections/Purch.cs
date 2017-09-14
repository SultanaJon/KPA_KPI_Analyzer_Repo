using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using KPA_KPI_Analyzer.Diagnostics;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class Purch
    {
        public PRs_Aging_Released prsAgingRel;
        public PO_First_Rel poFirstRel;
        public PO_Prev_Rel poPrevRel;
        public No_Confirmation noConfirmation;
        private double totalDays = 0;




        public delegate void ReportProgressHandler(string mesage);
        public event ReportProgressHandler ReportPogress;




        // Default Constructor
        public Purch()
        {
            prsAgingRel = new PRs_Aging_Released();
            poFirstRel = new PO_First_Rel();
            poPrevRel = new PO_Prev_Rel();
            noConfirmation = new No_Confirmation();
        }






        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //
        //  The below classes act as a specific KPA category that fall under a specific KPA section.
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public class PRs_Aging_Released
        {
            public TempOne data;

            public PRs_Aging_Released()
            {
                data = new TempOne();
            }
        }






        public class PO_First_Rel
        {
            public TempOne data;

            public PO_First_Rel()
            {
                data = new TempOne();
            }
        }





        public class PO_Prev_Rel
        {
            public TempOne data;

            public PO_Prev_Rel()
            {
                data = new TempOne();
            }
        }






        public class No_Confirmation
        {
            public TempOne data;

            public No_Confirmation()
            {
                data = new TempOne();
            }
        }







        /// <summary>
        /// Loads the specific KPA Data
        /// </summary>
        /// <param name="Overall.SelectedCountry"></param>
        public void LoadData()
        {
            try
            {

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PRs Aging Released
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                DataTable dt = new DataTable();
                OleDbCommand cmd;
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Purch_PRsAgingRel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Purch_PRsAgingRel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
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


                    prsAgingRel.data.Total++;


                    string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    if (elapsedDays <= 0)
                    {
                        prsAgingRel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        prsAgingRel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        prsAgingRel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prsAgingRel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prsAgingRel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        prsAgingRel.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        prsAgingRel.data.TwentyNinePlus++;
                    }
                }


                try
                {
                    prsAgingRel.data.Average = Math.Round(totalDays / prsAgingRel.data.Total, 2);
                    if (double.IsNaN(prsAgingRel.data.Average))
                        prsAgingRel.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    prsAgingRel.data.Average = 0;
                }
                totalDays = 0;





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO First Release
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Purch_POFirstRelease] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Purch_POFirstRelease] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
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



                    poFirstRel.data.Total++;



                    string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    if (elapsedDays <= 0)
                    {
                        poFirstRel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poFirstRel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poFirstRel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poFirstRel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poFirstRel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poFirstRel.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        poFirstRel.data.TwentyNinePlus++;
                    }
                }


                try
                {
                    poFirstRel.data.Average = Math.Round(totalDays / poFirstRel.data.Total, 2);
                    if (double.IsNaN(poFirstRel.data.Average))
                        poFirstRel.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poFirstRel.data.Average = 0;
                }
                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Prev Release
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Purch_POPrevRelease] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Purch_POPrevRelease] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                
                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
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



                    poPrevRel.data.Total++;


                    string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    if (elapsedDays <= 0)
                    {
                        poPrevRel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poPrevRel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poPrevRel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poPrevRel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poPrevRel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poPrevRel.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        poPrevRel.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    poPrevRel.data.Average = Math.Round(totalDays / poPrevRel.data.Total, 2);
                    if (double.IsNaN(poPrevRel.data.Average))
                        poPrevRel.data.Average = 0;
                }
                catch
                {
                    poPrevRel.data.Average = 0;
                }

                totalDays = 0;





                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // No Confirmation
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Purch_NoConfirmation] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Purch_NoConfirmation] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
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


                    noConfirmation.data.Total++;


                    string[] strDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        noConfirmation.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        noConfirmation.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        noConfirmation.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        noConfirmation.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        noConfirmation.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        noConfirmation.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        noConfirmation.data.TwentyNinePlus++;
                    }
                }


                try
                {
                    noConfirmation.data.Average = Math.Round(totalDays / noConfirmation.data.Total, 2);
                    if (double.IsNaN(noConfirmation.data.Average))
                        noConfirmation.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    noConfirmation.data.Average = 0;
                }

                totalDays = 0;

                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
                ReportPogress("KPA - Purch Completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Purch Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
