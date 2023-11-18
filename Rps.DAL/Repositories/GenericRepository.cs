using AllPhiConsultantRecruiter.DAL.Repositories.Contracts;
using Rps.Domain;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace Rps.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BasicEntity, new()
    {
        protected RpsDataContext Context { get; }

        public GenericRepository(RpsDataContext context)
        {
            Context = context;
        }

        #region Read
        /// <summary>
        ///Gets all entities from a table.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
           return Context.Set<T>().ToList();
        }

        /// <summary>
        /// Gets an entity based on the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id)
        {
            return SearchWithPk(id);
        }
        /// <summary>
        /// Gets all entities and their given associated tables filtered based on the conditions provided.
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? conditions,
         params Expression<Func<T, object>>[]? includes)
        {
            IQueryable<T> query = Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (conditions != null)
            {
                query = query.Where(conditions);
            }
            return query.ToList();
        }

        /// <summary>
        /// Gets a filtered collection of objects without any related entities included.
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> includes)
        {
            return GetAll(includes, null);
        }
        /// <summary>
        ///Gets a collection of objects with the related entities included.
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            return GetAll(null, includes);
        }
        /// <summary>
        /// Searches for an entity based on the primary key that was provided.
        /// </summary>
        /// <typeparam name="TPrimaryKey"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public T SearchWithPk<TPrimaryKey>(TPrimaryKey id)
        {
            return Context.Set<T>().Find(id);
        }
        #endregion
        //TODO finish the GetById method or delete it.
        #region Write
        #region Create
        /// <summary>
        /// Adds an entity to a table in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void AddToDb(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Adds an entity to a table in the database if it doesn't already exist.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        //public void AddToDbIfNotExist(T entity)
        //{
        //    Context.Set<T>().AddIfNotExists(entity);
        //}

        /// <summary>
        /// Adds or changes the data of the entity that was provided in the database.
        /// </summary>
        /// <param name="entity"></param>
        ///<remarks>If the primary key of the entity in question is equal to 0, then it will be added to the database. Otherwise, if the primary key is greater than 0, the data of the already exisiting entity will be updated.</remarks>
        /// <returns></returns>
        public void AddToDbOrChange(T entity)
        {
           Context.Set<T>().AddAsync(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Adds a range of entities to the database.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        #endregion
        #region Update
        /// <summary>
        /// Changes the data of an already exisiting entity from a table in the database.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public void Change(T entity)
        {
           Context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
           Context.SaveChanges();
        }
        #endregion
        #endregion
    }
}
