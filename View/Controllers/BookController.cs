using App.Services;
using BookTest.Requests;
using Domain.Entitys;
using Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace BookTest.Controllers;

public class BookController : Controller
{
    private readonly BooksServices _bookBookService;
    private readonly AuthorsServices _authorsServices;
    
    public BookController(BooksServices bookService, AuthorsServices authorsServices)
    {
        _bookBookService = bookService;
        _authorsServices = authorsServices;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var books = await _bookBookService.GetAll();

        return View(books);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]BookInputObject createBookRequest)
    {
        Guid guid;
        if (Guid.TryParse(createBookRequest.AuthorId.Trim(), out guid) == false)
        {
            return Json("invalid authour Id");
        }

        var getAuthourResult = await _authorsServices.GetById(guid);

        if (getAuthourResult.IsFailure)
        {
            return BadRequest(getAuthourResult.Error);
        }

        var authour = getAuthourResult.Value;

        var getLanguageResult = Language.Create(createBookRequest.LanguageId);

        if (getLanguageResult.IsFailure)
        {
            return BadRequest(getAuthourResult.Error);
        }

        var language = getLanguageResult.Value;

        var Id = Guid.NewGuid();
        
        var createBookResult =
            Book.Create(Id, createBookRequest.Name, createBookRequest.Year, authour, language);

        if (createBookResult.IsFailure)
        {
            return BadRequest(getAuthourResult.Error);
        }

        var book = createBookResult.Value;

        var createResult = await _bookBookService.Create(book);

        if (createResult.IsFailure)
        {
            return BadRequest(createResult.Error);
        }
        
        return new JsonResult(Id);
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateBookInputObject updateBookRequest)
    {
        var guid = Guid.Parse(updateBookRequest.Id);
        var getAuthourResult = await _authorsServices.GetById(Guid.Parse(updateBookRequest.AuthorId));

        if (getAuthourResult.IsFailure)
        {
            return BadRequest(getAuthourResult.Error);
        }

        var getLanguage = Language.Create(updateBookRequest.LanguageId);

        if (getLanguage.IsFailure)
        {
            return BadRequest(getLanguage.Error);
        }

        var language = getLanguage.Value;
        
        var authour = getAuthourResult.Value;

        var validateBookResult = Book.Create(guid, updateBookRequest.Name, updateBookRequest.Year, authour, language);

        if (validateBookResult.IsFailure)
        {
            return BadRequest(validateBookResult.Error);
        }

        var book = validateBookResult.Value;
        
        var updateResult = await _bookBookService.Update(book);

        if (updateResult.IsFailure)
        {
            return BadRequest(updateResult.Error);
        }
        
        return new JsonResult(updateResult.IsSuccess);
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delite([FromBody]DeliteElement deliteRequest)
    {
        Guid guid;
        if (Guid.TryParse(deliteRequest.Id, out guid) == false)
        {
            return BadRequest("id invalid");
        }

        var getBookResult = await _bookBookService.GetById(guid);

        if (getBookResult.IsFailure)
        {
            return BadRequest(getBookResult.Error);
        }

        var book = getBookResult.Value;
        
        var deliteResult = await _bookBookService.Delite(book);

        if (deliteResult.IsFailure)
        {
            return BadRequest(deliteResult.Error);
        }
        
        return new JsonResult(deliteResult.IsSuccess);
    }
}