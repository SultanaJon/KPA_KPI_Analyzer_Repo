using DataAccessLibrary;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DAL.Exceptions;

namespace KPA_KPI_Analyzer.Overall_Data.KPA_Sections
{
    public class Plan
    {
        public PRs_Aging_NotRel prsAgingNotRel;
        public MaterialDueDate matDueDate;
        private double totalDays = 0;
        private DataTable dt;



        // Default Constructor
        public Plan()
        {
            prsAgingNotRel = new PRs_Aging_NotRel();
            matDueDate = new MaterialDueDate();
        }





        public string Name { get { return "Plan"; } }



        public enum CategorNames
        {
            PrsAgingNotReleased,
            MaterialDue
        }


        public string[] categoryNames =
        {
            "PRs Aging (Not Released)",
            "Material Due"
        };





        /// <summary>
        /// Loads the data of a specific KPA
        /// </summary>
        public void LoadData()
        {
            try
            {
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // PRs Aging (Not Released)
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                dt = KpaData.PlanQueries.GetPrsAgingNotReleased();

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
                catch(DivideByZeroException)
                {
                    prsAgingNotRel.data.Average = 0;
                }
                totalDays = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Material Due
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                dt = KpaData.PlanQueries.GetMaterialDue();

                foreach (DataRow dr in dt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strCurrReqDate = (dr["PR Delivery Date"].ToString()).Split('/');
                    int year = int.Parse(strCurrReqDate[2]);
                    int month = int.Parse(strCurrReqDate[0].TrimStart('0'));
                    int day = int.Parse(strCurrReqDate[1].TrimStart('0'));

                    DateTime currReqDate = new DateTime(year, month, day);
                    DateTime today = DateTime.Now.Date;
                    double elapsedDays = (currReqDate - today).TotalDays;
                    totalDays += elapsedDays;
                    elapsedDays = (int)elapsedDays;

                    matDueDate.data.Total++;

                    if (elapsedDays <= 0)
                    {
                        matDueDate.data.LessThanZero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 3)
                    {
                        matDueDate.data.One_Three++;
                    }
                    else if (elapsedDays >= 4 && elapsedDays <= 7)
                    {
                        matDueDate.data.Four_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        matDueDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        matDueDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22 && elapsedDays <= 28)
                    {
                        matDueDate.data.TwentyTwo_TwentyEight++;
                    }
                    else // 29+
                    {
                        matDueDate.data.TwentyNinePlus++;
                    }
                }

                try
                {
                    matDueDate.data.Average = Math.Round(totalDays / matDueDate.data.Total, 2);
                    if (double.IsNaN(matDueDate.data.Average))
                        matDueDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    matDueDate.data.Average = 0;
                }

                DatabaseManager.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "KPA -> Plan Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class PRs_Aging_NotRel
    {
        public TempOne data;

        public PRs_Aging_NotRel()
        {
            data = new TempOne();
        }
    }






    public class MaterialDueDate
    {
        public TempOne data;

        public MaterialDueDate()
        {
            data = new TempOne();
        }
    }
}
