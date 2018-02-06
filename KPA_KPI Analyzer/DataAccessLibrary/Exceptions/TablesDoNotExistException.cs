using System;

namespace DataAccessLibrary.Exceptions
{
    [Serializable]
    public class TablesDoNotExistException : Exception
    {
        public TablesDoNotExistException() { }

        public TablesDoNotExistException(string message) : base(message) { }
    }
}
