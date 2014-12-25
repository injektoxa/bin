using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class LastModifiedFilter : ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            if (query != null && filter != null && filter.LastModified != null && filter.LastModified.Values != null)
            {
                if (filter.LastModified.SearchType == SearchType.All)
                {
                    return query.Where(b => filter.LastModified.Values.TrueForAll(v => b.LastModified >= v.From && b.LastModified <= v.To));
                }

                if (filter.LastModified.SearchType == SearchType.Any)
                {
                    query = query.Where(b => filter.LastModified.Values.Any(v => b.LastModified >= v.From && b.LastModified <= v.To));
                }
            }

            return query;
        }
    }
}