using Blog.Api.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.MapGet("/posts", (BlogContext db) => db.Posts.ToList());
app.MapGet("/posts/{slug}", (string slug, BlogContext db) => db.Posts.Where(x => x.Slug == slug).FirstOrDefault());
app.MapGet("/posts/{postId}/comments", (int postId, BlogContext db) => db.Comments.Where(x => x.PostId == postId).ToList());
app.MapPost("/posts", (Post p, BlogContext db) =>
{
    if (db.Posts.Any(x => x.Slug == p.Slug))
    {
        return Results.BadRequest("post with slug already exists");
    }

    var post = new Post()
    {
        Slug = p.Slug,
        Title = p.Title,
        Content = p.Content,
        CreatedOn = DateTime.Now,
    };

    db.Posts.Add(post);
    db.SaveChanges();

    return Results.Ok(post.Id);
});
app.MapPost("/posts/{postId}/comments", (int postId, Comment c, BlogContext db) =>
{
    db.Comments.Add(c);
    db.SaveChanges();

    return Results.Ok();
});

app.Run();

