using Framework.DTO.Interface;
using Framework.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.BusinessService.Interface
{
    public interface IBaseService<TEntity, TEntityId>  where TEntity : class, IBaseEntity<TEntityId>
    {
        /// <summary>
        /// Retrieves the entity of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TMap">The type the <typeparamref name="TEntity"/> will be mapped to</typeparam>
        /// <param name="id">The primary key id of the entity to retrieve</param>
        /// <returns>The <typeparamref name="TMap"/> instance with <paramref name="id"/> id</returns>
        //Task<IEnumerable<TMap?>> GetAllAsync<TMap>(TEntityId id) where TMap : class, IBaseDtoEntity<TEntityId>;

        Task<IEnumerable<TMap?>> GetAllAsync<TMap>() where TMap : class;


        /// <summary>
        /// Retrieves the entity of type <typeparamref name="TEntity"/>
        /// </summary>
        /// <typeparam name="TMap">The type the <typeparamref name="TEntity"/> will be mapped to</typeparam>
        /// <param name="id">The primary key id of the entity to retrieve</param>
        /// <returns>The <typeparamref name="TMap"/> instance with <paramref name="id"/> id</returns>
        Task<TMap?> GetById<TMap>(TEntityId id) where TMap : class, IBaseDtoEntity<TEntityId>;

        /// <summary>
        /// Adds the entity passed as input on the database. It starts by mapping the <typeparamref name="TMap"/> onto the <typeparamref name="TEntity"/> type.
        /// It also persist requested changes.
        /// </summary>
        /// <typeparam name="TMap">The type the <typeparamref name="TEntity"/> will be mapped to</typeparam>
        /// <param name="dto">The entity that should be added</param>
        /// <returns>The id of the just added entity of type <typeparamref name="TEntityId"/></returns>
        Task<TEntityId?> Add<TMap>(TMap dto) where TMap : class;

        /// <summary>
        /// Adds the collection of entities passed as input on the database. It starts by mapping the <typeparamref name="TMap"/> onto the <typeparamref name="TEntity"/> type.
        /// It also persist requested changes.
        /// </summary>
        /// <typeparam name="TMap">The type the <typeparamref name="TEntity"/> will be mapped to</typeparam>
        /// <param name="dtos">The collection of entities that should be added</param>
        Task AddRange<TMap>(IEnumerable<TMap> dtos) where TMap : class;

        /// <summary>
        /// Updates the entity passed as input on the database. It starts by mapping the <typeparamref name="TMap"/> onto the <typeparamref name="TEntity"/> type.
        /// It also persist requested changes.
        /// </summary>
        /// <typeparam name="TMap">The type the <typeparamref name="TEntity"/> will be mapped to</typeparam>
        /// <param name="dto">The entity that should be updated</param>
        Task<TEntityId?> Update<TMap>(TMap dto) where TMap : class;

        /// <summary>
        /// Updates the collection of entities passed as input on the database. It starts by mapping the <typeparamref name="TMap"/> onto the <typeparamref name="TEntity"/> type.
        /// It also persist requested changes.
        /// </summary>
        /// <typeparam name="TMap">The type the <typeparamref name="TEntity"/> will be mapped to</typeparam>
        /// <param name="dtos">The collection of entities that should be added</param>
        Task UpdateRange<TMap>(IEnumerable<TMap> dtos) where TMap : class;

        /// <summary>
        /// Removes the entity with the id <paramref name="id"/> passed in input (of type <typeparamref name="TEntityId"/>)
        /// </summary>
        /// <param name="id">The id of the entity to remove</param>
        Task Remove(TEntityId? id);

        /// <summary>
        /// Removes the of entities passed in input
        /// </summary>
        /// <param name="ids">The list of entity ids to remove (of type <typeparamref name="TEntityId"/>)</param>
        Task RemoveRange(IEnumerable<TEntityId>? ids);

        // Synchronous methods
        //IEnumerable<T> GetAll();
        //T GetById(Guid? id);
        //T Add(T entity);
        //T Update(Guid? id, T entity);
        //bool Delete(Guid? id);
    }
}
