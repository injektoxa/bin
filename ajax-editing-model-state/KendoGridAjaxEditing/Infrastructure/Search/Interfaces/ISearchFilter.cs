using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KendoGridAjaxEditing.Infrastructure.Search.Interfaces
{
    public interface ISearchFilter<TEntity, in TFilter>
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> query, TFilter filter);
    }
}
