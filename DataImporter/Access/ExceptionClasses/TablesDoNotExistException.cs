using System;

namespace Excel_Access_Tools.Access.ExceptionClasses
{
    public class TablesDoNotExistException : Exception
    {
        public TablesDoNotExistException() { }

        public TablesDoNotExistException(string message) : base(message) { }
    }
}
