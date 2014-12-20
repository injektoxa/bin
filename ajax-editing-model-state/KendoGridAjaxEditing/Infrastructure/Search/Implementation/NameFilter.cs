using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class NameFilter: ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            if (query != null && filter != null && !string.IsNullOrEmpty(filter.BinName))
            {
                query = query.Where(b => b.BinName.Contains(filter.BinName));
            }

            return query;
        }
    }
}