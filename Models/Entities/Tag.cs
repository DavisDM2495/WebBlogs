using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//namespace WebsiteBlogs.Models.Entities;
namespace WebsiteBlogs.Models;

public class Tag{

    [Key]
    public int Id {get; set;}

    public string Name {get; set;}

     public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

}