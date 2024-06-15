using System;
using App.Services;
using BookTest.Requests;
using Domain.Entitys;
using Domain.ValueObject;
using Microsoft.AspNetCore.Mvc;

namespace BookTest.Controllers;


public class AuthorController : Controller
{
    private readonly AuthorsServices _service;

    public AuthorController(AuthorsServices service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var authors = await _service.GetAll();

        return View(authors);
    }

    [HttpGet]
    public async Task<IActionResult> GetById([FromBody] string id)
    {
        if(Guid.TryParse(id, out var authourId) == false)
        {
            return BadRequest("Invalid Id");
        }

        var getAuthourResult = await _service.GetById(authourId);

        if(getAuthourResult.IsFailure)
        {
            return BadRequest(getAuthourResult.Error);
        }

        return new JsonResult(getAuthourResult.Value);

    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AuthorInputObjecst inputObjecst)
    {
        try
        {
            var validateAuthorNameResult =
                AuthorName.Create(inputObjecst.FirstName, inputObjecst.LastName, inputObjecst.SecondName);

            if (validateAuthorNameResult.IsFailure)
            {
                return BadRequest(validateAuthorNameResult.Error);
            }

            var name = validateAuthorNameResult.Value;

            var Id = Guid.NewGuid();
            
            var validateAuthorResult = Author.Create(Id, name, inputObjecst.YearOfBirth);

            if (validateAuthorResult.IsFailure)
            {
                return BadRequest(validateAuthorResult.Error);
            }

            var createResult = await _service.Create(validateAuthorResult.Value);

            return new JsonResult(Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateAuthourRequest request)
    {
        var guid = Guid.Parse(request.Id);

        var createNameResult = AuthorName.Create(request.FirstName, request.LastName, request.SecondName);

        if (createNameResult.IsFailure)
        {
            return BadRequest(createNameResult.Error);
        }

        var authourName = createNameResult.Value;
        
        var validateAuthorResult = Author.Create(guid, authourName, request.yearOfBirth);

        if (validateAuthorResult.IsFailure)
        {
            return BadRequest(validateAuthorResult.Error);
        }

        var author = validateAuthorResult.Value;
        
        var updateResult = await _service.Update(author);

        return new JsonResult(updateResult.IsSuccess);
    }
    [HttpDelete]
    public async Task<IActionResult> Delite([FromBody]DeliteElement request)
    {
        Guid id;
        if (Guid.TryParse(request.Id, out id))
        {
            BadRequest("id invalid");
        }

        var deliteResult = await _service.Delite(id);

        if (deliteResult.IsFailure)
        {
            return BadRequest(deliteResult.Error);
        }
        
        return new JsonResult(deliteResult.IsSuccess);
    }
}