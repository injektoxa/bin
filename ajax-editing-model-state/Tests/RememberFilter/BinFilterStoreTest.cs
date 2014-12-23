using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces;
using KendoGridAjaxEditing.Infrastructure.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.RememberFilter
{
    [TestClass]
    public class BinFilterStoreTest
    {
        private IFiltersStore<SearchBinFilters> _filtersStore;

        [TestInitialize]
        public void Initialize()
        {
            _filtersStore = new BinFiltersStore();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SaveFilter_WithNullSession_Should_Throw_NullReferenceException()
        {
            _filtersStore.SaveFilter(new SearchBinFilters(), null);
        }

        [TestMethod]
        public void SaveAndGetFilter_CorrectParams_Should_Return_Equal_Object()
        {
            var session = new MockHttpSession();
            var filterToSet = this.InitBinFilters();

            _filtersStore.SaveFilter(filterToSet, session);
            var filterToGet = _filtersStore.GetFilter(session);

            Assert.AreEqual(filterToSet, filterToGet);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetFilter_WithNullSession_Should_Throw_NullReferenceException()
        {
            _filtersStore.GetFilter(null);
        }

        public void ResetFilter_Should_Return_Clear_Filter_Object()
        {
            var session = new MockHttpSession();
            var filterToSet = this.InitBinFilters();

            _filtersStore.SaveFilter(filterToSet, session);
            _filtersStore.ResetFilter(session);

            var filterToGet = _filtersStore.GetFilter(session);

            Assert.AreNotEqual(filterToSet, filterToGet);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ResetFilter_WithNullSession_Should_Throw_NullReferenceException()
        {
            _filtersStore.ResetFilter(null);
        }

        private SearchBinFilters InitBinFilters()
        {
            return new SearchBinFilters()
            {
                Id = 2345,
                BinName = "This is test bin",
                LastModifiedBy = "Alex",
                Status = BinStatuses.New
            };
        }

        private class MockHttpSession : HttpSessionStateBase
        {
            Dictionary<string, object> m_SessionStorage = new Dictionary<string, object>();

            public override object this[string name]
            {
                get { return m_SessionStorage[name]; }
                set { m_SessionStorage[name] = value; }
            }
        }
    }
}
