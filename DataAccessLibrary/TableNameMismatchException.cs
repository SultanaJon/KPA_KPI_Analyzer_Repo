using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    class TableNameMismatchException : Exception
    {
        public TableNameMismatchException() { }

        public TableNameMismatchException(string message) : base(message) { }
    }
}
