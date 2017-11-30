using System;

namespace DataImporter.Importing.Exceptions
{
    public static class ImportExceptions
    {
        public class InvalidDataFileException : Exception
        {
            public InvalidDataFileException() { }
            public InvalidDataFileException(string message) : base(message) { }
        }
    }
}
