using System;

namespace KPA_KPI_Analyzer.DragDropFeatures.Exceptions
{
    public static class DragDropExceptions
    {
        public class DragDropFileOverloadException : Exception
        {
            public DragDropFileOverloadException() { }
            public DragDropFileOverloadException(string message) : base(message) { }
        }





        public class DragDropInvalidExtensionException : Exception
        {
            public DragDropInvalidExtensionException() { }
            public DragDropInvalidExtensionException(string message) : base(message) { }
        }





        public class DragDropInvalidExcelFileException : Exception
        {
            public DragDropInvalidExcelFileException() { }
            public DragDropInvalidExcelFileException(string message) : base(message) { }
        }
    }
}
