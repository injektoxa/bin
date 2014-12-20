﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kendo.Mvc.UI;
using KendoGridAjaxEditing.Enums;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Implementation;
using KendoGridAjaxEditing.Infrastructure.RememberFilter.Interfaces;
using KendoGridAjaxEditing.Infrastructure.Search;
using KendoGridAjaxEditing.Models;
using System.Web.Mvc;

namespace KendoGridAjaxEditing.Controllers
{
    public class DCOBinController : Controller
    {
        private IList<BinViewModel> _productsList;
        private IFiltersStore<SearchBinFilters> _filtersStore;

        public DCOBinController()
        {
            this._productsList = new List<BinViewModel>
                {
                    new BinViewModel
                        {
                            ID = 1234,
                            BinName = "This is bin",
                            LastModified = DateTime.Today,
                            LastModifiedBy = "Alex",
                            Status = BinStatuses.QA.ToString()
                        },
                     new BinViewModel
                        {
                            ID = 65334,
                            BinName = "Bin2",
                            LastModified = DateTime.Today,
                            LastModifiedBy = "Alex",
                            Status = BinStatuses.Processing.ToString()
                        },
                     new BinViewModel
                        {
                            ID = 64658,
                            BinName = "TestBin",
                            LastModified = DateTime.Today,
                            LastModifiedBy = "Alex",
                            Status = BinStatuses.Edited.ToString()
                        },
                    new BinViewModel
                        {
                            ID = 23456,
                            BinName = "New bin",
                            LastModified = DateTime.Today,
                            LastModifiedBy = "Alex",
                            Status = BinStatuses.PendingQA.ToString()
                        },
                     new BinViewModel
                        {
                            ID = 78678,
                            BinName = "not tested",
                            LastModified = DateTime.Today,
                            LastModifiedBy = "Den",
                            Status = BinStatuses.FuturePublish.ToString()
                        },
                     new BinViewModel
                        {
                            ID = 65346,
                            BinName = "hey this is bin",
                            LastModified = DateTime.Today,
                            LastModifiedBy = "Alex",
                            Status = BinStatuses.New.ToString()
                        },
                    new BinViewModel
                        {
                            ID = 2345,
                            BinName = "____",
                            LastModified = DateTime.Today,
                            LastModifiedBy = "Yura",
                            Status = BinStatuses.New.ToString()
                        },
                };

            this._filtersStore = new BinFiltersStore();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BinList_Read(SearchBinFilters searchfilters = null)
        {
            var bins = _productsList.AsQueryable();
            var filters = FiltersFactory.BinSearch;
            var result = filters.Aggregate(bins, (current, searchFilter) => searchFilter.Apply(current, searchfilters)).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveFilter(SearchBinFilters searchfilters = null)
        {
            searchfilters = new SearchBinFilters();
            _filtersStore.SaveFilter(searchfilters, this.HttpContext.Session);

            var filter = _filtersStore.GetFilter(this.HttpContext.Session);
            return this.Content("Success");
        }

        //public ActionResult Products_Create([DataSourceRequest]DataSourceRequest request, BinViewModel product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var northwind = new NorthwindEntities())
        //        {
        //            // Create a new Product entity and set its properties from the posted ProductViewModel
        //            var entity = new Product
        //            {
        //                ProductName = product.ProductName,
        //                UnitsInStock = product.UnitsInStock
        //            };
        //            // Add the entity
        //            northwind.Products.Add(entity);
        //            // Insert the entity in the database
        //            northwind.SaveChanges();
        //            // Get the ProductID generated by the database
        //            product.ProductID = entity.ProductID;
        //        }
        //    }
        //    // Return the inserted product. The grid needs the generated ProductID. Also return any validation errors.
        //    return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult Products_Update([DataSourceRequest]DataSourceRequest request, ProductViewModel product)
        //{
        //    if (product.ProductName.Length < 3)
        //    {
        //        ModelState.AddModelError("ProductName", "ProductName should be at least three characters long.");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        using (var northwind = new NorthwindEntities())
        //        {
        //            // Create a new Product entity and set its properties from the posted ProductViewModel
        //            var entity = new Product
        //            {
        //                ProductID = product.ProductID,
        //                ProductName = product.ProductName,
        //                UnitsInStock = product.UnitsInStock
        //            };
        //            // Attach the entity
        //            northwind.Products.Attach(entity);
        //            // Change its state to Modified so Entity Framework can update the existing product instead of creating a new one
        //            northwind.Entry(entity).State = EntityState.Modified;
        //            // Or use ObjectStateManager if using a previous version of Entity Framework
        //            // northwind.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        //            // Update the entity in the database
        //            northwind.SaveChanges();
        //        }
        //    }
        //    // Return the updated product. Also return any validation errors.
        //    return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        //}

        //public ActionResult Products_Destroy([DataSourceRequest]DataSourceRequest request, ProductViewModel product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var northwind = new NorthwindEntities())
        //        {
        //            // Create a new Product entity and set its properties from the posted ProductViewModel
        //            var entity = new Product
        //            {
        //                ProductID = product.ProductID,
        //                ProductName = product.ProductName,
        //                UnitsInStock = product.UnitsInStock
        //            };
        //            // Attach the entity
        //            northwind.Products.Attach(entity);
        //            // Delete the entity
        //            northwind.Products.Remove(entity);
        //            // Or use DeleteObject if using a previous versoin of Entity Framework
        //            // northwind.Products.DeleteObject(entity);
        //            // Delete the entity in the database
        //            northwind.SaveChanges();
        //        }
        //    }
        //    // Return the removed product. Also return any validation errors.
        //    return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        //}

        //public JsonResult GetData()
        //{
        //    // uncomment for returning mock list
        //    //return Json(this._productsList, JsonRequestBehavior.AllowGet);

        //    using (var northwind = new NorthwindEntities())
        //    {
        //        IQueryable<BinViewModel> products = northwind.Products;
        //        var result = products.Select(p => new BinViewModel()
        //            {
        //                BinName = p.,
        //                ProductName = p.ProductName,
        //                UnitsInStock = p.UnitsInStock
        //            }).ToList();
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
