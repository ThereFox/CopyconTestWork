using App.RepositorysInterfaces;
using CSharpFunctionalExtensions;
using Domain.Entitys;

namespace App.Services;

public class AuthorsServices
{
    private readonly IAuthorStore _store;

    public AuthorsServices(IAuthorStore Store)
    {
        _store = Store;
    }

    public async Task<List<Author>> GetAll()
    {
        return await _store.GetAll();
    }

    public async Task<Result<Author>> GetById(Guid id)
    {
        return await _store.GetById(id);
    }
    
    public async Task<Result> Create(Author Author)
    {
        return await _store.Create(Author);
    }

    public async Task<Result> Update(Author Author)
    {
        var checkContainingAuthorResult = await _store.GetById(Author.Id);
        
        if (checkContainingAuthorResult.IsFailure)
        {
            return Result.Failure("dont have base element");
        }
        
        return await _store.SaveChanges(Author);
    }

    public async Task<Result> Delite(Guid Id)
    {
        var checkContainingAuthorResult = await _store.GetById(Id);
        
        if (checkContainingAuthorResult.IsFailure)
        {
            return Result.Failure("dont have base element");
        }
        
        return await _store.Delite(checkContainingAuthorResult.Value);
    }
}