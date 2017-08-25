using KPA_KPI_Analyzer.KPA_KPI_Overall;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Windows.Forms;


namespace KPA_KPI_Analyzer.FilterFeeature
{
    public static class FilterUtils
    {
        private static List<string> strData;
        public static string query = string.Empty;






        /// <summary>
        /// Data used to updated the progress of the filter load process.
        /// </summary>
        public static bool FilterLoadProcessStarted { get; set; }
        public static bool FiltersLoaded { get; set; }
        public static int NumThreadsStarted { get; set; }
        public static int NumThreadCompleted { get; set; }






        /// <summary>
        /// Callback function used to update the checklist boxes on the filter page.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filter"></param>
        public delegate void UpdateFilterHandler(List<string> data, Filters filter);
        public static event UpdateFilterHandler UpdateFilter;






        /// <summary>
        /// 
        /// </summary>
        public enum Filters
        {
            WBSElement,
            PrdOrd,
            WBSProject,
            Material,
            MaterialGroup,
            Vendor,
            VendorDescription,
            PurchGroup,
            IRSuppName,
            FxdSuppName,
            DsrdSuppName,
            CommCat,
        }






        /// <summary>
        /// Table names contained within the database.
        /// </summary>
        public static string[] filterCols =
        {
            "WBS Element",
            "Prd Ord WBS",
            "WBS Element",
            "Material",
            "Material Group",
            "Vendor",
            "Vendor Description",
            "Purch# Group",
            "IR Supp Name",
            "Fxd Supp Name",
            "Dsrd Supp Name",
            "Commodity category",
        };






        /// <summary>
        /// 
        /// </summary>
        /// <param name="Overall.SelectedCountry"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static void getQuery(Filters col, string filters)
        {
            string temp;
            string column = filterCols[(int)col];

            if (filters == string.Empty)
            {
                temp = "SELECT DISTINCT " + Overall.SelectedCountry + ".[" + column + "] FROM " + Overall.SelectedCountry;
            }
            else
            {
                temp = "SELECT DISTINCT " + Overall.SelectedCountry + ".[" + column + "] FROM " + Overall.SelectedCountry + " WHERE " + filters;
            }
            query = temp;
        }






        /// <summary>
        /// Loads the unique filtesr into the application.
        /// </summary>
        /// <param name="filters">the current filters loaded.</param>
        public static void LoadFilters(string filters)
        {
            filters = string.Empty;
            OleDbCommand cmd = new OleDbCommand();
            strData = new List<string>();
            try
            {
                foreach (Filters col in Enum.GetValues(typeof(Filters)))
                {
                    getQuery(col, filters);
                    cmd = new OleDbCommand(query, DatabaseUtils.PRPO_DB_Utils.DatabaseConnection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader[filterCols[(int)col]] == DBNull.Value)
                            {
                                continue;
                            }
                            else
                            {
                                strData.Add(reader[filterCols[(int)col]].ToString());
                            }
                        }

                        MethodInvoker del = delegate
                        {
                            UpdateFilter(strData, col);
                        };
                        del.Invoke();
                        strData.Clear();
                    }
                }
                FiltersLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        /// <summary>
        /// Loads the filters for each unique filter column.
        /// </summary>
        /// <param name="filters">The current filters</param>
        /// <param name="ignoredCol">The column that we want to ignore</param>
        public static void LoadFilters(string filters, Filters ignoredCol)
        {
            OleDbCommand cmd = new OleDbCommand();
            strData = new List<string>();
            try
            {
                foreach (Filters col in Enum.GetValues(typeof(Filters)))
                {
                    if (ignoredCol == col)
                        continue;

                    getQuery(col, filters);
                    cmd = new OleDbCommand(query, DatabaseUtils.PRPO_DB_Utils.DatabaseConnection);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader[filterCols[(int)col]] == DBNull.Value)
                            {
                                continue;
                            }
                            else
                                strData.Add(reader[filterCols[(int)col]].ToString());
                        }
                        UpdateFilter(strData, col);
                        strData.Clear();
                    }
                }
                FiltersLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Filter Utils - Load Filters Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
