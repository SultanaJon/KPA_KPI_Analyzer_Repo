using System;

namespace DataAccessLibrary.Exceptions
{
    public class DatabaseCreationFailureException : Exception
    {
        public DatabaseCreationFailureException() { }
        public DatabaseCreationFailureException(string message) : base(message) { }
    }
}
