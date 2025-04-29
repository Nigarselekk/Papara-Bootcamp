using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DbOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Controllers;


[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase
{
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

    
    [HttpGet]
    public IActionResult GetAll()
    {
        GetBooksQuery query = new GetBooksQuery(_context);
        var result= query.Handle();
        return Ok(result);
    
    }

    [HttpGet("{id}")]
    public IActionResult  GetById(int id)
    {
        BookDetailViewModel result = new BookDetailViewModel();

    try{
    GetBookDetailQuery query = new GetBookDetailQuery(_context);
    query.BookId = id;
    result = query.Handle();

    }catch (Exception ex){
        return BadRequest(ex.Message);
    }
        return Ok(result);
    }


    
    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newbook)
    {
        CreateBookCommand command = new CreateBookCommand(_context);
        try
        { 
        command.Model = newbook;
        command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateBook( int id , [FromBody] UpdateBookModel updatedbook)
    {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        try
        {
            command.BookId = id;
            command.Model = updatedbook;
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    { 
        DeleteBookCommand command = new DeleteBookCommand(_context);
        try
        {
            command.BookId = id;
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }











}