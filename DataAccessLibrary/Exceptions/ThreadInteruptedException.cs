using System;

namespace AccessDatabaseLibrary.Exceptions
{
    public class ThreadInteruptedException : Exception
    {
        public ThreadInteruptedException() { }
        public ThreadInteruptedException(string message) : base(message) { }
    }
}
