using System.Collections.Generic;
using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class StatusFilter : ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            if (query != null && filter != null && filter.Status != null && filter.Status.Values != null)
            {
                if (filter.Status.SearchType == SearchType.All)
                {
                    return query.Where(b => filter.Status.Values.TrueForAll(v => b.Status.Equals(v.ToString())));
                }

                if (filter.Status.SearchType == SearchType.Any)
                {
                    return query.Where(b => filter.Status.Values.Any(v => b.Status.Equals(v.ToString())));
                }
            }

            return query;
        }
    }
}