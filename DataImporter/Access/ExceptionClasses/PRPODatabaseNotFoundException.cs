using System;

namespace DataImporter.Access.ExceptionClasses
{
    public class PRPOValuesbaseNotFoundException : Exception
    {
        public PRPOValuesbaseNotFoundException() { }

        public PRPOValuesbaseNotFoundException(string message) : base(message) { }
    }
}
