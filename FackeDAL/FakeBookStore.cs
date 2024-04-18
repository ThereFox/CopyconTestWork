using App.RepositorysInterfaces;
using CSharpFunctionalExtensions;
using Domain.Entitys;

namespace FackeDAL;

public class FakeBookStore : IBookStore
{
    public async Task<List<Book>> GetAll()
    {
        return new List<Book>() { };
    }

    public async Task<Result<Book>> GetById(Guid id)
    {
        return Result.Failure<Book>("123");
    }

    public async Task<Result> Create(Book author)
    {
        return Result.Failure("123");
    }

    public async Task<Result> SaveChanges(Book author)
    {
        return Result.Failure("123");
    }

    public async Task<Result> Delite(Guid id)
    {
        return Result.Failure("123");
    }
}