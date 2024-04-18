using App.RepositorysInterfaces;
using CSharpFunctionalExtensions;
using DAL.Entitys;
using Domain.Entitys;
using Domain.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositorys;

public class BookStore : IBookStore
{
    protected BasicDataBaseContext _context;

    public BookStore(BasicDataBaseContext context)
    {
        _context = context;
    }
    
    public async Task<List<Book>> GetAll()
    {
        var books = await _context
            .Books
            .AsNoTracking()
            .Include(ex => ex.Authour)
            .ToListAsync();

        var convertedBook = books.Select(ex =>
        {
            var validationLanguage = Language.Create(ex.LanguageId);

            if (validationLanguage.IsFailure)
            {
                return null;
            }

            var language = validationLanguage.Value;

            var authourInfo = ex.Authour;
            var validateAuthourName = AuthorName.Create(authourInfo.FirstName, authourInfo.LastName, authourInfo.SecondName);

            if (validateAuthourName.IsFailure)
            {
                return null;
            }

            var authourName = validateAuthourName.Value;

            var validateAuthour = Author.Create(authourInfo.Id, authourName, authourInfo.YearOfBirth);

            if (validateAuthour.IsFailure)
            {
                return null;
            }

            var authour = validateAuthour.Value;
            
            var validateBook = Book.Create(ex.Id, ex.Name, ex.Year, authour, language);

            if (validateBook.IsFailure)
            {
                return null;
            }

            return validateBook.Value;
        }).ToList();
        return convertedBook;
    }

    public async Task<Result<Book>> GetById(Guid id)
    {
        try
        {
            var book = await _context
                .Books
                .AsNoTracking()
                .Where(ex => ex.Id == id)
                .Include(ex => ex.Authour)
                .FirstAsync();

            var validateLanguage = Language.Create(book.LanguageId);

            if (validateLanguage.IsFailure)
            {
                return Result.Failure<Book>(validateLanguage.Error);
            }

            var language = validateLanguage.Value;

            var authourInfo = book.Authour;
            var validateAuthourName = AuthorName.Create(authourInfo.FirstName, authourInfo.LastName, authourInfo.SecondName);

            if (validateAuthourName.IsFailure)
            {
                return null;
            }

            var authourName = validateAuthourName.Value;

            var validateAuthour = Author.Create(authourInfo.Id, authourName, authourInfo.YearOfBirth);

            if (validateAuthour.IsFailure)
            {
                return null;
            }

            var authour = validateAuthour.Value;
            
            var validateBook = Book.Create(book.Id, book.Name, book.Year, authour, language);

            if (validateBook.IsFailure)
            {
                return Result.Failure<Book>(validateBook.Error);
            }

            var convertedBook = validateBook.Value;
            
            return Result.Success<Book>(convertedBook);
        }
        catch (Exception ex)
        {
            return Result.Failure<Book>(ex.Message);
        }
    }

    public async Task<Result> Create(Book book)
    {
        try
        {
            var convertedBook = new BookEntity()
            {
                Id = book.Id, AuthourId = book.Author.Id, LanguageId = book.OriginalLanguage.Id,
                Name = book.Name, Year = book.Year
            };
            
            await _context.Books.AddAsync(convertedBook);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }

    public async Task<Result> SaveChanges(Book book)
    {
        try
        {
            var initBook = _context.Books.First(ex => ex.Id == book.Id);

            initBook.AuthourId = book.Author.Id;
            initBook.LanguageId = book.OriginalLanguage.Id;
            initBook.Year = book.Year;
            initBook.Name = book.Name;

            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }

    public async Task<Result> Delite(Book book)
    {
        try
        {
            var getBook = _context.Books.First(ex => ex.Id == book.Id);
            _context.Books.Remove(getBook);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex.Message);
        }
    }
}