using System.ComponentModel.DataAnnotations;

namespace Blog.Models;

public class Post
{
    public int Id { get; set; }
    [MaxLength(255)]
    public string Slug { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; }
}