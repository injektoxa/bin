using System.Web;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces;
using KendoGridAjaxEditing.Infrastructure.Search;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation
{
    public class SessionFilterStorage<TFilter> : IFilterStorage<TFilter> where TFilter : class, new()
    {
        public HttpSessionStateBase Storage { get; set; }

        public void Save(TFilter filter, string filterKey)
        {
            Storage[filterKey] = filter;
        }

        public TFilter GetFilter(string filterKey)
        {
            return (Storage[filterKey] ?? new TFilter()) as TFilter;
        }

        public void Clear(string filterKey)
        {
            Storage[filterKey] = new TFilter();
        }
    }
}