using System;
using System.Collections.Generic;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.FilterTypes;

namespace KendoGridAjaxEditing.Infrastructure.Search
{
    public class SearchBinFilters
    {
        public FilterType<string> BinName { get; set; }

        public FilterType<int> Id { get; set; }

        public FilterType<string> Agency { get; set; }

        public FilterType<BinStatuses> Status { get; set; }

        public FilterType<RangeFilterField<DateTime>> LastModified { get; set; }

        public FilterType<string> LastModifiedBy { get; set; }
    }
}