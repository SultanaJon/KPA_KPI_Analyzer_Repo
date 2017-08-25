using System;

namespace Excel_Access_Tools.Access.ExceptionClasses
{
    public class TableNameMismatchException : Exception
    {
        public TableNameMismatchException() { }

        public TableNameMismatchException(string message) : base(message) { }
    }
}
