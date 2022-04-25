using System.ComponentModel.DataAnnotations;
using Entities.Statuses;

namespace Entities;

public class Product {

    private int _id {get;} public int Id {get{return _id;}}


    [Required(ErrorMessage = "Please insert title...")]
    [MinLength(3,ErrorMessage = "Minimum length is 3!")]
    [MaxLength(100,ErrorMessage = "Maximum length is 100!")]
    private string _title {get; set;} public string Title {get{return _title;} set{_title = value;}}

    [MaxLength(500,ErrorMessage = "Maximum length is 500!")]
    private string _description {get; set;} public string Description {get{return _description;} set{_description = value;}}

    [Required(ErrorMessage = "Please insert price...")]
    private int _price {get; set;} public int Price {get{return _price;} set{_price = value;}}

    private List<Comment>? _comments {get;} public List<Comment>? Comments {get{return _comments;}}

    private ProductStatus _status {get;set;} public ProductStatus Status {get{return _status;} set{_status = value;}}

    public Product(string title,string description,int price) {
        _title = title;
        _description = description;
        _price = price;
    }

    public List<Comment> Add_Comment(Comment comment) {
        _comments.Add(comment);
        return _comments;
    }

    public class Comment {

        private int _id {get;} public int Id {get{return _id;}}

        private User _author {get;} public User Author {get{return _author;}}

        [Required(ErrorMessage = "Please insert content...")]
        [MaxLength(500,ErrorMessage = "Maximum length is 500!")]
        private string _content {get; set;} public string Content {get{return _content;} set{_content = value;}}

        private DateTime _timeStamp {get;} public DateTime TimeStamp {get{return _timeStamp;}}

        public Comment(User author, string content) {
            _author = author;
            _content = content;
            _timeStamp = DateTime.Now;
        }
    }

} 