
using Dapper;
using Npgsql;

public class BookServices : IBookServices
{
    public bool AddBook(Book book)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                return connection.Execute(SqlCommands.InsertBook,book)>0;
            }
        }
        catch(NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool DeleteBook(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                return connection.Execute(SqlCommands.DeleteBook, new{Id=id})>0;
            }
        }
        catch(NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }

    public Book? GetBookById(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                return connection.QueryFirstOrDefault<Book>(SqlCommands.GetBookById, new {Id=id});
            }
        }
        catch(NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new Book();
        }
    }

    public IEnumerable<Book> GetBooks()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                return connection.Query<Book>(SqlCommands.GetAllBooks);
            }
        }
        catch(NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return new List<Book>();
        }
    }

    public bool UpdateBook(Book book)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(SqlCommands.ConnectionString))
            {
                return connection.Execute(SqlCommands.UpdateBook,book)>0;
            }
        }
        catch(NpgsqlException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
    }
}

file class SqlCommands
{
    public const string ConnectionString = "Server=localhost;Port=5432;Database=books_info_db;Username=postgres;Password=12345";
    public const string InsertBook = "Insert into books(title, author)Values(@Title, @Author)";
    public const string DeleteBook = "Delete from books where id = @Id";
    public const string UpdateBook = "Update books set title=@Title, author=@Author where id=@Id";
    public const string GetAllBooks = "Select * from books";
    public const string GetBookById = "Select * from books where id=@id";
}