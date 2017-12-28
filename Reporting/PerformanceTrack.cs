using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reporting.KeyPerformanceActions;

namespace Reporting
{
    public abstract class PerformanceTrack
    {
        internal List<KeyPerformanceAction> actions = new List<KeyPerformanceAction>();

        public List<KeyPerformanceAction> Actions { get { return actions; } }


        public PerformanceTrack()
        {
            this.AddActions();
        }


        internal abstract void AddActions();
    }
}
