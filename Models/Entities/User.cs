using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public class User {

    [Required(ErrorMessage = "Please insert title...")]
    [MinLength(3,ErrorMessage = "Minimum length is 3!")]
    [MaxLength(100,ErrorMessage = "Maximum length is 100!")]
    private string title {get; set;}

    [MaxLength(500,ErrorMessage = "Maximum length is 500!")]
    private string? description {get; set;}

    private List<Product> cart {get;}

    private List<Product.Comment> comments {get;}

    private DateTime established {get;}

    public User(string title, string? description) {
        this.title = title;
        this.description = description;
        cart = new List<Product>();
        comments = new List<Product.Comment>();
        established = DateTime.Now;
    }

    public List<Product> addToCart(Product product) {
        cart.Add(product);
        return cart;
    }

    public List<Product.Comment> addComment(Product.Comment comment) {
        comments.Add(comment);
        return comments;
    }
}