using Microsoft.AspNetCore.Mvc;
using Entities;
using Webshop.Data;

namespace Controllers;

public class ProductController : Controller {
    
    private ProductContext _context;
    
    public ProductController(ProductContext context) {_context = context;}

    public IActionResult Index() {
        IEnumerable<Product> products = _context.Product.ToList();
        return View(products);
    }

    public IActionResult Create() {return View();}

    [HttpPost]
    public IActionResult Create([Bind("title","description","price","status")] Product product) {
        if (ModelState.IsValid) {
            _context.Product.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult Edit(int id) {
        Post p = _context.products.Find(id);
        return View(p);
    }

    [HttpPost]
    public IActionResult Edit(int id, [Bind("id", "title", "description", "price" )] Product product) {
        if (ModelState.isValid) {
            _context.products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        return View();
    }
}