namespace Reporting.Interfaces
{
    public interface ISelectiveVTwo
    {
        double SelectiveAverage { get; set; }
        int SelectiveTotalRecords { get; set; }
        double SelectivePercentFavorable { get; set; }
    }
}
