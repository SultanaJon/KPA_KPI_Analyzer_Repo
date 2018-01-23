using System;

namespace DataAccessLibrary.Exceptions
{
    [Serializable]
    public class ThreadInteruptedException : Exception
    {
        public ThreadInteruptedException() { }
        public ThreadInteruptedException(string message) : base(message) { }
    }
}
