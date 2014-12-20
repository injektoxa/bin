using KendoGridAjaxEditing.Infrastructure.Search;

namespace KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation
{
    public class BinFiltersStore : BaseFiltersStore<SearchBinFilters>
    {
        public override string GetFilterKey()
        {
            return "binSearchFilters";
        }
    }
}