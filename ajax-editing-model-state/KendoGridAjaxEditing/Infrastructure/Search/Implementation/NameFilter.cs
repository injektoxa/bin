using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Web.Services.Description;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class NameFilter : ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            if (query != null && filter != null && filter.BinName != null && filter.BinName.Values != null)
            {
                if (filter.BinName.SearchType == SearchType.All)
                {
                    query = query.Where(b => filter.BinName.Values.TrueForAll(v => b.BinName.Contains(v)));
                }

                if (filter.BinName.SearchType == SearchType.Any)
                {
                    query = query.Where(b => filter.BinName.Values.Any(v => b.BinName.Contains(v)));
                }
            }

            return query;
        }
    }
}