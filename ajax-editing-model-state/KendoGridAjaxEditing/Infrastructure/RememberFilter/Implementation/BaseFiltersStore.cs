using System.Collections;
using System.Web;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation
{
    public abstract class BaseFiltersStore<TFilter, TFilterStorage> : IFiltersStore<TFilter, TFilterStorage>
        where TFilter : class, new()
        where TFilterStorage : IFilterStorage<TFilter>
    {
        public abstract string GetFilterKey();

        public TFilterStorage Storage { get; set; }

        public void SaveFilter(TFilter filter) 
        {
            Storage.Save(filter, this.GetFilterKey());
        }

        public TFilter GetFilter()
        {
            return Storage.GetFilter(this.GetFilterKey());
        }

        public void ResetFilter()
        {
            Storage.Clear(this.GetFilterKey());
        }
    }
}