public interface IBookServices
{
    IEnumerable<Book> GetBooks();
    Book? GetBookById(int id);
    bool AddBook(Book book);
    bool UpdateBook(Book book);
    bool DeleteBook(int id);    
}