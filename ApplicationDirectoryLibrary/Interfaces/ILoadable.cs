namespace ApplicationIOLibarary.Interfaces
{
    public interface ILoadable
    {
        /// <summary>
        /// Loads the JSON file into the application and stores it into a T object
        /// </summary>
        /// <param name="obj">The object to be loaded.</param>
        /// <returns>Boolean value indicating whether or not the Load operation was successful.</returns>
        void Load();
    }
}