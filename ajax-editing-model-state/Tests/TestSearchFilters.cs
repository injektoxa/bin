using System;
using System.Collections.Generic;
using System.Linq;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Implementation;
using KendoGridAjaxEditing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestSearchFilters
    {
        [TestMethod]
        public void NameFilterApply_WithValidField_ReturnFilteredRecord()
        {
            var searchName = "FirstBin";
            var list = new List<BinViewModel>
            {
                new BinViewModel
                {
                    ID = 2345,
                    BinName = searchName,
                    LastModified = DateTime.Today,
                    LastModifiedBy = "Alex",
                    Status = BinStatuses.New.ToString()
                },
                new BinViewModel
                {
                    ID = 2345,
                    BinName = "SecondBin",
                    LastModified = DateTime.Today,
                    LastModifiedBy = "Alex",
                    Status = BinStatuses.New.ToString()
                }
            };
                
            var query = list.AsQueryable();
            var filter = new NameFilter();
            var searchFilters = new SearchBinFilters
            {
                BinName = searchName
            };

            var result = filter.Apply(query, searchFilters).ToList();

            Assert.AreEqual(result.Count, 1);
            Assert.IsTrue(result.First().BinName == searchName);
        }

        [TestMethod]
        public void NameFilterApply_WithNullField_ReturnNotChangedList()
        {
            var searchName = "FirstBin";
            var list = new List<BinViewModel>
            {
                new BinViewModel
                {
                    ID = 2345,
                    BinName = searchName,
                    LastModified = DateTime.Today,
                    LastModifiedBy = "Alex",
                    Status = BinStatuses.New.ToString()
                },
                new BinViewModel
                {
                    ID = 2345,
                    BinName = "SecondBin",
                    LastModified = DateTime.Today,
                    LastModifiedBy = "Alex",
                    Status = BinStatuses.New.ToString()
                }
            };

            var query = list.AsQueryable();
            var filter = new NameFilter();
            var searchFilters = new SearchBinFilters();

            var result = filter.Apply(query, searchFilters).ToList();

            Assert.AreEqual(result.Count, list.Count);
        }
    }
}
