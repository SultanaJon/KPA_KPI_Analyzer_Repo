using KPA_KPI_Analyzer.Database;
using KPA_KPI_Analyzer.Templates;
using System;
using System.Data;
using System.Windows.Forms;

namespace KPA_KPI_Analyzer.KPA_KPI_Overall.KPI_Sections
{
    public class FollowUp
    {
        public CurrentConfirmationVsInitialConfirmationDate currConfVsInitConf;
        public FinalConfirmatinoVsFinalPlanDate finalConfDateVsFinalPlan;
        public ReceiptDateVsCurrentPlanDate receiptDateVsCurrPlanDate;
        public ReceiptDateVsOriginalConfirmationDate receiptDateVsOrigConfDate;
        public ReceiptDateVsCurrentConfirmationDate receiptDateVsCurrConfDate;
        private double totalDays = 0;



        // Default Constructor
        public FollowUp()
        {
            currConfVsInitConf = new CurrentConfirmationVsInitialConfirmationDate();
            finalConfDateVsFinalPlan = new FinalConfirmatinoVsFinalPlanDate();
            receiptDateVsCurrPlanDate = new ReceiptDateVsCurrentPlanDate();
            receiptDateVsOrigConfDate = new ReceiptDateVsOriginalConfirmationDate();
            receiptDateVsCurrConfDate = new ReceiptDateVsCurrentConfirmationDate();
        }





        public string Name { get { return "Follow Up"; } }


        public enum CategorNames
        {
            CurrConfVsInitConf,
            finalConfDateVsFinalPlan,
            receiptDateVsCurrPlanDate,
            receiptDateVsOrigConfDate,
            receiptDateVsCurrConfDate
        }

        public string[] categoryNames =
        {
            "Current Confirmation Date vs Initial Confirmation Date",
            "Final Confirmation Date vs Final Plan Date",
            "Receipt Date vs Current Plan Date",
            "Receipt Date vs Original Confirmation Date",
            "Receipt Date vs Current Confirmation Date"
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
                // Initial Confirmation vs Current Confirmation
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

                    string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                    int firstConfYear = int.Parse(strFirstConfDate[2]);
                    int firstConfMonth = int.Parse(strFirstConfDate[0]);
                    int firstConfDay = int.Parse(strFirstConfDate[1]);


                    if(firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                    {
                        currConfVsInitConf.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        firstConfYear = int.Parse(strFirstConfDate[2]);
                        firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                        firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                    }

                    DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);

                    string[] strDelConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strDelConfDate[2]);
                    int delConfMonth = int.Parse(strDelConfDate[0].TrimStart('0'));
                    int delConfDay = int.Parse(strDelConfDate[1].TrimStart('0'));

                    DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);
                    double elapsedDays = (delConfDate - firstConfDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);
                    
                    if(elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);

                    currConfVsInitConf.data.Total++;

                    if (elapsedDays <= (-22))
                    {
                        currConfVsInitConf.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        currConfVsInitConf.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        currConfVsInitConf.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        currConfVsInitConf.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        currConfVsInitConf.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        currConfVsInitConf.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        currConfVsInitConf.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        currConfVsInitConf.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        currConfVsInitConf.data.TwentyTwo++;
                    }
                }


                try
                {
                    currConfVsInitConf.data.PercentUnconf = Math.Round(((double)currConfVsInitConf.data.PercentUnconfTotal / (currConfVsInitConf.data.Total + currConfVsInitConf.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(currConfVsInitConf.data.PercentUnconf))
                        currConfVsInitConf.data.PercentUnconf = 0;

                    if (double.IsInfinity(currConfVsInitConf.data.PercentUnconf))
                        currConfVsInitConf.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    currConfVsInitConf.data.PercentUnconf = 0;
                }



                
                try
                {
                    currConfVsInitConf.data.Average = Math.Round(totalDays / currConfVsInitConf.data.Total, 2);
                    if (double.IsNaN(currConfVsInitConf.data.Average))
                        currConfVsInitConf.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    currConfVsInitConf.data.Average = 0;
                }
                
                totalDays = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Final Confirmation Date vs Final Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


                foreach (DataRow dr in DatabaseUtils.posRecCompDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strDelConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int delConfYear = int.Parse(strDelConfDate[2]);
                    int delConfMonth = int.Parse(strDelConfDate[0]);
                    int delConfDay = int.Parse(strDelConfDate[1]);

                    if(delConfYear == 0 && delConfMonth == 0 && delConfDay == 0)
                    {
                        finalConfDateVsFinalPlan.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        delConfYear = int.Parse(strDelConfDate[2]);
                        delConfMonth = int.Parse(strDelConfDate[0].TrimStart('0'));
                        delConfDay = int.Parse(strDelConfDate[1].TrimStart('0'));
                    }

                    DateTime delConfDate = new DateTime(delConfYear, delConfMonth, delConfDay);


                    string[] strDelDate = (dr["Delivery Date"].ToString()).Split('/');
                    int delYear = int.Parse(strDelDate[2]);
                    int delMonth = int.Parse(strDelDate[0].TrimStart('0'));
                    int delDay = int.Parse(strDelDate[1].TrimStart('0'));

                    DateTime delDate = new DateTime(delYear, delMonth, delDay);
                    double elapsedDays = (delConfDate - delDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);


                    finalConfDateVsFinalPlan.data.Total++;


                    if (elapsedDays <= (-22))
                    {
                        finalConfDateVsFinalPlan.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        finalConfDateVsFinalPlan.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        finalConfDateVsFinalPlan.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        finalConfDateVsFinalPlan.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        finalConfDateVsFinalPlan.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        finalConfDateVsFinalPlan.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        finalConfDateVsFinalPlan.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        finalConfDateVsFinalPlan.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        finalConfDateVsFinalPlan.data.TwentyTwo++;
                    }
                }

                try
                {
                    finalConfDateVsFinalPlan.data.Average = Math.Round(totalDays / finalConfDateVsFinalPlan.data.Total, 2);
                    if (double.IsNaN(finalConfDateVsFinalPlan.data.Average))
                        finalConfDateVsFinalPlan.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    finalConfDateVsFinalPlan.data.Average = 0;
                }



                try
                {
                    finalConfDateVsFinalPlan.data.PercentUnconf = Math.Round(((double)finalConfDateVsFinalPlan.data.PercentUnconfTotal / (finalConfDateVsFinalPlan.data.Total + finalConfDateVsFinalPlan.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(finalConfDateVsFinalPlan.data.PercentUnconf))
                        finalConfDateVsFinalPlan.data.PercentUnconf = 0;

                    if (double.IsInfinity(finalConfDateVsFinalPlan.data.PercentUnconf))
                        finalConfDateVsFinalPlan.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    finalConfDateVsFinalPlan.data.PercentUnconf = 0;
                }

                totalDays = 0;


                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Receipt Date vs Current Planned Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseUtils.posRecCompDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }


                    string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                    int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                    int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                    int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                    string[] strCurrPlanDate = (dr["Rescheduling date"].ToString()).Split('/');
                    int currConfYear = int.Parse(strCurrPlanDate[2]);
                    int currConfMonth = int.Parse(strCurrPlanDate[0]);
                    int currConfDay = int.Parse(strCurrPlanDate[1]);

                    if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                    {
                        string[] strNewCurrConfDate = (dr["Delivery Date"].ToString()).Split('/');
                        currConfYear = int.Parse(strNewCurrConfDate[2]);
                        currConfMonth = int.Parse(strNewCurrConfDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strNewCurrConfDate[1].TrimStart('0'));
                    }
                    else
                    {
                        currConfYear = int.Parse(strCurrPlanDate[2]);
                        currConfMonth = int.Parse(strCurrPlanDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strCurrPlanDate[1].TrimStart('0'));
                    }

                    DateTime currPlanDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                     
                    double elapsedDays = (lastPORecDate - currPlanDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);


                    receiptDateVsCurrPlanDate.data.Total++;


                    if (elapsedDays <= (-22))
                    {
                        receiptDateVsCurrPlanDate.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        receiptDateVsCurrPlanDate.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        receiptDateVsCurrPlanDate.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        receiptDateVsCurrPlanDate.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        receiptDateVsCurrPlanDate.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        receiptDateVsCurrPlanDate.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        receiptDateVsCurrPlanDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        receiptDateVsCurrPlanDate.data.Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays >= 22)
                    {
                        receiptDateVsCurrPlanDate.data.TwentyTwo++;
                    }
                }


                try
                {
                    receiptDateVsCurrPlanDate.data.Average = Math.Round(totalDays / receiptDateVsCurrPlanDate.data.Total, 2);
                    if (double.IsNaN(receiptDateVsCurrPlanDate.data.Average))
                        receiptDateVsCurrPlanDate.data.Average = 0;
                }
                catch(DivideByZeroException)
                {
                    receiptDateVsCurrPlanDate.data.Average = 0;
                }


                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Receipt Date vs Original Confirmed Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                foreach (DataRow dr in DatabaseUtils.posRecCompDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                    int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                    int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                    int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                    string[] strFirstConfDate = (dr["1st Conf Date"].ToString()).Split('/');
                    int firstConfYear = int.Parse(strFirstConfDate[2]);
                    int firstConfMonth = int.Parse(strFirstConfDate[0]);
                    int firstConfDay = int.Parse(strFirstConfDate[1]);

                    if (firstConfYear == 0 && firstConfMonth == 0 && firstConfDay == 0)
                    {
                        receiptDateVsOrigConfDate.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        firstConfYear = int.Parse(strFirstConfDate[2]);
                        firstConfMonth = int.Parse(strFirstConfDate[0].TrimStart('0'));
                        firstConfDay = int.Parse(strFirstConfDate[1].TrimStart('0'));
                    }

                    DateTime firstConfDate = new DateTime(firstConfYear, firstConfMonth, firstConfDay);
                    double elapsedDays = (lastPORecDate - firstConfDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);


                    receiptDateVsOrigConfDate.data.Total++;


                    if (elapsedDays <= (-22))
                    {
                        receiptDateVsOrigConfDate.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        receiptDateVsOrigConfDate.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        receiptDateVsOrigConfDate.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        receiptDateVsOrigConfDate.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        receiptDateVsOrigConfDate.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        receiptDateVsOrigConfDate.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        receiptDateVsOrigConfDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        receiptDateVsOrigConfDate.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        receiptDateVsOrigConfDate.data.TwentyTwo++;
                    }
                }


                try
                {
                    receiptDateVsOrigConfDate.data.Average = Math.Round(totalDays / receiptDateVsOrigConfDate.data.Total, 2);
                    if (double.IsNaN(receiptDateVsOrigConfDate.data.Average))
                        receiptDateVsOrigConfDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    receiptDateVsOrigConfDate.data.Average = 0;
                }



                try
                {
                    receiptDateVsOrigConfDate.data.PercentUnconf = Math.Round(((double)receiptDateVsOrigConfDate.data.PercentUnconfTotal / (receiptDateVsOrigConfDate.data.Total + receiptDateVsOrigConfDate.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(receiptDateVsOrigConfDate.data.PercentUnconf))
                        receiptDateVsOrigConfDate.data.PercentUnconf = 0;

                    if (double.IsInfinity(receiptDateVsOrigConfDate.data.PercentUnconf))
                        receiptDateVsOrigConfDate.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    receiptDateVsOrigConfDate.data.PercentUnconf = 0;
                }

                totalDays = 0;



                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //
                // Receipt Date vs Current Confirmed Date
                //
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                foreach (DataRow dr in DatabaseUtils.posRecCompDt.Rows)
                {
                    //Check if the datarow meets the conditions of any applied filters.
                    if (!Filters.FilterUtils.EvaluateAgainstFilters(dr))
                    {
                        // This datarow dos not meet the conditions of the filters applied.
                        continue;
                    }

                    string[] strLastPORecDate = (dr["Last PO Rec#Date"].ToString()).Split('/');
                    int lastPORecDtYear = int.Parse(strLastPORecDate[2]);
                    int lastPORecDtMonth = int.Parse(strLastPORecDate[0]);
                    int lastPORecDtDay = int.Parse(strLastPORecDate[1]);

                    DateTime lastPORecDate = new DateTime(lastPORecDtYear, lastPORecDtMonth, lastPORecDtDay);

                    string[] strCurrConfDate = (dr["Del#Conf#Date"].ToString()).Split('/');
                    int currConfYear = int.Parse(strCurrConfDate[2]);
                    int currConfMonth = int.Parse(strCurrConfDate[0]);
                    int currConfDay = int.Parse(strCurrConfDate[1]);

                    if (currConfYear == 0 && currConfMonth == 0 && currConfDay == 0)
                    {
                        receiptDateVsCurrConfDate.data.PercentUnconfTotal++;
                        continue;
                    }
                    else
                    {
                        currConfYear = int.Parse(strCurrConfDate[2]);
                        currConfMonth = int.Parse(strCurrConfDate[0].TrimStart('0'));
                        currConfDay = int.Parse(strCurrConfDate[1].TrimStart('0'));
                    }

                    DateTime currConfDate = new DateTime(currConfYear, currConfMonth, currConfDay);
                    double elapsedDays = (lastPORecDate - currConfDate).TotalDays;
                    totalDays += elapsedDays;

                    if (elapsedDays < 0)
                        elapsedDays = Math.Floor(elapsedDays);

                    if (elapsedDays > 0)
                        elapsedDays = Math.Ceiling(elapsedDays);



                    receiptDateVsCurrConfDate.data.Total++;



                    if (elapsedDays <= (-22))
                    {
                        receiptDateVsCurrConfDate.data.Minus_TwentyTwo++;
                    }
                    else if (elapsedDays > (-22) && elapsedDays <= (-15))
                    {
                        receiptDateVsCurrConfDate.data.Minus_Fifteen_TwentyOne++;
                    }
                    else if (elapsedDays > (-15) && elapsedDays <= (-8))
                    {
                        receiptDateVsCurrConfDate.data.Minus_Eight_Fourteen++;
                    }
                    else if (elapsedDays > (-8) && elapsedDays <= (-1))
                    {
                        receiptDateVsCurrConfDate.data.Minus_One_Seven++;
                    }
                    else if (elapsedDays == 0)
                    {
                        receiptDateVsCurrConfDate.data.Zero++;
                    }
                    else if (elapsedDays >= 1 && elapsedDays <= 7)
                    {
                        receiptDateVsCurrConfDate.data.One_Seven++;
                    }
                    else if (elapsedDays >= 8 && elapsedDays <= 14)
                    {
                        receiptDateVsCurrConfDate.data.Eight_Fourteen++;
                    }
                    else if (elapsedDays >= 15 && elapsedDays <= 21)
                    {
                        receiptDateVsCurrConfDate.data.Fifteen_TwentyOne++;
                    }
                    else // 22 Days or greater
                    {
                        receiptDateVsCurrConfDate.data.TwentyTwo++;
                    }
                }



                try
                {
                    receiptDateVsCurrConfDate.data.Average = Math.Round(totalDays / receiptDateVsCurrConfDate.data.Total, 2);
                    if (double.IsNaN(receiptDateVsCurrConfDate.data.Average))
                        receiptDateVsCurrConfDate.data.Average = 0;
                }
                catch (DivideByZeroException)
                {
                    receiptDateVsCurrConfDate.data.Average = 0;
                }



                try
                {
                    receiptDateVsCurrConfDate.data.PercentUnconf = Math.Round(((double)receiptDateVsCurrConfDate.data.PercentUnconfTotal / (receiptDateVsCurrConfDate.data.Total + receiptDateVsCurrConfDate.data.PercentUnconfTotal)) * 100, 2);
                    if (double.IsNaN(receiptDateVsCurrConfDate.data.PercentUnconf))
                        receiptDateVsCurrConfDate.data.PercentUnconf = 0;

                    if (double.IsInfinity(receiptDateVsCurrConfDate.data.PercentUnconf))
                        receiptDateVsCurrConfDate.data.PercentUnconf = 100;
                }
                catch (DivideByZeroException)
                {
                    receiptDateVsCurrConfDate.data.PercentUnconf = 0;
                }



                DatabaseUtils.UpdateLoadProgress();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "KPI -> Follow Up Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    public class CurrentConfirmationVsInitialConfirmationDate
    {
        public TempThree data;

        public CurrentConfirmationVsInitialConfirmationDate()
        {
            data = new TempThree();
        }
    }






    public class FinalConfirmatinoVsFinalPlanDate
    {
        public TempThree data;

        public FinalConfirmatinoVsFinalPlanDate()
        {
            data = new TempThree();
        }
    }






    public class ReceiptDateVsCurrentPlanDate
    {
        public TempThree data;

        public ReceiptDateVsCurrentPlanDate()
        {
            data = new TempThree();
        }
    }






    public class ReceiptDateVsOriginalConfirmationDate
    {
        public TempThree data;

        public ReceiptDateVsOriginalConfirmationDate()
        {
            data = new TempThree();
        }
    }






    public class ReceiptDateVsCurrentConfirmationDate
    {
        public TempThree data;

        public ReceiptDateVsCurrentConfirmationDate()
        {
            data = new TempThree();
        }
    }
}
