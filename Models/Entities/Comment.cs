using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//namespace WebsiteBlogs.Models.Entities;
namespace WebsiteBlogs.Models;

public class Comment{

    [Key]
    public int Id {get; set;}

    public string Text {get; set;}

    public int? PostId { get; set; }
    //public virtual Post? Post { get; set; }

    public Post? Post { get; set; }

    [ForeignKey("User")]
    public int? UserId { get; set; }
    //public virtual int? UserId { get; set; }

    public User? User { get; set; }
    //public virtual User? User { get; set; }


}