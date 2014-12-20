using System.Linq;

namespace KendoGridAjaxEditing.Infrastructure.Search.Interfaces
{
    public interface ISearchFilter<TEntity, in TFilter>
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> query, TFilter filter);
    }
}
