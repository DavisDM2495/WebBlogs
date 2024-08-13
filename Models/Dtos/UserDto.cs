namespace WebsiteBlogs.Models.Dtos;

public class UserDto {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public ICollection<BlogDto> Blogs { get; set; } = new List<BlogDto>();
    public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
}