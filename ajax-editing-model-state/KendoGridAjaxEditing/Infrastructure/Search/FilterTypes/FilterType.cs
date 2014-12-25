using System.Collections.Generic;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;

namespace KendoGridAjaxEditing.Infrastructure.Search.FilterTypes
{
    public class FilterType<T>
    {
         public SearchType SearchType { get; set; }

        public List<T> Values { get; set; }
    }
}