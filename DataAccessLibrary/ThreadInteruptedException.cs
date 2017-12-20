using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class ThreadInteruptedException : Exception
    {
        public ThreadInteruptedException() { }
        public ThreadInteruptedException(string message) : base(message) { }
    }
}
