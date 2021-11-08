using AutoMapper;
using Cryptos.Application.Services.Dtos;
using Cryptos.Core.Filtering;
using Cryptos.Domain.Entities;
using System.Linq;

namespace Cryptos.Application.Services
{
    public abstract class ApplicationService : IApplicationService
    {
        /// <summary>
        /// Represents a type used to perform mapping.
        /// </summary>
        protected readonly IMapper Mapper;

        public ApplicationService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }

    /// <summary>
    /// Service which provides an abstraction of <typeparamref name="TRepository"/>
    /// </summary>
    /// <typeparam name="TEntity">Represents an <see cref="IEntity{TPrimaryKey}"/> used for data representation.</typeparam>
    /// <typeparam name="TPrimaryKey">Represents the type of the primary key of <typeparamref name="TRepository"/>-related entities.</typeparam>
    /// <typeparam name="TRepository">Represents a repository which implements <see cref="IRepository{TEntity, TPrimaryKey}"/></typeparam>
    /// <typeparam name="TCreationInputDto">Represents an <see cref="IEntityDto"/> used to create entities.</typeparam>
    /// <typeparam name="TUpdateInputDto">Represents an <see cref="IEntityDto"/> used to update entities.</typeparam>
    /// <typeparam name="TEntityReadingDto">Represents an <see cref="IEntityDto"/> used for read-only data representation.</typeparam>
    public abstract class ApplicationService<TEntity, TPrimaryKey, TRepository, TCreationInputDto, TUpdateInputDto, TEntityReadingDto>
        : ApplicationService
        , IApplicationService<TPrimaryKey, TCreationInputDto, TUpdateInputDto, TEntityReadingDto>
        where TEntity : class, IEntity<TPrimaryKey>
        where TRepository : IRepository<TEntity, TPrimaryKey>
        where TCreationInputDto : class, IEntityDto
        where TUpdateInputDto : class, IEntityDto<TPrimaryKey>
        where TEntityReadingDto : class, IEntityDto
    {
        /// <summary>
        /// Represents a type to perform repository operations.
        /// </summary>
        protected readonly TRepository Repository;

        /// <summary>
        /// Creates an instance of this class with all needed dependencies.
        /// </summary>
        /// <param name="mapper">Represents a type used to perform mapping in this service.</param>
        /// <param name="repository">Represents a type to perform repository operations in this service.</param>
        public ApplicationService(IMapper mapper, TRepository repository)
            : base(mapper)
        {
            Repository = repository;
        }

        /// <summary>
        /// Deletes an entity by its primary key.
        /// </summary>
        /// <param name="id">Primary key of the entity to delete.</param>
        public virtual void DeleteById(TPrimaryKey id)
        {
            var entity = Repository.GetById(id);

            Repository.DeleteById(id);
        }

        /// <summary>
        /// Gets all entities mapped to <typeparamref name="TEntityReadingDto"/>.
        /// </summary>
        /// <param name="pagingOptions">Optional parameter to page the results.</param>
        /// <returns>The requested data, indicating paging-related info, if any.</returns>
        public virtual IPagedEnumerable<TEntityReadingDto> GetAll(IPagingOptions pagingOptions = null)
        {
            var result = Repository.GetAll(pagingOptions);

            return new PagedEnumerable<TEntityReadingDto>()
            {
                TotalCount = result.TotalCount,
                CurrentPage = result.CurrentPage,
                Items = result.Items.Select(Mapper.Map<TEntityReadingDto>).ToList()
            };
        }

        /// <summary>
        /// Gets an entity by its primary key mapped to <typeparamref name="TEntityReadingDto"/>.
        /// </summary>
        /// <param name="id">Primary key of the requested entity.</param>
        /// <returns>An instance of <typeparamref name="TEntityReadingDto"/> representing the requested entity or null if it does not exist.</returns>
        public virtual TEntityReadingDto GetById(TPrimaryKey id)
        {
            var result = Repository.GetById(id);

            return Mapper.Map<TEntityReadingDto>(result);
        }

        /// <summary>
        /// Creates and inserts a new entity.
        /// </summary>
        /// <param name="entityDto">Representation of the entity to create.</param>
        /// <returns>An instance of <typeparamref name="TEntityReadingDto"/> representing the newly created entity.</returns>
        public virtual TEntityReadingDto Insert(TCreationInputDto entityDto)
        {
            var entity = Mapper.Map<TEntity>(entityDto);

            entity = Repository.Insert(entity);

            return Mapper.Map<TEntityReadingDto>(entity);
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entityDto">Representation of the entity to update.</param>
        /// <returns>An instance of <typeparamref name="TEntityReadingDto"/> representing the newly updated entity.</returns>
        public virtual TEntityReadingDto Update(TUpdateInputDto entityDto)
        {
            var entity = Repository.GetById(entityDto.Id);

            Mapper.Map(entityDto, entity);

            Repository.Update(entity);

            entity = Repository.GetById(entity.Id);

            return Mapper.Map<TEntityReadingDto>(entity);
        }
    }
}