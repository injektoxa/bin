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
        public void Apply_WithCurrentDateAndTypeSearchAll_Should_Return_One_Item()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModified = new FilterType<RangeFilterField<DateTime>>()
                {
                    SearchType = SearchType.All,
                    Values = new List<RangeFilterField<DateTime>>()
                    {
                        new RangeFilterField<DateTime>()
                        {
                            From = DateTime.Today,
                            To = DateTime.Today
                        },
                        new RangeFilterField<DateTime>()
                        {
                            From = DateTime.MinValue,
                            To = DateTime.MaxValue
                        }
                    }
                }
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(rersult.Count(), 1);
        }

        [TestMethod]
        public void Apply_WithTypeSearchAny_Should_Return_All_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModified = new FilterType<RangeFilterField<DateTime>>()
                {
                    SearchType = SearchType.Any,
                    Values = new List<RangeFilterField<DateTime>>()
                    {
                        new RangeFilterField<DateTime>()
                        {
                            From = DateTime.Today,
                            To = DateTime.Today
                        },
                        new RangeFilterField<DateTime>()
                        {
                            From = DateTime.MinValue,
                            To = DateTime.MaxValue
                        }
                    }
                }
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(rersult.Count(), _bins.Count());
        }

        [TestMethod]
        public void Apply_WithTheBiggestRange_Should_Return_All_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModified = new FilterType<RangeFilterField<DateTime>>()
                {
                    SearchType = SearchType.All,
                    Values = new List<RangeFilterField<DateTime>>()
                    {
                        new RangeFilterField<DateTime>()
                        {
                            From = DateTime.MinValue,
                            To = DateTime.MaxValue
                        }
                    }
                }
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(rersult.Count(), _bins.Count());
        }

        [TestMethod]
        public void Apply_WithIncorrectRange_Should_Not_Return_Any_Items()
        {
            var searchfilters = new SearchBinFilters()
            {
                LastModified = new FilterType<RangeFilterField<DateTime>>()
                {
                    SearchType = SearchType.All,
                    Values = new List<RangeFilterField<DateTime>>()
                    {
                        new RangeFilterField<DateTime>()
                        {
                            From = DateTime.MaxValue,
                            To = DateTime.MinValue
                        }
                    }
                }
            };

            var rersult = _filter.Apply(_bins, searchfilters);

            Assert.AreEqual(rersult.Count(), 0);
        }

        [TestMethod]
        public void Apply_WithNullSearchFilter_Should_Return_Equal_Items()
        {
            var rersult = _filter.Apply(_bins, null);

            Assert.AreEqual(rersult, _bins);
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