using AutoMapper;
using AutoMapper.QueryableExtensions;
using Duende.IdentityServer.Models;
using Framework.DTO.Interface;
using Framework.Entities.Interface;
using Framework.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Repository.Implementation
{
    public abstract class BaseRepository<TEntity, TEntityId> : IBaseRepository<TEntity, TEntityId> where TEntity : class, IBaseEntity<TEntityId>
    {
        //private readonly List<T> _entities = new List<T>();
        /// <summary>
        /// The concrete <see cref="DbContext"/> instance used to access the database
        /// </summary>
        protected readonly DbContext _context;

        /// <summary>
        /// The <see cref="ILogger"/> instance
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// The <see cref="IMapper"/> instance
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// The typed <see cref="DbSet{TEntity}"/> from the <see cref="DbContext"/>. It maps the table on the db
        /// </summary>
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context, ILogger logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TMap>> GetAllAsync<TMap>() where TMap : class
        {
            var entities = await _context.Set<TEntity>().Where(e => !e.IsDeleted).ToListAsync();
            return _mapper.Map<IEnumerable<TMap>>(entities);
        }


        public virtual async Task Add(TEntity? entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRange(IEnumerable<TEntity>? entities)
        {
            ArgumentNullException.ThrowIfNull(entities);

            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<TMap?> GetById<TMap>(TEntityId id) where TMap : class, IBaseDtoEntity<TEntityId>
        {
            ArgumentNullException.ThrowIfNull(id);

            return await Query()
                .Where(x => x.Id!.Equals(id))
                .ProjectTo<TMap>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity?> GetById(TEntityId id, bool track = false)
        {
            ArgumentNullException.ThrowIfNull(id);

            return await Query(track).FirstOrDefaultAsync(x => x.Id!.Equals(id));
        }

        public virtual async Task<(IEnumerable<TEntity> Items, int TotalCount)> GetPagedAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }


        public virtual async Task Remove(TEntity? entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Remove(entity);

            await Task.CompletedTask;
        }

        public virtual async Task Remove(TEntityId? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            TEntity? entity = await GetById(id!);

            await Remove(entity);
        }

        public virtual async Task RemoveRange(IEnumerable<TEntity>? entities)
        {
            ArgumentNullException.ThrowIfNull(entities);

            _dbSet.RemoveRange(entities);

            await Task.CompletedTask;
        }

        public virtual async Task RemoveRange(IEnumerable<TEntityId?>? ids)
        {
            ArgumentNullException.ThrowIfNull(ids);

            IEnumerable<TEntity> entities = await Query()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();

            await RemoveRange(entities);
        }

        public virtual async Task Update(TEntity? entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _dbSet.Update(entity);

            await Task.CompletedTask;
        }

        public virtual async Task UpdateRange(IEnumerable<TEntity>? entities)
        {
            ArgumentNullException.ThrowIfNull(entities);

            _dbSet.UpdateRange(entities);

            await Task.CompletedTask;
        }

        #region Custom methods
        public virtual IQueryable<TEntity> Query(bool track = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!track)
                query = query.AsNoTracking();

            return query;
        }
        public void ClearTracking() => _context.ChangeTracker.Clear();


        public string? GetConnectionString() => _context.Database.GetConnectionString();


        public virtual async Task SaveChanges() => await _context.SaveChangesAsync();


        public virtual async void UntrackEntity(TEntity entity) => _context.Entry(entity).State = EntityState.Detached;

        #endregion


    }
}
