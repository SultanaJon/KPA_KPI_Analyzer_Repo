using System;

namespace DataImporter.Access.ExceptionClasses
{
    public class ValuesbaseCreationFailureException : Exception
    {
        public ValuesbaseCreationFailureException() { }
        public ValuesbaseCreationFailureException(string message) : base(message) { }
    }
}
