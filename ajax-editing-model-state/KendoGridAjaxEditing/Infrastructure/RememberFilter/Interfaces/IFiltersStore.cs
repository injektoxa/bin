using System.Web;
using System.Web.SessionState;
using KendoGridAjaxEditing.Infrastructure.Search;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces
{
    public interface IFiltersStore<TFilter> where TFilter : class, new()
    {
        string GetFilterKey();

        void SaveFilter(TFilter filter, HttpSessionStateBase session);

        TFilter GetFilter(HttpSessionStateBase session);

        void ResetFilter(HttpSessionStateBase session);
    }
}