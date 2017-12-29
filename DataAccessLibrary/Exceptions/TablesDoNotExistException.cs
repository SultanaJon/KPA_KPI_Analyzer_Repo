using System;

namespace DAL.Exceptions
{
    public class TablesDoNotExistException : Exception
    {
        public TablesDoNotExistException() { }

        public TablesDoNotExistException(string message) : base(message) { }
    }
}
