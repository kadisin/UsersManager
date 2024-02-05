﻿namespace UsersManager.Repositories
{
    // Abstract repository working on T element
    public interface IRepository<T> 
    {
        /// <summary>
        /// Get all elements from database
        /// </summary>
        /// <returns>List of elements</returns>
        public Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Get elements that equals filter function
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<T> GetElementsWithFilter(Func<T, Boolean> filter);

        /// <summary>
        /// Get element by key
        /// </summary>
        /// <param name="key">Unique key of element</param>
        /// <returns>Element T</returns>
        public Task<T> GetElementByKey(int id);

        /// <summary>
        /// Add element to database
        /// </summary>
        /// <param name="element">Element to add to database</param>
        /// <returns></returns>
        public Task<int> AddElement(T element);

        /// <summary>
        /// Update existing element
        /// </summary>
        /// <param name="element">Existing in database element</param>
        /// <returns></returns>
        public Task<int> UpdateElement(T element);

        /// <summary>
        /// Delete element from database
        /// </summary>
        /// <param name="key">Key of existing element</param>
        /// <returns></returns>
        public Task<int> DeleteElement(T element);
    }
}
