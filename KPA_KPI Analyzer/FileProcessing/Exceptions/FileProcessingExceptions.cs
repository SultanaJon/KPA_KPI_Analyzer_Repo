using System;

namespace KPA_KPI_Analyzer.FileProcessing.Exceptions
{
    public static class FileProcessingExceptions
    {
        public class PrpoFileOverloadException : Exception
        {
            public PrpoFileOverloadException() { }
            public PrpoFileOverloadException(string message) : base(message) { }
        }





        public class FileProcessingInvalidExtensionException : Exception
        {
            public FileProcessingInvalidExtensionException() { }
            public FileProcessingInvalidExtensionException(string message) : base(message) { }
        }





        public class FileProcessingInvalidExcelFileException : Exception
        {
            public FileProcessingInvalidExcelFileException() { }
            public FileProcessingInvalidExcelFileException(string message) : base(message) { }
        }




        public class PrpoDateProcessingErrorException : Exception
        {
            public PrpoDateProcessingErrorException() { }
            public PrpoDateProcessingErrorException(string message) : base(message) { }
        }
    }
}