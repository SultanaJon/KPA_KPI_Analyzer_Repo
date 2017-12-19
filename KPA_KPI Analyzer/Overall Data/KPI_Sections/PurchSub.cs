using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Overall_Data.KPI_Sections
{
    public class PurchSub
    {
        public PR_Rel_Vs_PO_Rel prRelVsPORel;
        public PO_Create_Vs_Conf_Entry poCreateVsConfEntry;
        private double totalDays = 0;






        // Default Constructor
        public PurchSub()
        {
            prRelVsPORel = new PR_Rel_Vs_PO_Rel();
            poCreateVsConfEntry = new PO_Create_Vs_Conf_Entry();
        }





        public string Name { get { return "Purch Sub"; } }


        public enum CategorNames
        {
            prRelVsPORel,
            poCreateVsConfEntry
        }

        public string[] categoryNames =
        {
            "PR Release Date vs PO Release Date",
            "PO Creation Date vs Confirmation Entry Date",
        };



        /// <summary>
        /// Loads the data for the specific KPI
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PR Release vs PO Release
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                foreach (DataRow dr in DatabaseUtils.prsOnPOsDt.Rows)
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

                    if(poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                    {
                        continue;
                    }
                    else
                    {
                        prRelVsPORel.data.Total++;
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
                    double elapsedDays = (poLineFirstRelDate - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        prRelVsPORel.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        prRelVsPORel.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        prRelVsPORel.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        prRelVsPORel.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        prRelVsPORel.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        prRelVsPORel.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        prRelVsPORel.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        prRelVsPORel.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        prRelVsPORel.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        prRelVsPORel.data.Fifty_FiftySix++;
                    }
                    else // elapsed days >= 57
                    {
                        prRelVsPORel.data.GreaterThanEqualFiftySeven++;
                    }
                }

                try
                {
                    prRelVsPORel.data.Average = Math.Round(totalDays / prRelVsPORel.data.Total, 2);
                    if (double.IsNaN(prRelVsPORel.data.Average))
                        prRelVsPORel.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    prRelVsPORel.data.Average = 0;
                }
                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Creation vs Confirmation Entry
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //int tempTotal = 0;
                foreach (DataRow dr in DatabaseUtils.prsOnPOsDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strFirstConfCreateDate = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int poLineFirstConfCreateYear = int.Parse(strFirstConfCreateDate[2]);
                    int poLineFirstConfCreateMonth = int.Parse(strFirstConfCreateDate[0]);
                    int poLineFirstConfCreateDay = int.Parse(strFirstConfCreateDate[1]);

                    if(poLineFirstConfCreateYear == 0 && poLineFirstConfCreateMonth == 0 && poLineFirstConfCreateDay == 0)
                    {
                        poCreateVsConfEntry.data.PercentUnconfTotal++;
                        poCreateVsConfEntry.data.Total++;
                        continue;
                    }
                    else
                    {
                        poLineFirstConfCreateYear = int.Parse(strFirstConfCreateDate[2]);
                        poLineFirstConfCreateMonth = int.Parse(strFirstConfCreateDate[0]);
                        poLineFirstConfCreateDay = int.Parse(strFirstConfCreateDate[1]);
                    }
                    

                    DateTime initialConfCreateDate = new DateTime(poLineFirstConfCreateYear, poLineFirstConfCreateMonth, poLineFirstConfCreateDay);

                    string[] strPOLineCreateDt = (dr["PO Line Creat#DT"].ToString()).Split('/');
                    int poLineCreateYear = int.Parse(strPOLineCreateDt[2]);
                    int poLineCreateMonth = int.Parse(strPOLineCreateDt[0].TrimStart('0'));
                    int poLineCreateDay = int.Parse(strPOLineCreateDt[1].TrimStart('0'));

                    DateTime poLineItemCreateDate = new DateTime(poLineCreateYear, poLineCreateMonth, poLineCreateDay);

                    double elapsedDays = (initialConfCreateDate - poLineItemCreateDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;


                    poCreateVsConfEntry.data.Total++;


                    if (elapsedDays <= 0)
                    {
                        poCreateVsConfEntry.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poCreateVsConfEntry.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poCreateVsConfEntry.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poCreateVsConfEntry.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poCreateVsConfEntry.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poCreateVsConfEntry.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        poCreateVsConfEntry.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        poCreateVsConfEntry.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        poCreateVsConfEntry.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        poCreateVsConfEntry.data.Fifty_FiftySix++;
                    }
                    else // elapsed days >= 57
                    {
                        poCreateVsConfEntry.data.GreaterThanEqualFiftySeven++;
                    }
                }


                try
                {
                    poCreateVsConfEntry.data.Average = Math.Round(totalDays / poCreateVsConfEntry.data.Total, 2);
                    if (double.IsNaN(poCreateVsConfEntry.data.Average))
                        poCreateVsConfEntry.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poCreateVsConfEntry.data.Average = 0;
                }


                try
                {
                    poCreateVsConfEntry.data.PercentUnconf = Math.Round(((double)poCreateVsConfEntry.data.PercentUnconfTotal / (poCreateVsConfEntry.data.Total + poCreateVsConfEntry.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(poCreateVsConfEntry.data.PercentUnconf))
                        poCreateVsConfEntry.data.PercentUnconf = 0;

                    if (double.IsInfinity(poCreateVsConfEntry.data.PercentUnconf))
                        poCreateVsConfEntry.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    poCreateVsConfEntry.data.PercentUnconf = 0;
                }


                totalDays = 0;

                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Sub Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ThreadInteruptedException();
            }
        }
    }







    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //
    //
    //  The below classes act as a specific KPA category that fall under a specific KPA section.
    //
    //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public class PR_Rel_Vs_PO_Rel
    {
        public TempFour data;

        public PR_Rel_Vs_PO_Rel()
        {
            data = new TempFour();
        }
    }






    public class PO_Create_Vs_Conf_Entry
    {
        public TempFour data;

        public PO_Create_Vs_Conf_Entry()
        {
            data = new TempFour();
        }
    }


}
