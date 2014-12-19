using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KendoGridAjaxEditing.Infrastructure.Search.Implementation;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search
{
    public class FiltersFactory
    {
        public static IEnumerable<ISearchFilter<BinViewModel, SearchBinFilters>> BinSearch = new List<ISearchFilter<BinViewModel, SearchBinFilters>>
        {
            new NameFilter()
        };
    }
}