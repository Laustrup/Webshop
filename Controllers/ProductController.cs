using Microsoft.AspNetCore.Mvc;
using Webshop.Models.Entities;
using Webshop.Data;

namespace Webshop.Controllers;

public class ProductController : Controller {
    
    private ProductContext context;
    public ProductController(ProductContext context) {
        this.context = context;
    }

    public IActionResult Index() {
        IEnumerable<Product> products = context.Product.ToList();
        return View();
    }

    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public IActionResult Create([Bind("title","description","price","status")] Product product) {
        if (ModelState.IsValid) {
            context.Product.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }
}