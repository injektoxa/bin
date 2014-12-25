using System;
using System.Collections.Generic;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Models;

namespace Tests.Helpers
{
    public class ProductsListInitializer
    {
        private const string ModifierName = "Alex";
        private const string BinName = "This is test bin";

        public static IList<BinViewModel> InitFakeList()
        {
            var productsList = new List<BinViewModel>();
            for (int i = 0; i < 10; i++)
            {
                productsList.Add(new BinViewModel
                {
                    ID = 2345,
                    BinName = string.Concat(BinName, i),
                    LastModified = DateTime.Today.AddDays(-i),
                    LastModifiedBy = string.Concat(ModifierName, i),
                    Status = BinStatuses.New.ToString()
                });
            }

            return productsList;
        }
    }
}