namespace KPA_KPI_Analyzer.Diagnostics
{
    public interface IStorable
    {
        /// <summary>
        /// Saves the object T to a JSON file.
        /// </summary>
        /// <param name="obj">The object to tbe saved</param>
        /// <returns>Boolean value indicating whether or not the Save operation was successful.</returns>
        void Save();
    }
}