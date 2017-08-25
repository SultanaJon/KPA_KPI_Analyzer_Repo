using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessor.Classes.ExceptionClasses
{
    public class DatabaseCreationFailureException : Exception
    {
        public DatabaseCreationFailureException() { }
        public DatabaseCreationFailureException(string message) : base(message) { }
    }
}
