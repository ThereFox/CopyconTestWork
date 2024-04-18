using App.RepositorysInterfaces;
using CSharpFunctionalExtensions;
using Domain.Entitys;
using Domain.ValueObject;

namespace FackeDAL;

public class FakeAuthorStore: IAuthorStore
{
    public async Task<List<Author>> GetAll()
    {
        return new List<Author>() {  Author.Create(Guid.NewGuid(), AuthorName.Create("123", "123", "123").Value, 1920).Value };
    }

    public async Task<Result<Author>> GetById(Guid id)
    {
        return Result.Failure<Author>("123");
    }

    public async Task<Result> Create(Author author)
    {
        return Result.Failure("123");
    }

    public async Task<Result> SaveChanges(Author author)
    {
        return Result.Failure("123");
    }

    public async Task<Result> Delite(Guid id)
    {
        return Result.Failure("123");
    }
}