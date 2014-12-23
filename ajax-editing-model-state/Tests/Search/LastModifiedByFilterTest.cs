using System;
using System.Collections.Generic;
using System.Linq;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Implementation;
using KendoGridAjaxEditing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Search
{
    [TestClass]
    public class LastModifiedByFilterTest
    {
        private IList<BinViewModel> _productsList;
        private string _modifierName;

        [TestInitialize]
        public void Initialize()
        {
            _modifierName = "Alex";

            _productsList = new List<BinViewModel>(); 
            this.InitFakeList(_productsList);
        }

        [TestMethod]
        public void Apply_WithCorrectAndExistingName_Should_Return_All_Items()
        {
            var bins = _productsList.AsQueryable();
            var searchfilters = new SearchBinFilters()
            {
                LastModifiedBy = _modifierName
            };

            var filter = new LastModifiedByFilter();
            var rersult = filter.Apply(bins, searchfilters);

            Assert.AreEqual(bins.Count(), rersult.Count());
        }

        [TestMethod]
        public void Apply_WithEmptyName_Should_Not_Return_Any_Items()
        {
            var bins = _productsList.AsQueryable();
            var searchfilters = new SearchBinFilters()
            {
                LastModifiedBy = string.Empty
            };

            var filter = new LastModifiedByFilter();
            var rersult = filter.Apply(bins, searchfilters);

            Assert.AreEqual(bins.Count(), rersult.Count());
        }

        private void InitFakeList(IList<BinViewModel> productsList)
        {
            for (int i = 0; i < 10; i++)
            {
                productsList.Add(new BinViewModel
                {
                    LastModifiedBy = string.Concat(_modifierName, -i)
                });
            }
        }
    }
}