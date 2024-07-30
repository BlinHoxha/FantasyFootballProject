using Framework.DTO.Interface;
using Framework.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository.Interface
{
    /// <summary>
    /// Base interface containing the standard CRUD operations
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to manage</typeparam>
    /// <typeparam name="TEntityId">The type of the id of the entity</typeparam>
    public interface IBaseRepository<TEntity, TEntityId> where TEntity : class, IBaseEntity<TEntityId>
    {
        #region Common Methods
        Task<IEnumerable<TMap>> GetAllAsync<TMap>() where TMap : class;

        /// <summary>
        /// Retrieves the entity of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TMap">The type the <typeparamref name="TEntity"/> will be mapped to</typeparam>
        /// <param name="id">The primary key id of the entity to retrieve</param>
        /// <returns>The <typeparamref name="TMap"/> instance with <paramref name="id"/> id</returns>
        Task<TMap?> GetById<TMap>(TEntityId id) where TMap : class, IBaseDtoEntity<TEntityId>;

        /// <summary>
        /// Retrieves the entity of type <typeparamref name="TEntity"/> by id
        /// </summary>
        /// <param name="id">The primary key id of the entity to retrieve</param>
        /// <param name="track">Specify if the read entity should be tracked or none</param>
        /// <returns>The <typeparamref name="TEntity"/> instance with <paramref name="id"/> id</returns>
        Task<TEntity?> GetById(TEntityId id, bool track = false);

        /// <summary>
        /// Adds the entity passed as input on the database.
        /// </summary>
        /// <param name="entity">The entity that should be added</param>
        /// <returns>The id of the just added entity of type <typeparamref name="TEntityId"/></returns>
        Task Add(TEntity? entity);

        /// <summary>
        /// Adds the collection of entities passed as input on the database.
        /// </summary>
        /// <param name="entities">The collection of entities that should be added</param>
        Task AddRange(IEnumerable<TEntity>? entities);

        /// <summary>
        /// Updates the entity passed as input on the database.
        /// </summary>
        /// <param name="entity">The entity that should be updated</param>
        Task Update(TEntity? entity);

        /// <summary>
        /// Updates the collection of entities passed in input
        /// </summary>
        /// <param name="entities">The collection of entities of type <typeparamref name="TEntity"/> to update</param>
        Task UpdateRange(IEnumerable<TEntity>? entities);

        /// <summary>
        /// Remove the entity passed in input
        /// </summary>
        /// <param name="entity">The entity to remove of type <typeparamref name="TEntity"/></param>
        Task Remove(TEntity? entity);

        /// <summary>
        /// Remove the entity with the passed id
        /// </summary>
        /// <param name="id">The id of the entity to delete</param>
        Task Remove(TEntityId? id);

        /// <summary>
        /// Remove the collection of entities passed in input
        /// </summary>
        /// <param name="entities">The collection of entities of type <typeparamref name="TEntity"/> to remove</param>
        Task RemoveRange(IEnumerable<TEntity>? entities);
        /// <summary>
        /// Remove a collection of entities retrieved by the passed ide
        /// </summary>
        /// <param name="ids">The collection of ids of the entities to remove</param>
        Task RemoveRange(IEnumerable<TEntityId?>? ids);
        #endregion
        #region Custom  Methods
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression);
        Task<(IEnumerable<TEntity> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>>? predicate = null);
        #endregion
        #region Helper methods

        /// <summary>
        /// Persist changes on the database
        /// </summary>
        Task SaveChanges();

        /// <summary>
        /// Retrieves the current connection string used in the underlying layer
        /// </summary>
        /// <returns>The connection string</returns>
        string? GetConnectionString();

        /// <summary>
        /// The <see cref="IQueryable{TEntity}"/> object used to perform complex query
        /// </summary>
        /// <param name="track">Specify if the read entities should be tracked or none</param>
        /// <returns>The <see cref="IQueryable{TEntity}"/> object, tracked or not, depending on <paramref name="track"/> parameter</returns>
        IQueryable<TEntity> Query(bool track = false);

        /// <summary>
        /// Clear tracked entities inside DbContext
        /// </summary>
        void ClearTracking();

        /// <summary>
        /// Set an entity as untracked insiede Dbcontext
        /// </summary>
        /// <param name="entity">The entity to be untracked</param>
        void UntrackEntity(TEntity entity);

        #endregion
    }
}

