using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Services.Description;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;

namespace KendoGridAjaxEditing.Infrastructure.Search.Implementation
{
    public class NameFilter: ISearchFilter<BinViewModel, SearchBinFilters>
    {
        public IQueryable<BinViewModel> Apply(IQueryable<BinViewModel> query, SearchBinFilters filter)
        {
            var isSearchByAll = filter.BinName.SearchType == SearchType.All;
            ParameterExpression argParam = Expression.Parameter(typeof(BinViewModel), "x");
            Expression nameProperty = Expression.Property(argParam, "BinName");
            Expression expression = Expression.Constant(isSearchByAll);

            if (query != null && filter != null && filter.BinName != null && filter.BinName.Values.Any())
            {
                foreach (var value in filter.BinName.Values)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        var property = Expression.Call(nameProperty, "Contains", null, Expression.Constant(value));
                        expression = isSearchByAll ? Expression.And(expression, property) : Expression.Or(expression, property);
                    }
                }

                var lambda = Expression.Lambda<Func<BinViewModel, bool>>(expression, argParam);
                query = query.Where(lambda);
            }

            return query;
        }
    }
}