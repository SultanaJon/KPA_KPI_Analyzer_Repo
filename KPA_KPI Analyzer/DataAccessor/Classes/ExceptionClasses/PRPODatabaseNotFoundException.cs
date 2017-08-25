using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessor.Classes.ExceptionClasses
{
    public class PRPODatabaseNotFoundException : Exception
    {
        public PRPODatabaseNotFoundException() { }

        public PRPODatabaseNotFoundException(string message) : base(message) { }
    }
}
