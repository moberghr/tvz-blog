using Blog.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/posts", () => new List<Post>
{
    new()
    {
        Id = 1,
        Title = "Title 1",
        Content = "Some content",
        Slug = "post-1",
        CreatedOn = DateTime.Now,
    },
    new()
    {
        Id = 2,
        Title = "Title 1",
        Content = "Some content",
        Slug = "post-1",
        CreatedOn = DateTime.Now,
    },
    new()
    {
        Id = 3,
        Title = "Title 1",
        Content = "Some content",
        Slug = "post-1",
        CreatedOn = DateTime.Now,
    },
});

app.MapGet("/posts/{slug}", (string slug) => new Post()
{
    Id = 3,
    Title = "Title 1",
    Content = "Some content",
    Slug = "post-1",
    CreatedOn = DateTime.Now,
});

app.MapGet("/posts/{postId}/comments", (int postId) => new List<Comment>()
{
    new()
    {
        Author = "Author 1",
        Text = "Commented some text",
        CreatedOn = DateTime.Now,
    },
    new()
    {
        Author = "Author 2",
        Text = "Commented some text",
        CreatedOn = DateTime.Now,
    },
    new()
    {
        Author = "Author 3",
        Text = "Commented some text",
        CreatedOn = DateTime.Now,
    },
    new()
    {
        Author = "Author 4",
        Text = "Commented some text",
        CreatedOn = DateTime.Now,
    },
});

app.Run();

