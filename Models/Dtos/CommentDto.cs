namespace WebsiteBlogs.Models.Dtos;

public class CommentDto{

    public int Id {get; set;}
    public string Text {get; set;}
    public int? PostId { get; set; }
    public Post? Post { get; set; }
    public int? UserId { get; set; }
    public User? User { get; set; }
    
}