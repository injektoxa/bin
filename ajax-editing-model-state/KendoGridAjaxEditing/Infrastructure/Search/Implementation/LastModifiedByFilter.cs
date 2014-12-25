using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class LastModifiedByFilter : ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            if (query != null && filter != null && filter.LastModifiedBy != null && filter.LastModifiedBy.Values != null)
            {
                if (filter.LastModifiedBy.SearchType == SearchType.All)
                {
                    return query.Where(b => filter.LastModifiedBy.Values.TrueForAll(v => b.LastModifiedBy.Contains(v)));
                }

                if (filter.LastModifiedBy.SearchType == SearchType.Any)
                {
                    return query.Where(b => filter.LastModifiedBy.Values.Any(v => b.LastModifiedBy.Contains(v)));
                }
            }

            return query;
        }
    }
}