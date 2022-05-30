using System.Generic.Collection;

namespace Controllers
{
    public class CartController
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
            Cart cart;
            List<Cart> carts = _context.Carts;

            for (int i = 0; i < carts.length; i++) 
            {
                if (carts[i].UserId == _manager.IdentityUser.Id) 
                {
                    cart = carts[i];
                    break;
                }
            }
            if (cart == null) { cart = new Cart(); }

            return View(cart); 
        }
    }
}