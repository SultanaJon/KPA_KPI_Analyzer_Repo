using System;

namespace DataAccessLibrary.Exceptions
{
    public class ThreadInteruptedException : Exception
    {
        public ThreadInteruptedException() { }
        public ThreadInteruptedException(string message) : base(message) { }
    }
}
