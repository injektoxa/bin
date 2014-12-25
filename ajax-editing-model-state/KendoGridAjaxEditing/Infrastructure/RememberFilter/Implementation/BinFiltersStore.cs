using KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation
{
    public class BinFiltersStore<TFilterStorage> : BaseFiltersStore<SearchBinFilters, TFilterStorage> where TFilterStorage : IFilterStorage<SearchBinFilters>
    {
        public override string GetFilterKey()
        {
            return FilterTypes.SearchBinFilters.ToString();
        }
    }
}