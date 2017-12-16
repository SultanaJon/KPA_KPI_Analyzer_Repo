using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Overall_Data.KPA_Sections
{
    public class Purch
    {
        public PRs_Aging_Released prsAgingRel;
        public PO_First_Rel poFirstRel;
        public PO_Prev_Rel poPrevRel;
        public No_Confirmation noConfirmation;
        private double totalDays = 0;
        private DataTable dt;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;




        // Default Constructor
        public Purch()
        {
            prsAgingRel = new PRs_Aging_Released();
            poFirstRel = new PO_First_Rel();
            poPrevRel = new PO_Prev_Rel();
            noConfirmation = new No_Confirmation();
        }





        public string Name { get { return "Purch"; } }


        public enum CategorNames
        {
            PRsAgingReleased,
            POFirstRelease,
            POPrevRelease,
            NoConfirmation
        }

        public string[] categoryNames =
        {
            "PRs Aging (Released)",
            "PO First Release",
            "PO Prev Release",
            "No Confirmation"
        };







        /// <summary>
        /// Loads the specific KPA Data
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PRs Aging Released
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchQueries.GetPrsAgingReleased() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


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
                    double elapsedDays = (today - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    prsAgingRel.data.Total++;



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
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchQueries.GetPoFirstRelease() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    poFirstRel.data.Total++;


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
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchQueries.GetPoPrevRelease() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    string[] strDate = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    poPrevRel.data.Total++;

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
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchQueries.GetNoConfirmations() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    string[] strDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    noConfirmation.data.Total++;

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


                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Purch Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
            }
            finally
            {
                totalDays = 0;
                dt.Rows.Clear();
                dt = null;
                GC.Collect();
            }
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
    }
}
