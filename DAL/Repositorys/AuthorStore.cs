using App.RepositorysInterfaces;
using CSharpFunctionalExtensions;
using DAL.Entitys;
using Domain.Entitys;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositorys;

public class AuthorStore : IAuthorStore
{
    protected BasicDataBaseContext _context;

    public AuthorStore(BasicDataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<Author>> GetAll()
    {
        try
        {
            var authours = await _context
                .Authors
                .AsNoTracking()
                .ToListAsync();

            var formatedUser = authours.Select(ex =>
            {
                var validateAuthourName = AuthorName.Create(ex.FirstName, ex.LastName, ex.SecondName);

                if (validateAuthourName.IsFailure)
                {
                    return null;
                }

                var authourName = validateAuthourName.Value;

                var validateAuthour = Author.Create(ex.Id, authourName, ex.YearOfBirth);

                if (validateAuthour.IsFailure)
                {
                    return null;
                }

                var authour = validateAuthour.Value;

                return authour;
            });

            return formatedUser.ToList();
        }
        catch (Exception ex)
        {
            return new List<Author>();
        }
    }

    public async Task<Result<Author>> GetById(Guid id)
    {
        try
        {
            var user = await _context
                .Authors
                .AsNoTracking()
                .Where(ex => ex.Id == id)
                .FirstAsync();

                var validateAuthourName = AuthorName.Create(
                    user.FirstName,
                    user.LastName,
                    user.SecondName);

                if (validateAuthourName.IsFailure)
                {
                    return Result.Failure<Author>("user by this Id have name invalid");
                }

                var authourName = validateAuthourName.Value;

                var validateAuthour = Author.Create(user.Id, authourName, user.YearOfBirth);

                if (validateAuthour.IsFailure)
                {
                    return Result.Failure<Author>("user by this Id have invalid data");
                }

                var authour = validateAuthour.Value;
            
            return Result.Success<Author>(authour);
        }
        catch (Exception ex)
        {
            return Result.Failure<Author>(ex.Message);
        }
    }

    public async Task<Result> Create(Author author)
    {
        try
        {
            var authourSystem = new AuthourEntity()
            {
                Id = author.Id, FirstName = author.Name.FirstName, SecondName = author.Name.SecondName,
                LastName = author.Name.LastName, YearOfBirth = author.YearOfBirth
            };
            
            await _context.Authors.AddAsync(authourSystem);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }

    public async Task<Result> SaveChanges(Author author)
    {
        try
        {
            var baseUser = _context.Authors.First(ex => ex.Id == author.Id);

            baseUser.FirstName = author.Name.FirstName;
            baseUser.SecondName = author.Name.SecondName;
            baseUser.LastName = author.Name.LastName;
            baseUser.YearOfBirth = author.YearOfBirth;

            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }

    public async Task<Result> Delite(Author author)
    {
        try
        {
            var baseUser = _context.Authors.First(ex => ex.Id == author.Id);
            
            _context.Authors.Remove(baseUser);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }
}