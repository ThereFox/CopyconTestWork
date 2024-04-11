using App.RepositorysInterfaces;
using CSharpFunctionalExtensions;
using Domain.Entitys;

namespace DAL.Repositorys;

public class BookStore : IBookStore
{
    public Task<List<Book>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Result<Book>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Create(Book author)
    {
        throw new NotImplementedException();
    }

    public Task<Result> SaveChanges(Book author)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Delite(Guid id)
    {
        throw new NotImplementedException();
    }
}