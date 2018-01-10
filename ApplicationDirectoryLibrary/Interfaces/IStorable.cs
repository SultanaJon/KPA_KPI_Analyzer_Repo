namespace ApplicationIOLibarary.Interfaces
{
    public interface IStorable<T>
    {
        /// <summary>
        /// Saves the object T to a JSON file.
        /// </summary>
        /// <param name="obj">The object to save into</param>
        void Save();
    }
}