using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class AgencyFilter : ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            if (query != null && filter != null && filter.Agency != null && filter.Agency.Values != null)
            {
                if (filter.Agency.SearchType == SearchType.All)
                {
                    query = query.Where(b => filter.Agency.Values.TrueForAll(v => b.Agency.Name.Contains(v)));
                }

                if (filter.Agency.SearchType == SearchType.Any)
                {
                    query = query.Where(b => filter.Agency.Values.Any(v => b.Agency.Name.Contains(v)));
                }
            }

            return query;
        }
    }
}