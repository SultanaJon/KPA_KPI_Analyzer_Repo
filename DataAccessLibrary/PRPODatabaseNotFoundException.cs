using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class PRPODatabaseNotFoundException : Exception
    {
        public PRPODatabaseNotFoundException() { }

        public PRPODatabaseNotFoundException(string message) : base(message) { }
    }
}
