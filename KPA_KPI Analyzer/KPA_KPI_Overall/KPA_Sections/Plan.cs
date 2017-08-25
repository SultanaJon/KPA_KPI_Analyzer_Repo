using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.FilterFeeature;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPA_Sections
{
    public class Plan
    {
        public PRs_Aging_NotRel prsAgingNotRel;
        public MaterialDueDate matDueDate;
        private double totalDays = 0;

        // Default Constructor
        public Plan()
        {
            prsAgingNotRel = new PRs_Aging_NotRel();
            matDueDate = new MaterialDueDate();
        }







        /// <summary>
        /// Loads the data of a specific KPA
        /// </summary>
        /// <param name="Overall.SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PRs Aging (Not Released)
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                DataTable dt = new DataTable();
                OleDbCommand cmd;
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Plan_PRsAgingNotRel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Plan_PRsAgingNotRel] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach(DataRow dr in dt.Rows)
                {
                    // The user wants to filter by PR date range
                    if(Filters.PrDateRangeFilterAdded)
                    {
                        string[] strPrDate = (dr["Requisn Date"].ToString().Split('/'));
                        int prYear = int.Parse(strPrDate[2]);
                        int prMonth = int.Parse(strPrDate[0].TrimStart('0'));
                        int prDay = int.Parse(strPrDate[1].TrimStart('0'));

                        DateTime prDate = new DateTime(prYear, prMonth, prDay);

                        if (DateTime.Compare(prDate, Filters.PrFromDate) < 0)
                        {
                            continue; // The PR date is not within the filtered PR date range
                        }
                        else
                        {
                            if (DateTime.Compare(prDate, Filters.PrToDate) > 0)
                            {
                                continue; // The PR date is not within the filtered PR date range
                            }
                        }
                    }



                    // The user wants to filter by PO date range
                    if (Filters.PoDateRangeFilterAdded)
                    {
                        string[] strPoDate = (dr["PO Date"].ToString().Split('/'));
                        int poYear = int.Parse(strPoDate[2]);
                        int poMonth = int.Parse(strPoDate[0]);
                        int poDay = int.Parse(strPoDate[1]);

                        if (poYear == 0 && poMonth == 0 && poDay == 0)
                        {
                            continue;
                        }
                        else
                        {
                            poYear = int.Parse(strPoDate[2]);
                            poMonth = int.Parse(strPoDate[0].TrimStart('0'));
                            poDay = int.Parse(strPoDate[1].TrimStart('0'));
                        }
                        

                        DateTime poDate = new DateTime(poYear, poMonth, poDay);

                        if (DateTime.Compare(poDate, Filters.PoFromDate) < 0)
                        {
                            continue; // The PR date is not within the filtered PR date range
                        }
                        else
                        {
                            if (DateTime.Compare(poDate, Filters.PoToDate) > 0)
                            {
                                continue; // The PR date is not within the filtered PR date range
                            }
                        }
                    }

                    prsAgingNotRel.data.Total = dt.Rows.Count;

                    string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                    int year = int.Parse(reqCreationDate[2]);
                    int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                    int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                    DateTime reqDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - reqDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;



                    if (elapsedDays <= 0)
                    {
                        prsAgingNotRel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        prsAgingNotRel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        prsAgingNotRel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prsAgingNotRel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prsAgingNotRel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        prsAgingNotRel.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        prsAgingNotRel.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    prsAgingNotRel.data.Average = Math.Round(totalDays / prsAgingNotRel.data.Total, 2);
                }
                catch(DivideByZeroException)
                {
                    prsAgingNotRel.data.Average = 0;
                }
                totalDays = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Material Due
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Plan_MaterialDue] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_Plan_MaterialDue] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    // The user wants to filter by PR date range
                    if(Filters.PrDateRangeFilterAdded)
                    {
                        string[] strPrDate = (dr["Requisn Date"].ToString().Split('/'));
                        int prYear = int.Parse(strPrDate[2]);
                        int prMonth = int.Parse(strPrDate[0].TrimStart('0'));
                        int prDay = int.Parse(strPrDate[1].TrimStart('0'));

                        DateTime prDate = new DateTime(prYear, prMonth, prDay);

                        if (DateTime.Compare(prDate, Filters.PrFromDate) < 0)
                        {
                            continue; // The PR date is not within the filtered PR date range
                        }
                        else
                        {
                            if (DateTime.Compare(prDate, Filters.PrToDate) > 0)
                            {
                                continue; // The PR date is not within the filtered PR date range
                            }
                        }
                    }



                    // The user wants to filter by PO date range
                    if (Filters.PoDateRangeFilterAdded)
                    {
                        string[] strPoDate = (dr["PO Date"].ToString().Split('/'));
                        int poYear = int.Parse(strPoDate[2]);
                        int poMonth = int.Parse(strPoDate[0]);
                        int poDay = int.Parse(strPoDate[1]);

                        if (poYear == 0 && poMonth == 0 && poDay == 0)
                        {
                            continue;
                        }
                        else
                        {
                            poYear = int.Parse(strPoDate[2]);
                            poMonth = int.Parse(strPoDate[0].TrimStart('0'));
                            poDay = int.Parse(strPoDate[1].TrimStart('0'));
                        }
                        

                        DateTime poDate = new DateTime(poYear, poMonth, poDay);

                        if (DateTime.Compare(poDate, Filters.PoFromDate) < 0)
                        {
                            continue; // The PR date is not within the filtered PR date range
                        }
                        else
                        {
                            if (DateTime.Compare(poDate, Filters.PoToDate) > 0)
                            {
                                continue; // The PR date is not within the filtered PR date range
                            }
                        }
                    }

                    matDueDate.data.Total++;


                    string[] strCurrReqDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int year = int.Parse(strCurrReqDate[2]);
                    int month = int.Parse(strCurrReqDate[0].TrimStart('0'));
                    int day = int.Parse(strCurrReqDate[1].TrimStart('0'));

                    DateTime currReqDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (currReqDate - today).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    if (elapsedDays <= 0)
                    {
                        matDueDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        matDueDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        matDueDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        matDueDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        matDueDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        matDueDate.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        matDueDate.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    matDueDate.data.Average = Math.Round(totalDays / matDueDate.data.Total, 2);
                }
                catch (DivideByZeroException)
                {
                    matDueDate.data.Average = 0;
                }

                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Plan Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PRs_Aging_NotRel
    {
        public TempOne data;

        public PRs_Aging_NotRel()
        {
            data = new TempOne();
        }
    }






    public class MaterialDueDate
    {
        public TempOne data;

        public MaterialDueDate()
        {
            data = new TempOne();
        }
    }
}
