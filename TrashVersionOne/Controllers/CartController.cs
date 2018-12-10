using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrashVersionOne.Infrastructure;
using TrashVersionOne.Models;
using TrashVersionOne.Models.ViewModel;

namespace TrashVersionOne.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        private Cart cart;
     

        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            cart = cartService;
           
        }

        public ViewResult Index(string retunrUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = retunrUrl
            });
        }
       
        public RedirectToActionResult AddToCart(int id, string returnUrl)
        {
            ProductDetails product = repository.Products
            .FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId,
        string returnUrl)
        {
            ProductDetails product = repository.Products
            .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
    }
}