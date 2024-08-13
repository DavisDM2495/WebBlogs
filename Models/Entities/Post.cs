using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//namespace WebsiteBlogs.Models.Entities;
namespace WebsiteBlogs.Models;

public class Post{

    [Key]
    public int Id {get; set;}

    public string Title {get; set;}

    public string Content {get; set;}

    [ForeignKey("Blog")]
    public int? BlogId { get; set; }
    //public virtual BlogId? BlogId { get; set; }

    public Blog? Blog { get; set; }
    //public virtual Blog? Blog { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

}