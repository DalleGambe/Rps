using Microsoft.EntityFrameworkCore.ChangeTracking;
using Rps.Domain;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace Rps.DAL.Extensions
{
    public static class DbSetExtensions
    {
        //public static void AddAsyncIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : BasicEntity, new()
        //{
        //    var exists = predicate != null ? dbSet.Any(predicate) : dbSet.Any();
        //    if (exists)
        //    {
        //        // Get the properties of the entity
        //        var properties = typeof(T).GetProperties();

        //        // Iterate through each property
        //        foreach (var property in properties)
        //        {
        //            // Check if the property type inherits from a base class with an id
        //            if (typeof(BasicEntity).IsAssignableFrom(property.PropertyType))
        //            {
        //                // Get the base entity type
        //                var baseEntityType = property.PropertyType;

        //                // Create a new instance of the base entity
        //                var baseEntity = (BasicEntity)Activator.CreateInstance(baseEntityType);

        //                // Reset the properties of the base entity
        //                foreach (var baseProperty in baseEntityType.GetProperties())
        //                {
        //                    // Exclude the key property
        //                    if (!baseProperty.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
        //                    {
        //                        baseProperty.SetValue(baseEntity, null);
        //                    }
        //                }

        //                // Set the updated base entity to the property of the main entity
        //                property.SetValue(entity, baseEntity);
        //            }
        //        }
        //    }
        //    if(!exists)
        //    {
        //        dbSet.Add(entity);
        //    }
        //}
    }
}
