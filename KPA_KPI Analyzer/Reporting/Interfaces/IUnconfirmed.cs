﻿namespace Reporting.Interfaces
{
    public interface IUnconfirmed
    {
        /// <summary>
        /// The percent of unconfirmed records within the KPA or KPI
        /// </summary>
        double PercentUnconfirmed { get; set; }



        /// <summary>
        /// The total of records that are unconfirmed
        /// </summary>
        int UnconfirmedTotal { get; set; }


        /// <summary>
        /// Calculated the percentage of unconfirmed records
        /// </summary>
        void CalculatePercentUnconfirmed(int _unconfirmedTotal);
    }
}
