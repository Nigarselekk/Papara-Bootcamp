using WebApi.DbOperations;

namespace   WebApi.BookOperations.UpdateBook;
public class UpdateBookCommand
{
    public int BookId { get; set; }
    public UpdateBookModel Model { get; set; }
    private readonly BookStoreDbContext _dbContext;

    public UpdateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

        if (book is null)
            throw new InvalidOperationException("Book not found");
        if (_dbContext.Books.Any(x => x.Title == Model.Title && x.Id != BookId))
            throw new InvalidOperationException("Book already exists");


        book.Title = Model.Title != default ? Model.Title : book.Title;
        book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
        
        _dbContext.SaveChanges();
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }

    }
} 