using App.RepositorysInterfaces;
using CSharpFunctionalExtensions;
using Domain.Entitys;

namespace App.Services;

public class BooksServices
{
    private readonly IBookStore _store;

    public BooksServices(IBookStore Store)
    {
        _store = Store;
    }

    public async Task<List<Book>> GetAll()
    {
        return await _store.GetAll();
    }
    
    public async Task<Result<Book>> GetById(Guid id)
    {
        return await _store.GetById(id);
    }

    public async Task<Result> Create(Book Book)
    {
        return await _store.Create(Book);
    }

    public async Task<Result> Update(Book Book)
    {
        var checkContainingBookResult = await _store.GetById(Book.Id);
        
        if (checkContainingBookResult.IsFailure)
        {
            return Result.Failure("dont have base element");
        }
        
        return await _store.SaveChanges(Book);
    }

    public async Task<Result> Delite(Book book)
    {
        return await _store.Delite(book);
    }
}