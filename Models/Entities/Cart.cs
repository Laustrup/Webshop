using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        private List<Product> _products {get; set;} public List<Product> Products { get{return _products;} }
        public List<Product> addProduct(Product product)
        {
            _products.Add(product);
            return _products;            
        }

        public string UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}