using System;

namespace AccessDatabaseLibrary.Exceptions
{
    public class TableNameMismatchException : Exception
    {
        public TableNameMismatchException() { }

        public TableNameMismatchException(string message) : base(message) { }
    }
}
