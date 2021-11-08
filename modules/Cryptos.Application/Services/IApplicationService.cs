using Cryptos.Application.Services.Dtos;
using Cryptos.Core.Filtering;

namespace Cryptos.Application.Services
{
    /// <summary>
    /// Contract that represents an application service. Every application service should implement this simple interface.
    /// </summary>
    public interface IApplicationService
    {
    }

    /// <summary>
    /// Contract that represents a CRUD application service.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Represents the type of the primary key of the entities related to this service.</typeparam>
    /// <typeparam name="TCreationInputDto">Represents an <see cref="IEntityDto"/> used to create entities.</typeparam>
    /// <typeparam name="TUpdateInputDto">Represents an <see cref="IEntityDto"/> used to update entities.</typeparam>
    /// <typeparam name="TEntityReadingDto">Represents an <see cref="IEntityDto"/> used for read-only data representation.</typeparam>
    public interface IApplicationService<TPrimaryKey, in TCreationInputDto, in TUpdateInputDto, TEntityReadingDto>
        : IApplicationService
        where TCreationInputDto : IEntityDto
        where TUpdateInputDto : IEntityDto<TPrimaryKey>
        where TEntityReadingDto : IEntityDto
    {
        /// <summary>
        /// Deletes an entity by its primary key.
        /// </summary>
        /// <param name="id">Primary key of the entity to delete.</param>
        void DeleteById(TPrimaryKey id);

        /// <summary>
        /// Gets all entities mapped to <typeparamref name="TEntityReadingDto"/>.
        /// </summary>
        /// <param name="pagingOptions">Optional parameter to page the results.</param>
        /// <returns>The requested data, indicating paging-related info, if any.</returns>
        IPagedEnumerable<TEntityReadingDto> GetAll(IPagingOptions pagingOptions = null);

        /// <summary>
        /// Gets an entity by its primary key mapped to <typeparamref name="TEntityReadingDto"/>.
        /// </summary>
        /// <param name="id">Primary key of the requested entity.</param>
        /// <returns>An instance of <typeparamref name="TEntityReadingDto"/> representing the requested entity or null if it does not exist.</returns>
        TEntityReadingDto GetById(TPrimaryKey id);

        /// <summary>
        /// Creates and inserts a new entity.
        /// </summary>
        /// <param name="entityDto">Representation of the entity to create.</param>
        /// <returns>An instance of <typeparamref name="TEntityReadingDto"/> representing the newly created entity.</returns>
        TEntityReadingDto Insert(TCreationInputDto entityDto);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entityDto">Representation of the entity to update.</param>
        /// <returns>An instance of <typeparamref name="TEntityReadingDto"/> representing the newly updated entity.</returns>
        TEntityReadingDto Update(TUpdateInputDto entityDto);
    }
}