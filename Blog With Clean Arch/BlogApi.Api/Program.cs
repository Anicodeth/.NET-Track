using Microsoft.EntityFrameworkCore;
using BlogApi.Infrastructure.Data;
using BlogApi.Infrastructure.Repositories;
using BlogApi.Core.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddScoped<AddComment>(); 
builder.Services.AddScoped<GetComment>(); 
builder.Services.AddScoped<GetComments>(); 
builder.Services.AddScoped<UpdateComment>(); 
builder.Services.AddScoped<DeleteComment>();

builder.Services.AddScoped<CreatePost>();
builder.Services.AddScoped<GetPost>();
builder.Services.AddScoped<GetPosts>();
builder.Services.AddScoped<UpdatePost>();
builder.Services.AddScoped<DeletePost>();




var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogDatabaseContext>(options =>
{
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("BlogApi.Api"));
});



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
