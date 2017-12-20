namespace Reporting
{
    abstract class KeyPerformanceAction
    {
        public abstract void CalculateOverallReport();
        public abstract void CalculateSelectiveReport();
        public abstract void CalculateComparisonReport();
    }
}