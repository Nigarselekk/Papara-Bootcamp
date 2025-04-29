using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail;

public class GetBookDetailQuery
{
    public int BookId { get; set; }
    private readonly BookStoreDbContext _dbContext;

    public GetBookDetailQuery(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public BookDetailViewModel Handle()
    {
        var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
        if (book is null)
            throw new InvalidOperationException("Book not found");
        BookDetailViewModel vm = new BookDetailViewModel();

        vm.Title = book.Title;
        vm.GenreId = ((GenreEnum)book.GenreId).ToString();
        vm.PageCount = book.PageCount;
        vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
        return vm;
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string GenreId { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    
    }
}