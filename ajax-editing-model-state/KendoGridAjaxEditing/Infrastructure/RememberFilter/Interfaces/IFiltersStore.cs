using System.Collections;
using System.Web;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces
{
    public interface IFiltersStore<TFilter, TFilterStorage>
        where TFilter : class, new()
        where TFilterStorage : IFilterStorage<TFilter>
    {
        TFilterStorage Storage { get; set; }

        string GetFilterKey();

        void SaveFilter(TFilter filter);

        TFilter GetFilter();

        void ResetFilter();
    }
}