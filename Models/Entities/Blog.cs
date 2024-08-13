using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//usings WebsiteBlogs.Models.Dtos;

//namespace WebsiteBlogs.Models.Entities;
namespace WebsiteBlogs.Models;

public class Blog{

    [Key]
    public int Id {get; set;}

    public string Name {get; set;}

    [ForeignKey("User")]
    public int? OwnerId { get; set; }
    //public virtual OwnerId? OwnerId { get; set; }

    public User? Owner { get; set; }
    //public virtual User? Owner { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

}