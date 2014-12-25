using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoGridAjaxEditing.Infrastructure.Search.FilterTypes
{
    public class RangeFilterField<TFieldType>
    {
        public TFieldType From { get; set; }

        public TFieldType To { get; set; }
    }
}