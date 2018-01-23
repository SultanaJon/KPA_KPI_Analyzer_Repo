using System;

namespace DataAccessLibrary.Exceptions
{
    [Serializable]
    public class PRPODatabaseNotFoundException : Exception
    {
        public PRPODatabaseNotFoundException() { }

        public PRPODatabaseNotFoundException(string message) : base(message) { }
    }
}
