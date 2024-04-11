using App.RepositorysInterfaces;
using CSharpFunctionalExtensions;
using Domain.Entitys;

namespace DAL.Repositorys;

public class AuthorStore : IAuthorStore
{
    public Task<List<Author>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Author>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Create(Author author)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(Author author)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Delite(Guid id)
    {
        throw new NotImplementedException();
    }
}