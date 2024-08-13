namespace WebsiteBlogs.Models.Dtos;

public class BlogDto{

    public int Id {get; set;}
    public string Name {get; set;}
    public int? OwnerId { get; set; }
    public User? Owner { get; set; }
    public ICollection<Post> Courses { get; set; } = new List<Post>();
}