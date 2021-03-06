﻿using System.Collections.Generic;
using System.Linq;
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
    public class StatusFilterTest
    {
        private IQueryable<BinViewModel> _bins;
        private ISearchFilter<BinViewModel, SearchBinFilters> _filter;
        private BinStatuses _defaultStatus;

        [TestInitialize]
        public void Initialize()
        {
            _bins = ProductsListInitializer.InitFakeList().AsQueryable();
            _filter = new StatusFilter();
            _defaultStatus = BinStatuses.New;
        }

        [TestMethod]
        public void Apply_WithDefaultStatus_Should_Return_All_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                Status = new FilterType<BinStatuses>()
                {
                    SearchType = SearchType.Any,
                    Values = new List<BinStatuses>()
                    {
                        _defaultStatus
                    }
                }
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(_bins.Count(), rersult.Count());
        }

        [TestMethod]
        public void Apply_WithNotDefaultStatus_Should_Return_Not_All_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                Status = new FilterType<BinStatuses>()
                {
                    SearchType = SearchType.Any,
                    Values = new List<BinStatuses>()
                    {
                        BinStatuses.Edited
                    }
                }
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreNotEqual(_bins.Count(), rersult.Count());
        }

        [TestMethod]
        public void Apply_WithNotDefaultStatusAndSearchTypeAny_Should_Return_All_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                Status = new FilterType<BinStatuses>()
                {
                    SearchType = SearchType.Any,
                    Values = new List<BinStatuses>()
                    {
                        BinStatuses.Edited,
                        _defaultStatus
                    }
                }
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(_bins.Count(), rersult.Count());
        }

        [TestMethod]
        public void Apply_WithDefferentStatusesAndSearchTypeAll_Should_Not_Return_Any_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                Status = new FilterType<BinStatuses>()
                {
                    SearchType = SearchType.All,
                    Values = new List<BinStatuses>()
                    {
                        BinStatuses.Edited,
                        _defaultStatus
                    }
                }
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreNotEqual(_bins.Count(), rersult.Count());
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