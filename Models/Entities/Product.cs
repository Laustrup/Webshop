using System.ComponentModel.DataAnnotations;
using Webshop.Models.Entities.Statuses;

namespace Webshop.Models.Entities;

public class Product {

    public int id {get; set;}

    [Required(ErrorMessage = "Please insert title...")]
    [MinLength(3,ErrorMessage = "Minimum length is 3!")]
    [MaxLength(100,ErrorMessage = "Maximum length is 100!")]
    public string? title {get; set;}

    public string description {get; set;}

    [Required(ErrorMessage = "Please insert price...")]
    public int price {get; set;}

    public ProductStatus status {get;set;}

    /*
    public Product(string title,string description,int price) {
        this.title = title;
        this.description = description;
        this.price = price;
    }
    */

} 
