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
        private const string AnencyName = "This is test Agency";

        public static IList<BinViewModel> InitFakeList()
        {
            var productsList = new List<BinViewModel>();
            for (int i = 0; i < 10; i++)
            {
                productsList.Add(new BinViewModel
                {
                    ID = i,
                    BinName = string.Concat(BinName, i),
                    LastModified = DateTime.Today.AddDays(-i),
                    LastModifiedBy = string.Concat(ModifierName, i),
                    Status = BinStatuses.New.ToString(),
                    Agency = new Agency { Id = i, Name = string.Concat(AnencyName, i) }
                });
            }

            return productsList;
        }
    }
}