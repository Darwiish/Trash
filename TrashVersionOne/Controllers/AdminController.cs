using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploadControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrashVersionOne.Data;
using TrashVersionOne.Models;
using TrashVersionOne.Models.ViewModel;

namespace TrashVersionOne.Controllers
{
    [Authorize]
    public class AdminController : Controller

    {
        
        private IProductRepository _repository;
        private ApplicationDbContext _context;
        private UploadInterface _upload;
        private readonly UserManager<IdentityUser> _userManager;

        
        public AdminController(ApplicationDbContext context, UploadInterface upload, 
            IProductRepository repository, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _upload = upload;
            _repository = repository;
            _userManager = userManager;


        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Create(IList<IFormFile> files, ProductDetailViewModel pmodel, ProductDetails product)
        {
                 
            product.Product_Name = pmodel.Name;
            product.Product_category = pmodel.category;
            product.Amount = pmodel.Amount;
            product.Product_Description = pmodel.Description;
            product.ProductPicture = pmodel.ProductImage;
            product.CreatedBy = _userManager.GetUserId(HttpContext.User);
            //product.CreatedBy = HttpContext.Current.User.Identity.GetUserId();

            foreach (var item in files)
            {
                product.ProductPicture = "~/uploads/" + item.FileName.Trim();
            }

            _upload.uploadfilemultiple(files);
            _context.ProductDetails.Add(product);
            _context.SaveChanges();
            TempData["Sucess"] = "You Product is Saved";
            return RedirectToAction("Check", "Admin");

        }
        
        public ViewResult Check() => View(_repository.Products.Where(p => p.CreatedBy == _userManager.GetUserId(HttpContext.User)));

        public ViewResult Edit(int productId) => View(_repository.Products .FirstOrDefault(p => p.Id == productId));

        [HttpPost]
        public IActionResult Edit(ProductDetails product, IList<IFormFile> files)
        {
           
            if (ModelState.IsValid)
            {
                
                _upload.uploadfilemultiple(files);
                _repository.SaveProduct(product);
                TempData["message"] = $"{product.Product_Name} has been saved";
                return RedirectToAction("Check");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            ProductDetails deletedProduct = _repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Product_Name} was deleted";
            }
            return RedirectToAction("Check");
        }

    }
}

