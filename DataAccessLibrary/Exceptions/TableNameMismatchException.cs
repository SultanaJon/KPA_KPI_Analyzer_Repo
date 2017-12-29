using System;

namespace DAL.Exceptions
{
    public class TableNameMismatchException : Exception
    {
        public TableNameMismatchException() { }

        public TableNameMismatchException(string message) : base(message) { }
    }
}
