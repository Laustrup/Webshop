using Microsoft.AspNetCore.Mvc;
using Data;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Controllers;

public class CartController : Controller
{
    private WebshopContext _context;
    private readonly UserManager<IdentityUser> _manager;

    public CartController(WebshopContext context, UserManager<IdentityUser> manager) 
    {
        _context = context;
        _manager = manager;
    }

    [AllowAnonymous]
    public IActionResult Index() 
    {
        Cart cart = new Cart();
        List<Cart> carts = _context.Carts.ToList();

        for (int i = 0; i < carts.Count; i++) 
        {
            if (carts[i].User == _manager.Users.GetEnumerator().Current) 
            {
                cart = carts[i];
                break;
            }
        }
        
        return View(cart.Products); 
    }
}