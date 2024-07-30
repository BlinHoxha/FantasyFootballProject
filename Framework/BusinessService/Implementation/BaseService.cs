
using AutoMapper;
using FluentValidation;
using Framework.BusinessService.Interface;
using Framework.DTO.Interface;
using Framework.Entities.Interface;
using Framework.Repository.Interface;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.BusinessService.Implementation
{
    /// <summary>
    /// The base service wrapping the base repository operations
    /// </summary>
    /// <typeparam name="TEntity">The main entity type</typeparam>
    /// <typeparam name="TEntityId">The type of the id of the <typeparamref name="TEntity"/></typeparam>
    public abstract class BaseService<TEntity, TEntityId> : IBaseService<TEntity, TEntityId> where TEntity : class, IBaseEntity<TEntityId>
    {
        /// <summary>
        /// The <see cref="IBaseRepository{TEntity, TEntityId}"/> repository instance
        /// </summary>
        protected readonly IBaseRepository<TEntity, TEntityId> _repository;

        /// <summary>
        /// The <see cref="ILogger"/> instance
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// The instance of <see cref="IMapper"/>
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// The instance of <see cref="IValidator"/>
        /// </summary>
        protected readonly IValidator _validator;

        /// <summary>
        /// Returns a instance of <see cref="BaseService{TEntity, TEntityId}"/>
        /// </summary>
        /// <param name="repository">The <see cref="IBaseRepository{TEntity, TEntityId}"/> instance used to accesss data</param>
        /// <param name="logger">The <see cref="ILogger"/> instance</param>
        /// <param name="mapper">The <see cref="IMapper"/> instance used to perform mapping between DTO e Db models</param>
        /// <param name="validator">The <see cref="IValidator"/> instance used to perform validation</param>
        protected BaseService(IBaseRepository<TEntity, TEntityId> repository,
            ILogger logger,
            IMapper mapper,
            IValidator validator) : base()
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _validator = validator;
        }

        ///<inheritdoc/>
        public virtual async Task<IEnumerable<TMap?>> GetAllAsync<TMap>() where TMap : class
        {
            if (_repository == null)
            {
                throw new ArgumentNullException(nameof(_repository));
            }

            return await _repository.GetAllAsync<TMap>();
        }

        //public virtual async Task<IEnumerable<TMap?>> GetAllAsync<TMap>() where TMap : class
        //{
        //    return await _repository.GetAllAsync<TMap>();
        //}

        ///<inheritdoc/>
        public virtual async Task<TMap?> GetById<TMap>(TEntityId id) where TMap : class, IBaseDtoEntity<TEntityId>
        {
            ArgumentNullException.ThrowIfNull(id);

            return await _repository.GetById<TMap>(id);
        }

        ///<inheritdoc/>
        public virtual async Task<TEntityId?, TValidation> Add<TMap>(TMap dto) where TMap : class
        {
            ArgumentNullException.ThrowIfNull(dto);

            TEntity entity = _mapper.Map<TEntity>(dto);

            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            await _repository.Add(entity);
            await _repository.SaveChanges();

            _logger.LogTrace("Added entity with id {entityId}", entity.Id!);

            return entity.Id;
        }

        ///<inheritdoc/>
        public virtual async Task AddRange<TMap>(IEnumerable<TMap> dtos) where TMap : class
        {
            ArgumentNullException.ThrowIfNull(dtos);

            IEnumerable<TEntity> entities = _mapper.Map<IEnumerable<TEntity>>(dtos);
            await _repository.AddRange(entities);
            await _repository.SaveChanges();
        }

        ///<inheritdoc/>
        public virtual async Task<TEntityId?> Update<TMap>(TMap dto) where TMap : class
        {
            ArgumentNullException.ThrowIfNull(dto);

            TEntity entity = _mapper.Map<TEntity>(dto);
            await _repository.Update(entity);
            await _repository.SaveChanges();

            _logger.LogTrace("Updated entity with id {entityId}", entity.Id);

            return entity.Id;
        }

        ///<inheritdoc/>
        public virtual async Task UpdateRange<TMap>(IEnumerable<TMap> dtos) where TMap : class
        {
            ArgumentNullException.ThrowIfNull(dtos);

            IEnumerable<TEntity> entities = _mapper.Map<IEnumerable<TEntity>>(dtos);
            await _repository.UpdateRange(entities);
            await _repository.SaveChanges();
        }

        ///<inheritdoc/>
        public virtual async Task Remove(TEntityId? id)
        {
            ArgumentNullException.ThrowIfNull(id);

            await _repository.Remove(id);
            await _repository.SaveChanges();

            _logger.LogTrace("Removed entity with id {entityId}", id);
        }

        ///<inheritdoc/>
        public virtual async Task RemoveRange(IEnumerable<TEntityId>? ids)
        {
            ArgumentNullException.ThrowIfNull(ids);

            await _repository.RemoveRange(ids);
            await _repository.SaveChanges();
        }

    }
}
