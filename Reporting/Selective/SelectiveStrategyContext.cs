using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Selective
{
    public class SelectiveStrategyContext
    {
        /// <summary>
        /// The selective reporting data
        /// </summary>
        private SelectiveStrategyData data;


        /// <summary>
        /// Property to get the selective data
        /// </summary>
        public SelectiveStrategyData Data
        {
            get { return data; }
            private set
            {
                if(value != null)
                {
                    this.data = value;
                }
            }
        }


        /// <summary>
        /// Custom Constructor
        /// </summary>
        /// <param name="_data">The selective strategy data used for selective reporting</param>
        public SelectiveStrategyContext(SelectiveStrategyData _data)
        {
            this.Data = _data;
        }
    }
}
