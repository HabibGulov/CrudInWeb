var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();

// BookServices bookServices = new BookServices();
// Book book = new Book()
// {
//     Id=1,
//     Title="ha",
//     Author="Rem"
// };
// bookServices.AddBook(book);
// Book book1 = bookServices.GetBookById(1)!;
// System.Console.WriteLine(book.Id);
// System.Console.WriteLine(book.Author);
// System.Console.WriteLine(book.Title);