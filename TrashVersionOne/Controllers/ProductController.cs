using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrashVersionOne.Models;
using TrashVersionOne.Models.ViewModel;

namespace TrashVersionOne.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 6;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Product_category == category)
                .OrderBy(p => p.Id)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Product_category == category).Count()
                },
                CurrentCategory = category
            });

        public ViewResult Details(int Id)
        {
            var product = repository.Products.FirstOrDefault(d => d.Id == Id);
            if (product == null)
            {
                return View("");
            }
            return View(product);
        }
    }
}