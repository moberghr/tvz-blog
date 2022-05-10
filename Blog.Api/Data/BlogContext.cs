#nullable disable
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Api.Data;

public class BlogContext : DbContext
{
    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {
        
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    
}