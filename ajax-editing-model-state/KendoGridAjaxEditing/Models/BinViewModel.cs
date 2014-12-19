using System;

namespace KendoGridAjaxEditing.Models
{
    public class BinViewModel
    {
        public int ID { get; set; }
        
        public string BinName { get; set; }
        
        public DateTime LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public string Status { set; get; }
    }
}