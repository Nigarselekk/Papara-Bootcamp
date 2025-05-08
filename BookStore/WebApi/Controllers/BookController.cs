using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DbOperations;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.BookOperations.GetBookDetail.GetBookDetailQuery;
using static WebApi.BookOperations.UpdateBook.UpdateBookCommand;
using AutoMapper;
using FluentValidation;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public BookController(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        GetBooksQuery query = new GetBooksQuery(_context, _mapper);
        var result = query.Handle();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        BookDetailViewModel result;

        try
        {
            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;
            GetBookDetailQueryValidator validator = new GetBookDetailQueryValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok(result);
    }


    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookModel newbook)
    {
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        try
        {
            command.Model = newbook;
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedbook)
    {
        UpdateBookCommand command = new UpdateBookCommand(_context);
        try
        {
            command.BookId = id;
            command.Model = updatedbook;
            UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
            
            validator.ValidateAndThrow(command);
            
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
            DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}