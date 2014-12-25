using System;
using System.Collections.Generic;
using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.FilterTypes;
using KendoGridAjaxEditing.Infrastructure.Search.Implementation;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace Tests.Search
{
    [TestClass]
    public class IdFilterTest
    {
        private IQueryable<BinViewModel> _bins;
        private ISearchFilter<BinViewModel, SearchBinFilters> _filter;

        [TestInitialize]
        public void Initialize()
        {
            _bins = ProductsListInitializer.InitFakeList().AsQueryable();
            _filter = new IdFilter();
        }

        [TestMethod]
        public void IdFilterApply_WithValidValue_ReturnOneRecord()
        {
            var searchFilters = new SearchBinFilters
            {
                Id = new FilterType<int>
                {
                    Values = new List<int> { 1 }
                }
            };

            var result = _filter.Apply(_bins, searchFilters);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void IdFilterApply_WithEmptyValue_ReturnNoRecord()
        {
            var searchFilters = new SearchBinFilters
            {
                Id = new FilterType<int>
                {
                    Values = new List<int>()
                }
            };

            var result = _filter.Apply(_bins, searchFilters);

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void IdFilterApply_WithNullList_ReturnNull()
        {
            var searchFilters = new SearchBinFilters();

            var result = _filter.Apply(null, searchFilters);

            Assert.IsNull(result);
        }
    }
}
