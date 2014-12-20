using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation
{
    public class BinFiltersStore : BaseFiltersStore<SearchBinFilters>
    {
        public override string GetFilterKey()
        {
            return FilterTypes.SearchBinFilters.ToString();
        }
    }
}