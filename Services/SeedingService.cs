using Microsoft.EntityFrameworkCore;
using WebsiteBlogs.Data;
using WebsiteBlogs.Models;

using System;

namespace WebsiteBlogs.Services;

public class SeedingService {
    private readonly ApplicationDbContext _context;
    private readonly Random _random = new Random();

    public SeedingService(ApplicationDbContext context) {
        _context = context;
    }

    public async Task SeedDatabase() {
        if (await _context.Users.AnyAsync() ||
            await _context.Blogs.AnyAsync() ||
            await _context.Tags.AnyAsync() ||
            await _context.Posts.AnyAsync() ||
            await _context.Comments.AnyAsync()) {
            return; // Database already seeded.
        }

        await this.CreateUsers();
        await this.CreateBlogs();
        await this.CreateTags();
        await this.CreatePostsAndComments();
    }

    private async Task CreateUsers() {
        var users = new List<User> {
            new User { FirstName = "John", LastName = "Doe", Email = "john@example.com" },
            new User { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com" },
            new User { FirstName = "Alice", LastName = "Johnson", Email = "alice@example.com" },
            new User { FirstName = "Bob", LastName = "Williams", Email = "bob@example.com" },
            new User { FirstName = "Emma", LastName = "Brown", Email = "emma@example.com" },
            new User { FirstName = "Chris", LastName = "Evans", Email = "chris@example.com" },
            new User { FirstName = "Sophia", LastName = "Clark", Email = "sophia@example.com" },
            new User { FirstName = "Daniel", LastName = "Lewis", Email = "daniel@example.com" },
            new User { FirstName = "Mia", LastName = "Walker", Email = "mia@example.com" },
            new User { FirstName = "Olivia", LastName = "Martinez", Email = "olivia@example.com" }
        };

        await _context.Users.AddRangeAsync(users);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    private async Task CreateBlogs() {
        var users = await _context.Users.ToListAsync();

        var blogs = new List<Blog>();

        for (int i = 0; i < users.Count; i++) {
            // Create multiple blogs for every user except the last one
            if (i < users.Count - 1) {
                blogs.Add(new Blog { Name = $"{users[i].FirstName}'s Blog", Owner = users[i] });
                blogs.Add(new Blog { Name = $"{users[i].FirstName}'s Second Blog", Owner = users[i] });
            } else {
                blogs.Add(new Blog { Name = $"{users[i].FirstName}'s Blog", Owner = users[i] });
            }
        }

        await _context.Blogs.AddRangeAsync(blogs);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    private async Task CreateTags() {
        var tags = new List<Tag> {
            new Tag { Name = "Introduction" },
            new Tag { Name = "Tutorial" },
            new Tag { Name = "Guide" },
            new Tag { Name = "Tips" },
            new Tag { Name = "Review" }
        };

        await _context.Tags.AddRangeAsync(tags);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }

    private async Task CreatePostsAndComments() {
        var blogs = await _context.Blogs.ToListAsync();
        var users = await _context.Users.ToListAsync();
        var tags = await _context.Tags.ToListAsync();

        var posts = new List<Post>();
        var comments = new List<Comment>();

        for (int i = 0; i < blogs.Count; i++) {
            // Randomly select a user for the post
            var randomUserForPost = users[_random.Next(users.Count)];

            var post = new Post {
                Title = $"Post {i + 1}",
                Content = $"This is post {i + 1}.",
                Blog = blogs[i],
                Tags = new List<Tag> { tags[i % tags.Count] }
            };
            posts.Add(post);

            // Randomly select a user for the comment
            var randomUserForComment = users[_random.Next(users.Count)];

            var comment = new Comment {
                Text = $"This is a comment on post {i + 1}.",
                User = randomUserForComment,
                Post = post
            };
            comments.Add(comment);
        }

        await _context.Posts.AddRangeAsync(posts);
        await _context.Comments.AddRangeAsync(comments);
        await _context.SaveChangesAsync().ConfigureAwait(false);
    }
}