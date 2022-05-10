#nullable disable
using System.ComponentModel.DataAnnotations;

namespace Blog.Models;

public class Comment
{
    public int Id { get; set; }
    public int PostId { get; set; }
    [MaxLength(255)]
    public string Author { get; set; }
    public string Text { get; set; }
    public DateTime CreatedOn { get; set; }

    public Post Post { get; set; }
}