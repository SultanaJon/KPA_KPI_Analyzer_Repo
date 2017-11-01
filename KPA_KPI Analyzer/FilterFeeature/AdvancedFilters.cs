using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static bool FilterByReturnPo { get; set; } = true;


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
        /// <returns></returns>
        public static bool AdvanceFiltersChanged()
        {
            if (FilterByServicePrPo && 
                FilterBySteelPrPo && 
                FilterByPouPrPo && 
                FilterByReturnPo && 
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
            FilterByReturnPo = true;
            FilterByIntercompPo = true;
            FilterByCodifiedMatNonSubcont = true;
            FilterByCodifiedMatSubcont = true;
            FilterByManualPr = true;
        }
    }
}
