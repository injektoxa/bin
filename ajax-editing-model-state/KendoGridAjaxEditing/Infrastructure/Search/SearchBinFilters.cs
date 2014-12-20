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

        public DateTime LastModifiedFrom { get; set; }

        public DateTime LastModifiedTo { get; set; }

        public string LastModifiedBy { get; set; }
    }
}