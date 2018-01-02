using DataAccessLibrary;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DataAccessLibrary.Exceptions;



namespace KPA_KPI_Analyzer.Overall_Data.KPA_Sections
{
    public class Purch_Sub
    {
        public PR_Rel_PO_Rel prRelToPORel;
        public PO_Create_Conf_Entry POCreatToConfEntry;
        private double totalDays = 0;
        private DataTable dt;



  
        // Default Constructor
        public Purch_Sub()
        {
            prRelToPORel = new PR_Rel_PO_Rel();
            POCreatToConfEntry = new PO_Create_Conf_Entry();
        }




        public string Name { get { return "Purch Sub"; } }


        public enum CategorNames
        {
            PrReleasePoRelease,
            PoCreationConfirmationEntry,
        }

        public string[] categoryNames =
        {
            "PR Release to PO Release",
            "PO Creation to Confirmation Entry",
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
                // PR Release to PO Release
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = KpaUtils.PurchSubQueries.GetPrReleaseToPoRelease();

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

                    prRelToPORel.data.Total++;



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
                    if (double.IsNaN(prRelToPORel.data.Average))
                        prRelToPORel.data.Average = 0;
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
                dt = KpaUtils.PurchSubQueries.GetPoCreationToConfirmationEntry();



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

                    POCreatToConfEntry.data.Total++;


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
                    if (double.IsNaN(POCreatToConfEntry.data.Average))
                        POCreatToConfEntry.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    POCreatToConfEntry.data.Average = 0;
                }

                DatabaseManager.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPA -> Purch Sub Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
