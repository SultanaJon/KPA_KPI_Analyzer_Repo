namespace ApplicationIOLibarary.Interfaces
{
    public interface ILoadable<T>
    {
        /// <summary>
        /// Loads the JSON file into the application and stores it into a T object
        /// </summary>
        /// <param name="obj">The object to load into.</param>
        void Load();
    }
}