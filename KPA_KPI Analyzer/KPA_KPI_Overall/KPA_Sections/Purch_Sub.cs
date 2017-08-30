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
    public class Purch_Sub
    {
        public PR_Rel_PO_Rel prRelToPORel;
        public PO_Create_Conf_Entry POCreatToConfEntry;
        private double totalDays = 0;

        // Default Constructor
        public Purch_Sub()
        {
            prRelToPORel = new PR_Rel_PO_Rel();
            POCreatToConfEntry = new PO_Create_Conf_Entry();
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
                // PR Release to PO Release
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                DataTable dt = new DataTable();
                OleDbCommand cmd;
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_PurchSub_PRReleasePORelease] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_PurchSub_PRReleasePORelease] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);

                prRelToPORel.data.Total = dt.Rows.Count;

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
                        prRelToPORel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        prRelToPORel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        prRelToPORel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prRelToPORel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prRelToPORel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        prRelToPORel.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        prRelToPORel.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    prRelToPORel.data.Average = Math.Round(totalDays / prRelToPORel.data.Total, 2);
                }
                catch (DivideByZeroException)
                {
                    prRelToPORel.data.Average = 0;
                }
                totalDays = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Creation Date to Confirmation Entry
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = new DataTable();
                if (Overall.SelectedCountry == AccessInfo.MainTables.US_PRPO)
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_PurchSub_POCreationCOnfEntry] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);
                else
                    cmd = new OleDbCommand(PRPOCommands.Queries[(int)PRPOCommands.DatabaseTables.TableNames.KPA_PurchSub_POCreationCOnfEntry] + Filters.FilterQuery, PRPO_DB_Utils.DatabaseConnection);

                da = new OleDbDataAdapter(cmd);
                da.Fill(dt);


                POCreatToConfEntry.data.Total = dt.Rows.Count;

                foreach (DataRow dr in dt.Rows)
                {
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
                        POCreatToConfEntry.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        POCreatToConfEntry.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        POCreatToConfEntry.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        POCreatToConfEntry.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        POCreatToConfEntry.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        POCreatToConfEntry.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        POCreatToConfEntry.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    POCreatToConfEntry.data.Average = Math.Round(totalDays / POCreatToConfEntry.data.Total, 2);
                }
                catch (DivideByZeroException)
                {
                    POCreatToConfEntry.data.Average = 0;
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
                MessageBox.Show(ex.StackTrace, "KPA -> Purch Sub Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }






    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PR_Rel_PO_Rel
    {
        public TempOne data;

        public PR_Rel_PO_Rel()
        {
            data = new TempOne();
        }
    }





    public class PO_Create_Conf_Entry
    {
        public TempOne data;

        public PO_Create_Conf_Entry()
        {
            data = new TempOne();
        }
    }
}
