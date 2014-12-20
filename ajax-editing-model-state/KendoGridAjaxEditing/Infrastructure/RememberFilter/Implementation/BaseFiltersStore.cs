using System.Web;
using System.Web.SessionState;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces;
using KendoGridAjaxEditing.Infrastructure.Search;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation
{
    public abstract class BaseFiltersStore<TFilter> : IFiltersStore<TFilter> where TFilter : class, new()
    {
        public abstract string GetFilterKey();

        public void SaveFilter(TFilter filter, HttpSessionStateBase session) 
        {
            session[this.GetFilterKey()] = filter;
        }

        public TFilter GetFilter(HttpSessionStateBase session)
        {
            return (session[this.GetFilterKey()] ?? new TFilter()) as TFilter;
        }

        public void ResetFilter(HttpSessionStateBase session)
        {
            session[this.GetFilterKey()] = new TFilter();
        }
    }
}