using App.Services;
using Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace BookTest.Controllers;

[Route("/authors")]
public class AuthorController : Controller
{
    private readonly AuthorsServices _service;
    
    [HttpGet]
    [Route("/")]
    public async Task<IActionResult> Index()
    {
        var authors = await _service.GetAll();

        return View(authors);
    }
    
    [HttpPost]
    [Route("/create")]
    public async Task<IActionResult> Create([FromBody]Author author)
    {
        var createResult = await _service.Create(author);

        return new JsonResult(createResult);
    }
    [HttpPut]
    [Route("/update")]
    public async Task<IActionResult> Update([FromBody]Author author)
    {
        var updateResult = await _service.Update(author);

        return new JsonResult(updateResult);
    }
    [HttpDelete]
    [Route("/delite")]
    public async Task<IActionResult> Create([FromBody]Guid id)
    {
        var deliteResult = await _service.Delite(id);

        return new JsonResult(deliteResult);
    }
}