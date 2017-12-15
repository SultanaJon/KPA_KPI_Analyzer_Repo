using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace KPA_KPI_Analyzer.Overall_Data.KPA_Sections
{
    public class Hot_Jobs
    {
        public PRs_Not_On_PO prsNotOnPO;
        public No_Confirmation noConfirmation;
        public LateToConfirmed lateToConfirmed;
        private double totalDays = 0;
        private DataTable dt;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;





        // Default Constructor
        public Hot_Jobs()
        {
            prsNotOnPO = new PRs_Not_On_PO();
            noConfirmation = new No_Confirmation();
            lateToConfirmed = new LateToConfirmed();
        }





        public string Name { get { return "Hot Jobs"; } }


        public enum CategorNames
        {
            PrsNotOnPo,
            NoConfirmation,
            LateToConfirmed
        }

        public string[] categoryNames =
        {
            "PRs (Not on PO) - Hot Jobs Only",
            "No Confirmations - Hot Jobs Only",
            "Late to Confirmed - Hot Jobs Only"
        };





        /// <summary>
        /// Loads the data for the specific KPA
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PRs (Not on PO) - Hot Jobs Only
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.HotJobsQueries.GetPrsNotOnPo() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
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

                    DateTime secLvlRelDt = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - secLvlRelDt).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    prsNotOnPO.data.Total++;

                    if (elapsedDays <= 0)
                    {
                        prsNotOnPO.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        prsNotOnPO.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        prsNotOnPO.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prsNotOnPO.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prsNotOnPO.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        prsNotOnPO.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        prsNotOnPO.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    prsNotOnPO.data.Average = Math.Round(totalDays / prsNotOnPO.data.Total, 2);
                    if (double.IsNaN(prsNotOnPO.data.Average))
                        prsNotOnPO.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    prsNotOnPO.data.Average = 0;
                }

                totalDays = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // No Confirmations - Hot Jobs Only
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.HotJobsQueries.GetNoConfirmations() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
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



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Late To Confirmed
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.HotJobsQueries.GetLateToConfirmed() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);
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

                    string[] strDate = (dr["Latest Conf#Date"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime delConfDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;

                    if (!(delConfDate < today))
                        continue;


                    double elapsedDays = (today - delConfDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    lateToConfirmed.data.Total++;

                    if (elapsedDays <= 0)
                    {
                        lateToConfirmed.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        lateToConfirmed.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        lateToConfirmed.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        lateToConfirmed.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        lateToConfirmed.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        lateToConfirmed.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        lateToConfirmed.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    lateToConfirmed.data.Average = Math.Round(totalDays / lateToConfirmed.data.Total, 2);
                    if (double.IsNaN(lateToConfirmed.data.Average))
                        lateToConfirmed.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    lateToConfirmed.data.Average = 0;
                }



                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Hot Jobs Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class PRs_Not_On_PO
    {
        public TempOne data;

        public PRs_Not_On_PO()
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




    public class LateToConfirmed
    {
        public TempOne data;


        public LateToConfirmed()
        {
            data = new TempOne();
        }
    }
}
