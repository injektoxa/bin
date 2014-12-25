using KendoGridAjaxEditing.Infrastructure.Search;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces
{
    public interface IFilterStorage<TFilter>
    {
        void Save(TFilter filter, string filterKey);

        TFilter GetFilter(string filterKey);

        void Clear(string filterKey);
    }
}