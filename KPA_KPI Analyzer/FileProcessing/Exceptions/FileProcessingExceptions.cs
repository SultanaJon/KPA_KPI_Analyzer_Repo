using System;

namespace KPA_KPI_Analyzer.FileProcessing.Exceptions
{
    public static class FileProcessingExceptions
    {
        [Serializable]
        public class PrpoFileOverloadException : Exception
        {
            public PrpoFileOverloadException() { }
            public PrpoFileOverloadException(string message) : base(message) { }
        }




        [Serializable]
        public class FileProcessingInvalidExtensionException : Exception
        {
            public FileProcessingInvalidExtensionException() { }
            public FileProcessingInvalidExtensionException(string message) : base(message) { }
        }




        [Serializable]
        public class FileProcessingInvalidExcelFileException : Exception
        {
            public FileProcessingInvalidExcelFileException() { }
            public FileProcessingInvalidExcelFileException(string message) : base(message) { }
        }



        [Serializable]
        public class PrpoDateProcessingErrorException : Exception
        {
            public PrpoDateProcessingErrorException() { }
            public PrpoDateProcessingErrorException(string message) : base(message) { }
        }
    }
}