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
        return View(products);
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

    public IActionResult Edit(int id) {
        Post p = context.products.Find(id);
        return View(p);
    }

    [HttpPost]
    public IActionResult Edit(int id, [Bind("id", "title", "description", "price", )] Product product) {
        if (ModelState.isValid) {
            context.products.Update(product);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        return View();
    }
}