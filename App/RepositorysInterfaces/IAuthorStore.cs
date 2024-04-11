using CSharpFunctionalExtensions;
using Domain.Entitys;

namespace App.RepositorysInterfaces;

public interface IAuthorStore
{
    public Task<List<Author>> GetAll();
    public Task<Result<Author>> GetById(Guid id);
    public Task<Result> Create(Author author);
    public Task<Result> SaveChanges(Author author);
    public Task<Result> Delite(Guid id);
}