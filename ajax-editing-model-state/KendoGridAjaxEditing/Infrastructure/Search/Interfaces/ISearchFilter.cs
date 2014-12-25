using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;

namespace KendoGridAjaxEditing.Infrastructure.Search.Interfaces
{
    public interface ISearchFilter<TEntity, in TFilter>
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> query, TFilter filter);
    }
}
