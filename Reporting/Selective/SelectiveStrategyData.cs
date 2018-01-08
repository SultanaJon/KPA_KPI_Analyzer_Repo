using System;
using Reporting.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Selective
{
    public abstract class SelectiveStrategyData
    {
        /// <summary>
        /// The average for this KPA or KPI
        /// </summary>
        public abstract double Average { get; set; }


        /// <summary>
        /// The total number of records for this KPA or KPI
        /// </summary>
        public abstract double TotalRecords { get; set; }



        /// <summary>
        /// Default Constructor
        /// </summary>
        public SelectiveStrategyData()
        {

        }



        /// <summary>
        /// Calculates the average for selective reporting for this KPA or KPI
        /// </summary>
        /// <param name="_totalDays"></param>
        public void CalculateAverage(double _totalDays)
        {
            try
            {
                this.Average = Math.Round(_totalDays / this.TotalRecords, 2);
                if (double.IsNaN(this.Average))
                    this.Average = 0;
            }
            catch (DivideByZeroException)
            {
                this.Average = 0;
            }
        }
    }


    public sealed class SelectiveDataTypeOne : SelectiveStrategyData
    {
        public override double Average { get; set; }
        public override double TotalRecords { get; set; }
    }



    public sealed class SelectiveDataTypeTwo : SelectiveStrategyData
    {
        public override double Average { get; set; }
        public override double TotalRecords { get; set; }
        public double PercentUnconfirmed { get; set; }
    }


    public sealed class SelectiveDataTypeThree : SelectiveStrategyData 
    {
        public override double Average { get; set; }
        public override double TotalRecords { get; set; }
        public double PercentFavorable { get; set; }
    }


    public sealed class SelectiveDataTypeFour : SelectiveStrategyData
    {
        public override double Average { get; set; }
        public override double TotalRecords { get; set; }
        public double PercentUnconfirmed { get; set; }
        public double PercentFavorable { get; set; }
    }
}
