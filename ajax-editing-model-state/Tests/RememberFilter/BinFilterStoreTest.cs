using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Infrastructure.Search.Enums;
using KendoGridAjaxEditing.Infrastructure.Search.FilterTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.RememberFilter
{
    [TestClass]
    public class BinFilterStoreTest
    {
        private IFiltersStore<SearchBinFilters, SessionFilterStorage<SearchBinFilters>> _filtersStore;
        private HttpSessionStateBase _session;

        [TestInitialize]
        public void Initialize()
        {
            _filtersStore = new BinFiltersStore<SessionFilterStorage<SearchBinFilters>>();
            _session = new MockHttpSession();
            _filtersStore.Storage = new SessionFilterStorage<SearchBinFilters>
            {
                Storage = _session
            };
        }

        [TestMethod]
        public void SaveAndGetFilter_CorrectParams_Should_Return_Equal_Object()
        {
            var filterToSet = this.InitBinFilters();

            _filtersStore.SaveFilter(filterToSet);
            var filterToGet = _filtersStore.GetFilter();

            Assert.AreEqual(filterToSet, filterToGet);
        }

        [TestMethod]
        public void ResetFilter_Should_Return_Clear_Filter_Object()
        {
            var filterToSet = this.InitBinFilters();

            _filtersStore.SaveFilter(filterToSet);
            _filtersStore.ResetFilter();

            var filterToGet = _filtersStore.GetFilter();

            Assert.AreNotEqual(filterToSet, filterToGet);
        }

        private SearchBinFilters InitBinFilters()
        {
            return new SearchBinFilters()
            {
                Id = 2345,
                BinName = "This is test bin",
                Status = new FilterType<BinStatuses>()
                {
                    SearchType = SearchType.Any,
                    Values = new List<BinStatuses>()
                    {
                        BinStatuses.New
                    }
                }
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
