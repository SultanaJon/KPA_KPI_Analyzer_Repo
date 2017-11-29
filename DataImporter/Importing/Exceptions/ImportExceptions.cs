using System;

namespace DataImporter.Importing.Exceptions
{
    public static class ImportExceptions
    {
        public class InvalidValuesFileException : Exception
        {
            public InvalidValuesFileException() { }
            public InvalidValuesFileException(string message) : base(message) { }
        }
    }
}
