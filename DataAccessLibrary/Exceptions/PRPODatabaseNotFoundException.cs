using System;

namespace DataAccessLibrary.Exceptions
{
    public class PRPODatabaseNotFoundException : Exception
    {
        public PRPODatabaseNotFoundException() { }

        public PRPODatabaseNotFoundException(string message) : base(message) { }
    }
}
