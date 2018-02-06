using System;

namespace DataAccessLibrary.Exceptions
{
    [Serializable]
    public class DatabaseCreationFailureException : Exception
    {
        public DatabaseCreationFailureException() { }
        public DatabaseCreationFailureException(string message) : base(message) { }
    }
}
