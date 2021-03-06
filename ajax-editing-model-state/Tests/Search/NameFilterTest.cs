﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using KendoGridAjaxEditing.Enums;
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
    public class TestSearchFilters
    {
        private IQueryable<BinViewModel> _bins;
        private ISearchFilter<BinViewModel, SearchBinFilters> _filter;

        [TestInitialize]
        public void Initialize()
        {
            _bins = ProductsListInitializer.InitFakeList().AsQueryable();
            _filter = new NameFilter();
        }

        [TestMethod]
        public void NameFilterApply_WithAnySearchType_ReturnRecordThatContainsAnyFilters()
        {
            var searchFilters = new SearchBinFilters
            {
                BinName = new FilterType<string>
                {
                    SearchType = SearchType.Any,
                    Values = new List<string> { "This", "bin1" }
                }
            };

            var result = _filter.Apply(_bins, searchFilters);

            Assert.AreEqual(_bins.Count(), result.Count());
        }

        [TestMethod]
        public void NameFilterApply_WithAllSearchType_ReturnRecordThatContainsAllFilters()
        {
            var searchFilters = new SearchBinFilters
            {
                BinName = new FilterType<string>
                {
                    SearchType = SearchType.All,
                    Values = new List<string> { "This", "bin1" }
                }
            };

            var result = _filter.Apply(_bins, searchFilters);

            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void NameFilterApply_WithNullField_ReturnNotChangedList()
        {
            var searchFilters = new SearchBinFilters();

            var result = _filter.Apply(_bins, searchFilters);

            Assert.AreEqual(result.Count(), _bins.Count());
        }

        [TestMethod]
        public void NameFilterApply_WithNullModel_ReturnNull()
        {
            var searchFilters = new SearchBinFilters();

            var result = _filter.Apply(null, searchFilters);

            Assert.IsNull(result);
        }
    }
}
