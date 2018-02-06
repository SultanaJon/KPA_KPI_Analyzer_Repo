namespace KPA_KPI_Analyzer.ExcelLibrary
{
    public class RawDataExcelFile : ExcelFile
    {
        public RawDataExcelFile(string _fileName, bool _hasHeaders)
        {
            FileName = _fileName;
            ContainsHeaders = _hasHeaders;
        }
    }
}
