using System.ComponentModel.DataAnnotations;

namespace Entities;

public class User {

    private int _id {get; set;} public int Id {get{return _id;} set{if(_id==null){_id=value;}}}

    [Required(ErrorMessage = "Please insert title...")]
    [MinLength(3,ErrorMessage = "Minimum length is 3!")]
    [MaxLength(100,ErrorMessage = "Maximum length is 100!")]
    private string _title {get; set;} public string Title {get{return _title;} set{_title = value;}}

    [MaxLength(500,ErrorMessage = "Maximum length is 500!")]
    private string? _description {get; set;} public string? Description {get{return _description;} set{_description = value;}}

    private List<Product> _cart {get;} public List<Product> Cart {get{return _cart;}}

    private List<Product.Comment> _comments {get;} public List<Product.Comment> Comments {get{return _comments;}}

    private DateTime _established {get;} public DateTime Established {get{return _established;}}

    public User(string title, string? description) {
        _title = title;
        _description = description;
        _cart = new List<Product>();
        _comments = new List<Product.Comment>();
        _established = DateTime.Now;
    }

    public List<Product> AddToCart(Product product) {
        _cart.Add(product);
        return _cart;
    }

    public List<Product.Comment> AddComment(Product.Comment comment) {
        _comments.Add(comment);
        return _comments;
    }
}