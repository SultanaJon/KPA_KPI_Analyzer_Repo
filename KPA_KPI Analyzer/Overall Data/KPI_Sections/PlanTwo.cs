using DAL;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;
using DAL.Exceptions;

namespace KPA_KPI_Analyzer.Overall_Data.KPI_Sections
{
    public class PlanTwo
    {
        public MaterialDueOrigPlannedDate materialDueOrigPlanDate;
        public MaterialDueFinalPlanDate materialDueFinalPlanDate;
        private double totalDays = 0;

        // Default Constructor
        public PlanTwo()
        {
            materialDueOrigPlanDate = new MaterialDueOrigPlannedDate();
            materialDueFinalPlanDate = new MaterialDueFinalPlanDate();
        }


        public string Name { get { return "Plan II"; } }


        public enum CategoryNames
        {
            materialDueOrigPlanDate,
            materialDueFinalPlanDate
        }


        public string[] categoryNames =
        {
            "Material Due Original Planned Date",
            "Material Due Final Planned Date"
        };





        /// <summary>
        /// Loads the data of a specific KPI
        /// </summary>
        /// <param name="SelectedCountry"></param>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Material Due Original Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseManager.pr2ndLvlRelDateDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }



                    string[] strOrigPlanDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int origPlanYear = int.Parse(strOrigPlanDate[2]);
                    int origPlanMonth = int.Parse(strOrigPlanDate[0]);
                    int origPlanDay = int.Parse(strOrigPlanDate[1]);

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
                    DateTime origPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                    double elapsedDays = (origPlanDate - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;



                    materialDueOrigPlanDate.data.Total++;



                    if (elapsedDays <= 0)
                    {
                        materialDueOrigPlanDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        materialDueOrigPlanDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        materialDueOrigPlanDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        materialDueOrigPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        materialDueOrigPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        materialDueOrigPlanDate.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        materialDueOrigPlanDate.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        materialDueOrigPlanDate.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        materialDueOrigPlanDate.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        materialDueOrigPlanDate.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        materialDueOrigPlanDate.data.GreaterThanEqualFiftySeven++;
                    }
                }



                try
                {
                    materialDueOrigPlanDate.data.Average = Math.Round(totalDays / materialDueOrigPlanDate.data.Total, 2);
                    if (double.IsNaN(materialDueOrigPlanDate.data.Average))
                        materialDueOrigPlanDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    materialDueOrigPlanDate.data.Average = 0;
                }

                totalDays = 0;




                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Material Due Final Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseManager.prsOnPOsDt.Rows)
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

                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int origPlanYear = int.Parse(strCurrPlanDate[2]);
                    int origPlanMonth = int.Parse(strCurrPlanDate[0]);
                    int origPlanDay = int.Parse(strCurrPlanDate[1]);

                    if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                    {
                        string[] strNewCurrPlanDelDate = (dr["Delivery Date"].ToString()).Split('/');
                        origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                        origPlanMonth = int.Parse(strNewCurrPlanDelDate[0]);
                        origPlanDay = int.Parse(strNewCurrPlanDelDate[1]);

                        if (origPlanYear == 0 && origPlanMonth == 0 && origPlanDay == 0)
                        {
                            string[] strNewCurrPlanPrDelDate = (dr["PR Delivery Date"].ToString()).Split('/');
                            origPlanYear = int.Parse(strNewCurrPlanPrDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanPrDelDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strNewCurrPlanPrDelDate[1].TrimStart('0'));
                        }
                        else
                        {
                            origPlanYear = int.Parse(strNewCurrPlanDelDate[2]);
                            origPlanMonth = int.Parse(strNewCurrPlanDelDate[0].TrimStart('0'));
                            origPlanDay = int.Parse(strNewCurrPlanDelDate[1].TrimStart('0'));
                        }
                    }
                    else
                    {
                        origPlanYear = int.Parse(strCurrPlanDate[2]);
                        origPlanMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        origPlanDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime currPlanDate = new DateTime(origPlanYear, origPlanMonth, origPlanDay);

                    double elapsedDays = (currPlanDate - prFullyRelDt).TotalDays;
                    totalDays += elapsedDays;


                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    elapsedDays = (int)elapsedDays;



                    materialDueFinalPlanDate.data.Total++;




                    if (elapsedDays <= 0)
                    {
                        materialDueFinalPlanDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        materialDueFinalPlanDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        materialDueFinalPlanDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        materialDueFinalPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        materialDueFinalPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        materialDueFinalPlanDate.data.TwentyTwo_TwentyEight++;
                    }
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        materialDueFinalPlanDate.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        materialDueFinalPlanDate.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        materialDueFinalPlanDate.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50 && elapsedDays <= 56)
                    {
                        materialDueFinalPlanDate.data.Fifty_FiftySix++;
                    }
                    else // elapsed days is >= 57
                    {
                        materialDueFinalPlanDate.data.GreaterThanEqualFiftySeven++;
                    }
                }



                try
                {
                    materialDueFinalPlanDate.data.Average = Math.Round(totalDays / materialDueFinalPlanDate.data.Total, 2);
                    if (double.IsNaN(materialDueFinalPlanDate.data.Average))
                        materialDueFinalPlanDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    materialDueFinalPlanDate.data.Average = 0;
                }

                totalDays = 0;
                DatabaseManager.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Plan Two Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    public class MaterialDueOrigPlannedDate
    {
        public TempFour data;

        public MaterialDueOrigPlannedDate()
        {
            data = new TempFour();
        }
    }


    public class MaterialDueFinalPlanDate
    {
        public TempFour data;

        public MaterialDueFinalPlanDate()
        {
            data = new TempFour();
        }
    }
}
