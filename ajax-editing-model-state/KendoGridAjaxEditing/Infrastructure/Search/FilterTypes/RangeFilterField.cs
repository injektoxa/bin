namespace KendoGridAjaxEditing.Infrastructure.Search.FilterTypes
{
    public class RangeFilterField<TFieldType>
    {
        public TFieldType From { get; set; }

        public TFieldType To { get; set; }
    }
}