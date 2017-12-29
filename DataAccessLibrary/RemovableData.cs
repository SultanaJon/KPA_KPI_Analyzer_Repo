using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class RemovableData
    {
        /// <summary>
        /// Query that removes unessessary United States data from the database.
        /// </summary>
        /// <returns>Returns the query to remove uneeded data from United States table.</returns>
        public static string GetUsRemovableDataQuery()
        {
            return "DELETE * FROM US_PRPO WHERE " + "(US_PRPO.[Open PR Qty] = 0 AND US_PRPO.[Qty Ordered] = 0)";
        }


        /// <summary>
        /// Query that removes unessessary Mexico data from the database.
        /// </summary>
        /// <returns>Returns the query to removed the uneeded data from Mexico's table.</returns>
        public static string GetMxRemovableDataQuery()
        {
            return "DELETE * FROM MX_PRPO WHERE " + "(MX_PRPO.[Open PR Qty] = 0 AND MX_PRPO.[Qty Ordered] = 0)";
        }
    }
}
