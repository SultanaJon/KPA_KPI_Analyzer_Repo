namespace Reporting.Interfaces
{
    public interface ISelectiveVThree
    {
        double SelectiveAverage { get; set; }
        int SelectiveTotalRecords { get; set; }
        double SelectivePercentUnconfirmed { get; set; }
        double SelectivePercentFavorable { get; set; }
    }
}
