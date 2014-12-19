using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KendoGridAjaxEditing.Enums;

namespace KendoGridAjaxEditing.Infrastructure.Search
{
    public class SearchBinFilters
    {
        public string BinName { get; set; }

        public int ID { get; set; }

        public BinStatuses Status { get; set; }
    }
}