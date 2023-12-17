using Rps.Domain;
using System.Linq.Expressions;

namespace AllPhiConsultantRecruiter.DAL.Repositories.Contracts
{
    public interface IGenericRepository<T>
  where T : BasicEntity, new()
    {
        #region Read
        /// <summary>
        ///Gets all entities from a table.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Gets an entity based on the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);
        /// <summary>
        /// Gets a filtered collection of objects without any related entities included.
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? conditions);
        /// <summary>
        ///Gets a collection of objects with the related entities included.
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Gets all entities and their given associated tables filtered based on the conditions provided.
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
       IEnumerable<T> GetAll(Expression<Func<T, bool>> conditions,
            params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// Searches for an entity based on the primary key that was provided.
        /// </summary>
        /// <typeparam name="TPrimaryKey"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T SearchWithPk<TPrimaryKey>(TPrimaryKey id);
        #endregion
        #region Write
        #region Create
        /// <summary>
        /// Adds an entity to a table in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void AddToDb(T entity);
        /// <summary>
        /// Adds an entity to a table in the database if it doesn't already exist.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        /// <summary>
        /// Adds an entity to a table in the database if it doesn't already exist and returns it'd id.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int AddToDbReturnId(T entity);

        /// <summary>
        /// Adds or changes the data of the entity that was provided in the database.
        /// </summary>
        /// <param name="entity"></param>
        ///<remarks>If the primary key of the entity in question is equal to 0, then it will be added to the database. Otherwise, if the primary key is greater than 0, the data of the already exisiting entity will be updated.</remarks>
        /// <returns></returns>
        void AddToDbOrChange(T entity);
        /// <summary>
        /// Adds or changes the data of the entity that was provided in the database based on the value of the primary key. It will return the id afterwards.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void AddRange(IEnumerable<T> entities);
        #endregion
        #region Update
        /// <summary>
        /// Changes the data of an already exisiting entity from a table in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Change(T entity);
        #endregion
        #endregion
    }
}
