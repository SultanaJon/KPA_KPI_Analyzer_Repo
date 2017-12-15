using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Overall_Data.KPA_Sections
{
    public class Excess_Stock_Open_Order
    {
        public PRs_Aging_Not_Rel prsAgingNotRel;
        public PRs_Aging_Rel prsAgingRel;
        public PoCreationThruDelivery PoCreationThruDeliv;
        private double totalDays = 0;
        private DataTable dt;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;



        // Default Constructor
        public Excess_Stock_Open_Order()
        {
            prsAgingNotRel = new PRs_Aging_Not_Rel();
            prsAgingRel = new PRs_Aging_Rel();
            PoCreationThruDeliv = new PoCreationThruDelivery();
        }


        public string Name { get { return "Excess Stock - Open Orders"; } }


        public enum CategorNames
        {
            PrsAgingNotReleased,
            PrsAgingReleased,
            PoCreationThruDelivery
        }

        public string[] categoryNames =
        {
            "Prs Aging (Not Released)",
            "PRs Aging (Released)",
            "PO Creation Thru Delivery"
        };




        /// <summary>
        /// Loads the data of the specific KPA.
        /// </summary>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Prs Aging Not Released
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockOpenOrdersQueries.GetPrsAgingNotReleased() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
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


                    string[] reqCreationDate = (dr["Requisn Date"].ToString()).Split('/');
                    int year = int.Parse(reqCreationDate[2]);
                    int month = int.Parse(reqCreationDate[0].TrimStart('0'));
                    int day = int.Parse(reqCreationDate[1].TrimStart('0'));

                    DateTime reqDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - reqDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    prsAgingNotRel.data.Total++;

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
                    if (double.IsNaN(prsAgingNotRel.data.Average))
                        prsAgingNotRel.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    prsAgingNotRel.data.Average = 0;
                }

                totalDays = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Prs Aging Released
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockOpenOrdersQueries.GetPrsAgingReleased() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
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


                    string[] strDate = (dr["PR Fully Rel Date"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
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
                }



                totalDays = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Po Creation Thru Delivery
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.ExcessStockOpenOrdersQueries.GetPoCreationThruDelivery() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
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

                    PoCreationThruDeliv.data.Total++;


                    if (elapsedDays <= 0)
                    {
                        PoCreationThruDeliv.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        PoCreationThruDeliv.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        PoCreationThruDeliv.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        PoCreationThruDeliv.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        PoCreationThruDeliv.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        PoCreationThruDeliv.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        PoCreationThruDeliv.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    PoCreationThruDeliv.data.Average = Math.Round(totalDays / PoCreationThruDeliv.data.Total, 2);
                    if (double.IsNaN(PoCreationThruDeliv.data.Average))
                        PoCreationThruDeliv.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    PoCreationThruDeliv.data.Average = 0;
                }

                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Excess Stock - Stock Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }





    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PRs_Aging_Not_Rel
    {
        public TempOne data;

        public PRs_Aging_Not_Rel()
        {
            data = new TempOne();
        }
    }






    public class PRs_Aging_Rel
    {
        public TempOne data;

        public PRs_Aging_Rel()
        {
            data = new TempOne();
        }
    }


    public class PoCreationThruDelivery
    {
        public TempOne data;

        public PoCreationThruDelivery()
        {
            data = new TempOne();
        }
    }
}
