using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Entities;
using Data;

namespace Controllers 
{
    [Authorize]
    public class ProductsController : Controller 
    {
        
        private WebshopContext _context;
        private readonly UserManager<IdentityUser> _manager;
        
        public ProductsController(WebshopContext context, UserManager<IdentityUser> manager) 
        {
            _context = context;
            _manager = manager;
        }

        [AllowAnonymous]
        public IActionResult Index() { return View(_context.Products.ToList()); }

        public IActionResult Create() {return View();}

        [HttpPost]
        public IActionResult Create([Bind("title","description","price","status")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Product product = _context.Products.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("id", "title", "description", "price" )] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult AddToCart(int id, [Bind("id", "title", "description", "price" )] Product product)
        {
            
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}