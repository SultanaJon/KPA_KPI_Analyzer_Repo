using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPA_KPI_Analyzer.Correlation
{
    public static class CorrelationHeaders
    {
        /// <summary>
        /// Correlation index date range filter names
        /// </summary>
        public enum CorrelationDateRangeFilters
        {
            RequisitionDate,
            PoLineCreateDate,
            QtyOrdered
        }



        /// <summary>
        /// The correlation date range query header names.
        /// </summary>
        public static string[] correlationDateRangeFilters =
        {
            "Requisn Date",
            "PO Line Creat#DT",
            "Qty Ordered"
        };


        /// <summary>
        /// The list of correlation Query header names. These string are used to query the data because they contain special characters
        /// needed to get proper results from the query.
        /// </summary>
        public static string[] correlationQueryHeaders =
        {
            "PO Qty",
            "PR Qty",
            "PR Price",
            "PR Pos#Value",
            "PO Net Price",
            "PO Value",
            "Price Unit",
            "Pl# Deliv# Time",
            "Qty Ordered",
            "Delivered",
            "Qty Conf#",
            "Open PR Qty"
        };




        /// <summary>
        /// The Correlation Index Matric Header names
        /// </summary>
        public enum CorrelationMatrixIndexer
        {
            PoQty,
            PrQty,
            PrPrice,
            PrPosValue,
            PoNetPrice,
            PoValue,
            PriceUnit,
            PlDelivTime,
            QtyOrdered,
            Delivered,
            QtyConf,
            OpenPrQty
        }



        /// <summary>
        /// The list of correlation header names.
        /// </summary>
        public static string[] correlationHeaders =
        {
            "PO Qty",
            "PR Qty",
            "PR Price",
            "PR Pos Val",
            "PO Net Price",
            "PO Val",
            "Price Unit",
            "Plan Del Time",
            "Qty Ordered",
            "Delivered",
            "Qty Conf",
            "Open PR Qty"
        };
    }
}
