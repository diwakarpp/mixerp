// ReSharper disable All
using System.Collections.Generic;
using System.Dynamic;
using PetaPoco;

namespace MixERP.Net.Schemas.Core.Data
{
    public interface IBonusSlabSelectorViewRepository
    {
        /// <summary>
        /// Performs count on IBonusSlabSelectorViewRepository.
        /// </summary>
        /// <returns>Returns the number of IBonusSlabSelectorViewRepository.</returns>
        long Count();

        /// <summary>
        /// Return all instances of the "BonusSlabSelectorView" class from IBonusSlabSelectorViewRepository. 
        /// </summary>
        /// <returns>Returns a non-live, non-mapped instances of "BonusSlabSelectorView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.BonusSlabSelectorView> Get();

        /// <summary>
        /// Displayfields provide a minimal name/value context for data binding IBonusSlabSelectorViewRepository.
        /// </summary>
        /// <returns>Returns an enumerable name and value collection for IBonusSlabSelectorViewRepository.</returns>
        IEnumerable<DisplayField> GetDisplayFields();

        /// <summary>
        /// Produces a paginated result of 10 items from IBonusSlabSelectorViewRepository.
        /// </summary>
        /// <returns>Returns the first page of collection of "BonusSlabSelectorView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.BonusSlabSelectorView> GetPaginatedResult();

        /// <summary>
        /// Produces a paginated result of 10 items from IBonusSlabSelectorViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result.</param>
        /// <returns>Returns collection of "BonusSlabSelectorView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.BonusSlabSelectorView> GetPaginatedResult(long pageNumber);

        List<EntityParser.Filter> GetFilters(string catalog, string filterName);

        /// <summary>
        /// Performs a filtered count on IBonusSlabSelectorViewRepository.
        /// </summary>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns number of rows of "BonusSlabSelectorView" class using the filter.</returns>
        long CountWhere(List<EntityParser.Filter> filters);

        /// <summary>
        /// Produces a paginated result of 10 items using the supplied filters from IBonusSlabSelectorViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns collection of "BonusSlabSelectorView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.BonusSlabSelectorView> GetWhere(long pageNumber, List<EntityParser.Filter> filters);

        /// <summary>
        /// Performs a filtered count on IBonusSlabSelectorViewRepository.
        /// </summary>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns number of rows of "BonusSlabSelectorView" class using the filter.</returns>
        long CountFiltered(string filterName);

        /// <summary>
        /// Produces a paginated result of 10 items using the supplied filter name from IBonusSlabSelectorViewRepository.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the paginated result. If you provide a negative number, the result will not be paginated.</param>
        /// <param name="filterName">The named filter.</param>
        /// <returns>Returns collection of "BonusSlabSelectorView" class.</returns>
        IEnumerable<MixERP.Net.Entities.Core.BonusSlabSelectorView> GetFiltered(long pageNumber, string filterName);


    }
}