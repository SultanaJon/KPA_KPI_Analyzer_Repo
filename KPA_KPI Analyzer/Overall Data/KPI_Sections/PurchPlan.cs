using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.Overall_Data.KPI_Sections
{
    public class PurchPlan
    {
        public Po_Rel_vs_PR_Del_Date poRelVsPRDelDate;
        private double totalDays = 0;
        string[] strPoLineFirstRelDate;





        // Default Constructor
        public PurchPlan()
        {
            poRelVsPRDelDate = new Po_Rel_vs_PR_Del_Date();
        }




        public string Name { get { return "Purch Plan"; } }


        public enum CategorNames
        {
            poRelVsPRDelDate,
        }

        public string[] categoryNames =
        {
            "PO Release vs PR Delivery Date",
        };





        /// <summary>
        /// Loads the data for the specifc KPI
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PO Release vs PR Delivery Date
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


                    strPoLineFirstRelDate = (dr["PO Line 1st Rel Dt"].ToString()).Split('/');
                    int poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                    int poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0]);
                    int poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1]);

                    if (poLineFirstRelYear == 0 && poLineFirstRelMonth == 0 && poLineFirstRelDay == 0)
                    {
                        continue;
                    }
                    else
                    {
                        poRelVsPRDelDate.data.Total++;
                        poLineFirstRelYear = int.Parse(strPoLineFirstRelDate[2]);
                        poLineFirstRelMonth = int.Parse(strPoLineFirstRelDate[0]);
                        poLineFirstRelDay = int.Parse(strPoLineFirstRelDate[1]);
                    }

                    DateTime poLineFirstRelDate = new DateTime(poLineFirstRelYear, poLineFirstRelMonth, poLineFirstRelDay);

                    string[] strPRDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int prDelYear = int.Parse(strPRDelDate[2]);
                    int prDelMonth = int.Parse(strPRDelDate[0]);
                    int prDelDay = int.Parse(strPRDelDate[1]);

                    DateTime prDelDate = new DateTime(prDelYear, prDelMonth, prDelDay);
                    double elapsedDays = (prDelDate - poLineFirstRelDate).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    if (elapsedDays <= 0)
                    {
                        poRelVsPRDelDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        poRelVsPRDelDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        poRelVsPRDelDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        poRelVsPRDelDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        poRelVsPRDelDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        poRelVsPRDelDate.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        poRelVsPRDelDate.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        poRelVsPRDelDate.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        poRelVsPRDelDate.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        poRelVsPRDelDate.data.Fifty_FiftySix++;
                    }
                    else // elapsed days >= 57
                    {
                        poRelVsPRDelDate.data.GreaterThanEqualFiftySeven++;
                    }
                }


                try
                {
                    poRelVsPRDelDate.data.Average = Math.Round(totalDays / poRelVsPRDelDate.data.Total, 2);
                    if (double.IsNaN(poRelVsPRDelDate.data.Average))
                        poRelVsPRDelDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    poRelVsPRDelDate.data.Average = 0;
                }
                
                totalDays = 0;

                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Purch Plan Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class Po_Rel_vs_PR_Del_Date
    {
        public TempFour data;

        public Po_Rel_vs_PR_Del_Date()
        {
            data = new TempFour();
        }
    }
}
