using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrashVersionOne.Data;
using TrashVersionOne.Models;
using TrashVersionOne.Models.ViewModel;

namespace TrashVersionOne.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult OrderNow(int Id)
        //{
        //    OrderNowViewModel vn = new OrderNowViewModel();
        //    var item = _context.ProductDetails.Where(a => a.Id == Id).FirstOrDefault();
        //    //vn.ProNo = item.Product_category;
        //    ////vn.Product_Name = item.Product_Name;

        //    vn.ProductId = Id;

        //    return View(vn);
        //}

        public IActionResult ProductDetails()
        {
            var getProductList = _context.ProductDetails.ToList();
            return View(getProductList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
