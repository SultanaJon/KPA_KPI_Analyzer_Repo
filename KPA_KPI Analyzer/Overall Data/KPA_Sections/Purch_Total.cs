﻿using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Overall_Data.KPA_Sections
{
    public class Purch_Total
    {
        public PR_Rel_Conf_Entry prRelConfEntry;
        private double totalDays = 0;
        private DataTable dt;
        private OleDbCommand cmd;
        private OleDbDataAdapter da;


        // Default Constructor
        public Purch_Total()
        {
            prRelConfEntry = new PR_Rel_Conf_Entry();
        }



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
                // PR Release to Confirmation Entry
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                cmd = new OleDbCommand(Database.QueryManager.KpaQueries.PurchTotalQueries.GetPrReleaseToConfirmationEntry() + Filters.FilterData.FilterQuery, DatabaseUtils.DatabaseConnection);

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


                    string[] strDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int year = int.Parse(strDate[2]);
                    int month = int.Parse(strDate[0].TrimStart('0'));
                    int day = int.Parse(strDate[1].TrimStart('0'));

                    DateTime date = new DateTime(year, month, day);

                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (today - date).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    prRelConfEntry.data.Total++;



                    if (elapsedDays <= 0)
                    {
                        prRelConfEntry.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        prRelConfEntry.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        prRelConfEntry.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prRelConfEntry.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prRelConfEntry.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        prRelConfEntry.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        prRelConfEntry.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    prRelConfEntry.data.Average = Math.Round(totalDays / prRelConfEntry.data.Total, 2);
                    if (double.IsNaN(prRelConfEntry.data.Average))
                        prRelConfEntry.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    prRelConfEntry.data.Average = 0;
                }

                totalDays = 0;

                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Purch Total Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
            }
            finally
            {
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
    public class PR_Rel_Conf_Entry
    {
        public TempOne data;

        public PR_Rel_Conf_Entry()
        {
            data = new TempOne();
        }
    }
}