using System;
using System.Collections.Generic;
using System.Linq;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Implementation;
using KendoGridAjaxEditing.Infrastructure.Search.Interfaces;
using KendoGridAjaxEditing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Helpers;

namespace Tests.Search
{
    [TestClass]
    public class LastModifiedByFilterTest
    {
        private string _modifierName;
        private IQueryable<BinViewModel> _bins;
        private ISearchFilter<BinViewModel, SearchBinFilters> _filter;
            
        [TestInitialize]
        public void Initialize()
        {
            _modifierName = "Alex";

            _bins = ProductsListInitializer.InitFakeList().AsQueryable();
            _filter = new LastModifiedByFilter();
        }

        [TestMethod]
        public void Apply_WithCorrectAndExistingName_Should_Return_All_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModifiedBy = _modifierName
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(_bins.Count(), rersult.Count());
        }

        [TestMethod]
        public void Apply_WithEmptyName_Should_All_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModifiedBy = string.Empty
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(_bins.Count(), rersult.Count());
        }

        [TestMethod]
        public void Apply_WithNullBinList_Should_Return_Null()
        {
            var searchfilters = new SearchBinFilters();

            var rersult = _filter.Apply(null, searchfilters);

            Assert.IsNull(rersult);
        }
    }
}