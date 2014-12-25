using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.Implementation;

namespace KendoGridAjaxEditing.Infrastructure.Search
{
    public class FilterType<T>
    {
        public FilterType()
        {
            Values = new List<T>();
        }

        public IList<T> Values { get; set; }

        public SearchType SearchType { get; set; }
    }
}