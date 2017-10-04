using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
