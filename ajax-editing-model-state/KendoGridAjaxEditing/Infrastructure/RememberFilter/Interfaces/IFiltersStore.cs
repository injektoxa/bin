using System.Web;

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