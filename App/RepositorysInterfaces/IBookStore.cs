using CSharpFunctionalExtensions;
using Domain.Entitys;

namespace App.RepositorysInterfaces;

public interface IBookStore
{
    public Task<List<Book>> GetAll();
    public Task<Result<Book>> GetById(Guid id);
    public Task<Result> Create(Book author);
    public Task<Result> SaveChanges(Book author);
    public Task<Result> Delite(Guid id);
}