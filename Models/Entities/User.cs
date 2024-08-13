using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//namespace WebsiteBlogs.Models.Entities;
namespace WebsiteBlogs.Models;

public class User{

    [Key]
    public int Id {get; set;}

    [Required]
    public required string FirstName {get; set;}

   [Required]
    public required string LastName {get; set;}

    [Required]
    public required string Email {get; set;}

    [ForeignKey("Blog")]
   // public int? BlogId { get; set; }
    //public virtual Blog? Blog { get; set; }
    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
    
    [ForeignKey("Comment")]
    //public int? CommentId { get; set; }
    //public virtual Comment? Comment { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

}