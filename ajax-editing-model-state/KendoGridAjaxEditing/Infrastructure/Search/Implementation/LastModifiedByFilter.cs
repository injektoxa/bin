using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class LastModifiedByFilter : ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            if (query != null && filter != null && !string.IsNullOrEmpty(filter.LastModifiedBy))
            {
                query = query.Where(b => b.LastModifiedBy.Equals(filter.LastModifiedBy));
            }

            return query;
        }
    }
}