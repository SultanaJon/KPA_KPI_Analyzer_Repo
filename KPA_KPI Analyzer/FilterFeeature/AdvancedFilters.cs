using System.Collections.Generic;

namespace KPA_KPI_Analyzer.FilterFeeature
{
    public class AdvancedFilters
    {
        #region PROPERTIES REGION
        /// <summary>
        /// 
        /// </summary>
        public static bool FilterByServicePrPo { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public static bool FilterBySteelPrPo { get; set; } = true;


        /// <summary>
        /// 
        /// </summary>
        public static bool FilterByPouPrPo { get; set; } = true;


        /// <summary>
        /// 
        /// </summary>
        public static bool FilterByIntercompPo { get; set; } = true;


        /// <summary>
        /// 
        /// </summary>
        public static bool FilterByCodifiedMatNonSubcont { get; set; } = true;


        /// <summary>
        /// 
        /// </summary>
        public static bool FilterByCodifiedMatSubcont { get; set; } = true;


        /// <summary>
        /// 
        /// </summary>
        public static bool FilterByManualPr { get; set; } = true;
        #endregion





        /// <summary>
        /// 
        /// </summary>
        public enum AdvancedFilter
        {
            ServicePrPo,
            SteelPrPo,
            PouPrPo,
            IntercompanyPo,
            CodifiedMatNonSubCont,
            CodifiedMatSubCont,
            ManualPr
        }





        /// <summary>
        /// 
        /// </summary>
        public static string[] advancedFilters =
        {
            "Service PR/PO",
            "Steel PR/PO",
            "POU PR/PO",
            "Intercompany PO",
            "Codified Material (Non-Subcontract)",
            "Codified Material (Subcontract)",
            "Manual PR"
        };





        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool AdvanceFiltersChanged()
        {
            if (FilterByServicePrPo && 
                FilterBySteelPrPo && 
                FilterByPouPrPo && 
                FilterByIntercompPo && 
                FilterByCodifiedMatNonSubcont && 
                FilterByCodifiedMatSubcont && 
                FilterByManualPr)
            {
                return false;
            }
            else
            {
                return true;
            }
        }





        /// <summary>
        /// 
        /// </summary>
        public static void ResetAdvanceFilters()
        {
            FilterByServicePrPo = true;
            FilterBySteelPrPo = true;
            FilterByPouPrPo = true;
            FilterByIntercompPo = true;
            FilterByCodifiedMatNonSubcont = true;
            FilterByCodifiedMatSubcont = true;
            FilterByManualPr = true;
        }




        public static List<string> GetSelectedAdvancedFilters()
        {
            List<string> temp = new List<string>();
            if (!FilterByServicePrPo) temp.Add(advancedFilters[(int)AdvancedFilter.ServicePrPo]);
            if (!FilterBySteelPrPo) temp.Add(advancedFilters[(int)AdvancedFilter.SteelPrPo]);
            if (!FilterByPouPrPo) temp.Add(advancedFilters[(int)AdvancedFilter.PouPrPo]);
            if (!FilterByIntercompPo) temp.Add(advancedFilters[(int)AdvancedFilter.IntercompanyPo]);
            if (!FilterByCodifiedMatNonSubcont) temp.Add(advancedFilters[(int)AdvancedFilter.CodifiedMatNonSubCont]);
            if (!FilterByCodifiedMatSubcont) temp.Add(advancedFilters[(int)AdvancedFilter.CodifiedMatSubCont]);
            if (!FilterByManualPr) temp.Add(advancedFilters[(int)AdvancedFilter.ManualPr]);

            return temp;
        }
    }
}
