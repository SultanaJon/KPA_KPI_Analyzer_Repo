using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessor.Classes.ExceptionClasses
{
    public class TablesDoNotExistException : Exception
    {
        public TablesDoNotExistException() { }

        public TablesDoNotExistException(string message) : base(message) { }
    }
}
