using System;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.FilterTypes;
using KendoGridAjaxEditing.Infrastructure.Search.FilterTypes;

namespace KendoGridAjaxEditing.Infrastructure.Search
{
    public class SearchBinFilters
    {
        public string BinName { get; set; }

        public int Id { get; set; }

        public BinStatuses Status { get; set; }

        public FilterType<RangeFilterField<DateTime>> LastModified { get; set; }

        public FilterType<string> LastModifiedBy { get; set; }
    }
}