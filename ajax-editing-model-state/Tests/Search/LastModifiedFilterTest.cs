using System;
using System.Collections.Generic;
using System.Linq;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Implementation;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace Tests.Search
{
    [TestClass]
    public class LastModifiedFilterTest
    {
        private IQueryable<BinViewModel> _bins;
        private ISearchFilter<BinViewModel, SearchBinFilters> _filter;

        [TestInitialize]
        public void Initialize()
        {
            _bins = ProductsListInitializer.InitFakeList().AsQueryable();
            _filter = new LastModifiedFilter();
        }

        [TestMethod]
        public void Apply_WithCurrentDate_Should_Return_One_Item()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModifiedFrom = DateTime.Today,
                LastModifiedTo = DateTime.Today
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(rersult.Count(), 1);
        }

        [TestMethod]
        public void Apply_WithTheBiggestRange_Should_Return_All_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModifiedFrom = DateTime.MinValue,
                LastModifiedTo = DateTime.MaxValue
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(rersult.Count(), _bins.Count());
        }

        [TestMethod]
        public void Apply_WithIncorrectRange_Should_Not_Return_Any_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModifiedFrom = DateTime.MaxValue,
                LastModifiedTo = DateTime.MinValue
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(rersult.Count(), 0);
        }

        [TestMethod]
        public void Apply_WithNullSearchFilter_Should_Not_Return_Any_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModifiedFrom = DateTime.MaxValue,
                LastModifiedTo = DateTime.MinValue
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(rersult.Count(), 0);
        }
    }
}