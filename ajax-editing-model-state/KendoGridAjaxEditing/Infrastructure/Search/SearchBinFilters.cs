using System;
using System.Collections.Generic;
using KendoGridAjaxEditing.Enums;

namespace KendoGridAjaxEditing.Infrastructure.Search
{
    public class SearchBinFilters
    {
        public FilterType<string> BinName { get; set; }

        public int Id { get; set; }

        public BinStatuses Status { get; set; }

        public DateTime LastModifiedFrom { get; set; }

        public DateTime LastModifiedTo { get; set; }

        public string LastModifiedBy { get; set; }
    }
}