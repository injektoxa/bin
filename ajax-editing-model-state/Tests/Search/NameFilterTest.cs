using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
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
        public void NameFilterApply_WithValidField_ReturnFilteredRecord()
        {
            var searchName = "This is test bin1";
            var list = new List<BinViewModel>
            {
                new BinViewModel
                {
                    ID = 2345,
                    BinName = "Test bin",
                    LastModified = DateTime.Today.AddDays(-1),
                    LastModifiedBy = "user",
                    Status = BinStatuses.New.ToString()
                },
                new BinViewModel
                {
                    ID = 2345,
                    BinName = "Hi all",
                    LastModified = DateTime.Today.AddDays(-1),
                    LastModifiedBy = "user",
                    Status = BinStatuses.New.ToString()
                },
                new BinViewModel
                {
                    ID = 2345,
                    BinName = "ohh",
                    LastModified = DateTime.Today.AddDays(-1),
                    LastModifiedBy = "user",
                    Status = BinStatuses.New.ToString()
                }
            };

            var qr = list.AsQueryable();
            var searchFilters = new SearchBinFilters
            {
                BinName = new FilterType<string>
                {
                    SearchType = SearchType.All,
                    Values = new List<string> { "Hi", "all" }
                }
            };

            var result = _filter.Apply(qr, searchFilters);

            Assert.AreEqual(2, result.Count());
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
