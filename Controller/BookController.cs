// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

[Route("Book")]
[ApiController]

public class BookController
{
    private readonly IBookServices bookServices = new BookServices();

    [HttpGet]
    public IEnumerable<Book> GetBooks()
    {
        return bookServices.GetBooks();
    }

    [HttpGet("{id}")]
    public Book? GetBookById(int id)
    {
        return bookServices.GetBookById(id);
    }

    [HttpPost]
    public bool InsertBook(Book book)
    {
        return bookServices.AddBook(book);
    }

    [HttpDelete]
    public bool DeleteBook(int id)
    {
        return bookServices.DeleteBook(id);
    }
    
    [HttpPut]
    public bool UpdateBook(Book book)
    {
        return bookServices.UpdateBook(book);
    }
}