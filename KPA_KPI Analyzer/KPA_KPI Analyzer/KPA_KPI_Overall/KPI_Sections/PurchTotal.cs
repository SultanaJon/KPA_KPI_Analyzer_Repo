﻿using Excel_Access_Tools.Access;
using KPA_KPI_Analyzer.DatabaseUtils;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class PurchTotal
    {
        public PR_Rel_Conf_Entry prRelConfEntry;
        private double totalDays = 0;


        // Default Constructor
        public PurchTotal()
        {
            prRelConfEntry = new PR_Rel_Conf_Entry();
        }


        /// <summary>
        /// Loads the data for the specific KPI
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

                foreach (DataRow dr in Overall.prsOnPOsDt.Rows)
                {
                    string[] strfirstConfCreateDt = (dr["1st Conf Creation Da"].ToString()).Split('/');
                    int firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                    int firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0]);
                    int firstConfCreateDay = int.Parse(strfirstConfCreateDt[1]);

                    if(firstConfCreateYear == 0 && firstConfCreateMonth == 0 & firstConfCreateDay == 0)
                    {

                        continue;
                    }
                    else
                    {
                        prRelConfEntry.data.Total++;
                        firstConfCreateYear = int.Parse(strfirstConfCreateDt[2]);
                        firstConfCreateMonth = int.Parse(strfirstConfCreateDt[0].TrimStart('0'));
                        firstConfCreateDay = int.Parse(strfirstConfCreateDt[1].TrimStart('0'));
                    }

                    DateTime poLineConfCreateDate = new DateTime(firstConfCreateYear, firstConfCreateMonth, firstConfCreateDay);

                    string[] strPR2ndLvlRelDate = (dr["PR 2° Rel# Date"].ToString()).Split('/');
                    int secLvlRelYear = int.Parse(strPR2ndLvlRelDate[2]);
                    int secLvlRelMonth = int.Parse(strPR2ndLvlRelDate[0].TrimStart('0'));
                    int secLvlRelDay = int.Parse(strPR2ndLvlRelDate[1].TrimStart('0'));

                    DateTime pr2ndLvlRelDate = new DateTime(secLvlRelYear, secLvlRelMonth, secLvlRelDay);
                    double elapsedDays = (poLineConfCreateDate - pr2ndLvlRelDate).TotalDays;
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
                    else if (elapsedDays >= 29 && elapsedDays <= 35)
                    {
                        prRelConfEntry.data.TwentyNine_ThirtyFive++;
                    }
                    else if (elapsedDays >= 36 && elapsedDays <= 42)
                    {
                        prRelConfEntry.data.ThirtySix_FourtyTwo++;
                    }
                    else if (elapsedDays >= 43 && elapsedDays <= 49)
                    {
                        prRelConfEntry.data.FourtyThree_FourtyNine++;
                    }
                    else if (elapsedDays >= 50)
                    {
                        prRelConfEntry.data.greaterThanEqualFifty++;
                    }
                }

                try
                {
                    prRelConfEntry.data.PercentUnconf = (int)(((double)(Overall.prsOnPOsDt.Rows.Count - prRelConfEntry.data.Total) / Overall.prsOnPOsDt.Rows.Count) * 100);
                }
                catch (DivideByZeroException)
                {
                    prRelConfEntry.data.PercentUnconf = 0;
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
                MessageBox.Show(ex.StackTrace, "KPI -> Purch Total Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class PR_Rel_Conf_Entry
    {
        public TempFour data;

        public PR_Rel_Conf_Entry()
        {
            data = new TempFour();
        }
    }
}
