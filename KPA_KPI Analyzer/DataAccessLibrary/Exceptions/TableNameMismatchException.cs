using System;

namespace DataAccessLibrary.Exceptions
{
    [Serializable]
    public class TableNameMismatchException : Exception
    {
        public TableNameMismatchException() { }

        public TableNameMismatchException(string message) : base(message) { }
    }
}
