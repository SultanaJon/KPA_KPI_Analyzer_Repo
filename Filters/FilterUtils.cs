using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filters
{
    public static class FilterUtils
    {
        public static string query = string.Empty;


        /// <summary>
        /// Data used to updated the progress of the filter load process.
        /// </summary>
        public static bool FilterLoadProcessStarted { get; set; }
        public static bool FiltersLoaded { get; set; }
        public static int NumThreadsStarted { get; set; }
        public static int NumThreadCompleted { get; set; }






        ///// <summary>
        ///// Loads the unique filters into the application.
        ///// </summary>
        ///// <param name="filters">the current filters loaded.</param>
        //public static void LoadFilters(string filters)
        //{
        //    OleDbCommand cmd = new OleDbCommand();
        //    strData = new HashSet<string>();
        //    try
        //    {
        //        foreach (FilterColumn col in Enum.GetValues(typeof(FilterColumn)))
        //        {
        //            getQuery(col, filters);
        //            cmd = new OleDbCommand(query, DatabaseManager.GetDatabaseConnection());
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    if (reader[filterCols[(int)col]] == DBNull.Value)
        //                    {
        //                        strData.Add("[Blanks]");
        //                        continue;
        //                    }
        //                    else
        //                    {
        //                        strData.Add(reader[filterCols[(int)col]].ToString());
        //                    }
        //                }

        //                // We want to continue to add Prod Ord WBS element to the already added WBS elements to create the project numbers
        //                if (col == FilterColumn.ProjectNum_WBS_Element) continue;


        //                // Now that we have combined all unique values from WBS Element and Prod Ord. WBS fields, we want to clean them up before storing them
        //                // in the Checked list views.
        //                if (col == FilterColumn.ProjectNUm_ProdOrdWbs)
        //                    CleanUpProjectNumbers();


        //                MethodInvoker del = delegate
        //                {
        //                    UpdateFilter(strData, col);
        //                };
        //                del.Invoke();
        //            }
        //            strData.Clear();
        //        }
        //        FiltersLoaded = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        strData.Clear();
        //        strData = null;
        //        GC.Collect();
        //    }
        //}






        /// <summary>
        /// Returns whether or no the PO Line Creation date is within the data row is
        /// </summary>
        /// <param name="dr">The data row we are usin to get the data for this specific PR or PO line.</param>
        /// <returns>Returns a boolean indicating whether or no the PO line creation date is within the spcified filter dates</returns>
        public static bool PoCreateDateInRange(string createDate, string qtyOrdered)
        {
            // The user wnats to filter by PO date range
            string[] strPoLineCreateDate = createDate.Split('/');
            int poYear = int.Parse(strPoLineCreateDate[2]);
            int poMonth = int.Parse(strPoLineCreateDate[0]);
            int poDay = int.Parse(strPoLineCreateDate[1]);

            if (poYear == 0 && poMonth == 0 && poDay == 0)
            {
                // This record is not a PO so we dont care about it
                return false;
            }
            else
            {
                // This record shows as a PO but was it removed from the PO?
                if (qtyOrdered == "0")
                    return false;
                else
                {
                    poYear = int.Parse(strPoLineCreateDate[2]);
                    poMonth = int.Parse(strPoLineCreateDate[0].TrimStart('0'));
                    poDay = int.Parse(strPoLineCreateDate[1].TrimStart('0'));
                }
            }

            DateTime poTestDate = new DateTime(poYear, poMonth, poDay);

            if (poTestDate < Filters.FilterData.DateFilters.PoFromDate || poTestDate > Filters.FilterData.DateFilters.PoToDate)
            {
                // The PO date is not within the PO date range.
                return false;
            }
            return true;
        }




        /// <summary>
        /// Returns whether or no the Requisition date within the data row is
        /// </summary>
        /// <param name="dr">The data row we are usin to get the data for this specific PR or PO line.</param>
        /// <returns>Returns a boolean indicating whether or no the Requisition date is within the specified filter dates.</returns>
        public static bool PrDateInRange(string date)
        {
            // The user wants to filter by PR date range
            string[] requisnDate = date.Split('/');
            int reqYear = int.Parse(requisnDate[2]);
            int reqMonth = int.Parse(requisnDate[0].TrimStart('0'));
            int reqDay = int.Parse(requisnDate[1].TrimStart('0'));
            DateTime reqTestDate = new DateTime(reqYear, reqMonth, reqDay);

            if (reqTestDate < Filters.FilterData.DateFilters.PrFromDate || reqTestDate > Filters.FilterData.DateFilters.PrToDate)
            {
                // The PR date is not within the PR date range.
                return false;
            }

            return true;
        }



        /// <summary>
        /// Returns whether or no the PO Line Creation date is within the data row is
        /// </summary>
        /// <param name="dr">The data row we are usin to get the data for this specific PR or PO line.</param>
        /// <returns>Returns a boolean indicating whether or no the PO line creation date is within the spcified filter dates</returns>
        public static bool FinalReceiptDateInRange(string finalReceiptDate)
        {
            string[] strFinalRecDate = finalReceiptDate.Split('/');
            int finRecYear = int.Parse(strFinalRecDate[2]);
            int finRecMonth = int.Parse(strFinalRecDate[0]);
            int finRecDay = int.Parse(strFinalRecDate[1]);

            if (finRecYear == 0 && finRecMonth == 0 && finRecDay == 0)
            {
                // This record does not have a final receipt date
                return false;
            }
            else
            {
                finRecYear = int.Parse(strFinalRecDate[2]);
                finRecMonth = int.Parse(strFinalRecDate[0].TrimStart('0'));
                finRecDay = int.Parse(strFinalRecDate[1].TrimStart('0'));
            }

            DateTime finalRecDate = new DateTime(finRecYear, finRecMonth, finRecDay);

            if (finalRecDate < Filters.FilterData.DateFilters.FinalReceiptFromDate || finalRecDate > Filters.FilterData.DateFilters.FinalReceiptToDate)
            {
                // This records final receipt date is not within the filters final receipt date range.
                return false;
            }
            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        public static bool CheckAdvancedFilters(DataRow dr)
        {
            if (!FilterData.AdvancedFilters.FilterByServicePrPo)
            {
                string temp = dr["PR ItemCat1"].ToString();
                if (temp != string.Empty)
                {
                    if (int.Parse(temp) == 9)
                    {
                        return false;
                    }
                }
            }


            if (!FilterData.AdvancedFilters.FilterBySteelPrPo)
            {
                string material = dr["Material"].ToString();
                if (material.Contains("TAL-ST"))
                {
                    return false;
                }
            }


            if (!FilterData.AdvancedFilters.FilterByPouPrPo)
            {
                string docType = dr["Document Type"].ToString();
                if (docType.Contains("POU"))
                {
                    return false;
                }
            }


            if (!FilterData.AdvancedFilters.FilterByIntercompPo)
            {
                string vendorDesc = dr["Vendor Description"].ToString();
                if (vendorDesc.Contains("COMAU"))
                {
                    return false;
                }
            }


            if (!FilterData.AdvancedFilters.FilterByCodifiedMatNonSubcont)
            {
                if (dr["Material"].ToString() != string.Empty)
                {
                    return false;
                }
            }


            if (!FilterData.AdvancedFilters.FilterByCodifiedMatSubcont)
            {
                if (dr["Prd Ord Mat"].ToString() != string.Empty)
                {
                    return false;
                }
            }


            if (!FilterData.AdvancedFilters.FilterByManualPr)
            {
                string material = dr["Material"].ToString();
                string prdOrdMat = dr["Prd Ord Mat"].ToString();

                if (material == string.Empty && prdOrdMat == string.Empty)
                {
                    return false;
                }
            }

            return true;
        }







        /// <summary>
        /// When the program is loading the data, if filters are applied, it will return true or false
        /// if the datarow applies to the conditions.
        /// </summary>
        /// <param name="dr">The datarow being evaluated</param>
        /// <returns>True if the datarow meets the conditions of the filter, false otherwise.</returns>
        public static bool EvaluateAgainstFilters(DataRow dr)
        {
            if (FilterData.DateFilters.FilterByPrDateRange)
            {
                if (!FilterUtils.PrDateInRange(dr["Requisn Date"].ToString()))
                {
                    // The PR Date was not in range of the filter the user applied.
                    return false;
                }
            }

            if (FilterData.DateFilters.FilterByPoDateRange)
            {
                if (!FilterUtils.PoCreateDateInRange(dr["PO Line Creat#DT"].ToString(), dr["Qty Ordered"].ToString()))
                {
                    // The PO Date was not in range of the filter the user applied.
                    return false;
                }
            }

            if (FilterData.DateFilters.FilterByFinalReceiptDate)
            {
                if (!FilterUtils.FinalReceiptDateInRange(dr["Last PO Rec#Date"].ToString()))
                {
                    // The final receipt date was not in range of the filter the user applied
                    return false;
                }
            }

            if (FilterData.AdvancedFilters.AdvanceFiltersChanged())
            {
                // We have some advanced filters that the user would like to exclude.
                if (!FilterUtils.CheckAdvancedFilters(dr))
                    return false;
            }

            return true;
        }
    }
}
