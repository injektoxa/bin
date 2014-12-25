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
        private HttpSessionStateBase _session;

        [TestInitialize]
        public void Initialize()
        {
            _filtersStore = new BinFiltersStore();
            _session = new MockHttpSession();
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
            var filterToSet = this.InitBinFilters();

            _filtersStore.SaveFilter(filterToSet, _session);
            var filterToGet = _filtersStore.GetFilter(_session);

            Assert.AreEqual(filterToSet, filterToGet);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetFilter_WithNullSession_Should_Throw_NullReferenceException()
        {
            _filtersStore.GetFilter(null);
        }

        [TestMethod]
        public void ResetFilter_Should_Return_Clear_Filter_Object()
        {
            var filterToSet = this.InitBinFilters();

            _filtersStore.SaveFilter(filterToSet, _session);
            _filtersStore.ResetFilter(_session);

            var filterToGet = _filtersStore.GetFilter(_session);

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
