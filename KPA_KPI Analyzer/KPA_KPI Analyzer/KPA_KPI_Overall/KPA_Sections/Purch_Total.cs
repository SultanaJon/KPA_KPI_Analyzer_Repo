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
    public class Purch_Total
    {
        public PR_Rel_Conf_Entry prRelConfEntry;
        private double totalDays = 0;

        // Default Constructor
        public Purch_Total()
        {
            prRelConfEntry = new PR_Rel_Conf_Entry();
        }





        /// <summary>
        /// Loads the data for the specific KPA
        /// </summary>
        /// <param name="Overall.SelectedCountry"></param>
        public void LoadData()
        {
            try
            {

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR Release to Confirmation Entry
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                DataTable dt = new DataTable();
                OleDbCommand cmd;
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_PurchTotal_PRRelConfEntry] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_PurchTotal_PRRelConfEntry] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                prRelConfEntry.data.Total = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {
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
                }
                catch (DivideByZeroException)
                {
                    prRelConfEntry.data.Average = 0;
                }

                totalDays = 0;

                PRPO_DB_Utils.CompletedDataLoads++;
                MethodInvoker del = delegate
                {
                    PRPO_DB_Utils.UpdateDataLoadProgress();
                };
                del.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Purch Total Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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