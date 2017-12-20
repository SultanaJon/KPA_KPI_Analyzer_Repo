using System;

namespace AccessDatabaseLibrary.Exceptions
{
    public class TablesDoNotExistException : Exception
    {
        public TablesDoNotExistException() { }

        public TablesDoNotExistException(string message) : base(message) { }
    }
}
