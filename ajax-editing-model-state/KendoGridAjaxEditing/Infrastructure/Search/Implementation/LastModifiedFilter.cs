using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class LastModifiedFilter : ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            if (query != null && filter != null)
            {
                query = query.Where(b => b.LastModified >= filter.LastModifiedFrom && b.LastModified <= filter.LastModifiedTo);
            }

            return query;
        }
    }
}