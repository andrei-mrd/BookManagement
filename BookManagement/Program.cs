using FluentValidation;
using Microsoft.EntityFrameworkCore;
using BookManagement.Features;
using BookManagement.Persistence;
using BookManagement.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<BookManagementContext>(options =>
	options.UseSqlite("Data Source=bookmanagement.db"));
builder.Services.AddScoped<CreateBookHandler>();
builder.Services.AddScoped<GetAllBookHandler>();
builder.Services.AddScoped<GetPagedBooksHandler>();
builder.Services.AddScoped<GetBookByIdHandler>();
builder.Services.AddScoped<UpdateBookHandler>();
builder.Services.AddScoped<DeleteBookHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookValidator>();


var app = builder.Build();

// Ensure the database is created at runtime
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<BookManagementContext>();
	context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.MapPost("/books", async (CreateBookRequest req, CreateBookHandler handler) =>
	await handler.Handle(req));

// Read all
app.MapGet("/books", async (GetAllBookHandler handler) =>
	await handler.Handle(new GetAllBookRequest()));

// Paginated
app.MapGet("/books/paged", async (int page, int pageSize, GetPagedBooksHandler handler) =>
	await handler.Handle(new GetPagedBooksRequest(page, pageSize)));

app.MapGet("/books/{id:guid}", async (Guid id, GetBookByIdHandler handler) =>
	await handler.Handle(new GetBookByIdRequest(id)));

app.MapPut("/books", async (UpdateBookRequest req, UpdateBookHandler handler) =>
	await handler.Handle(req));

app.MapDelete("/books/{id:guid}", async (Guid id, DeleteBookHandler handler) =>
{
	await handler.Handle(new DeleteBookRequest(id));
});

app.Run();
