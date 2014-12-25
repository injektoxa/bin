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
            if (query != null && filter != null)
            {
                query = query.Where(b => b.Status.Equals(filter.Status.ToString()));
            }

            return query;
        }
    }
}