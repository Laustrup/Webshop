using System.ComponentModel.DataAnnotations;

namespace Entities
{
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