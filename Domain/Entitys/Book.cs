using CSharpFunctionalExtensions;
using Domain.ValueObject;

namespace Domain.Entitys;

public class Book : Entity<Guid>
{
    public string Name { get; private set; }
    public int Year { get; private set; }
    public Language OriginalLanguage { get; private set; }
    public Author Author { get; private set; }

    protected Book(Guid id, string name, int year, Author author, Language originalLanguage)
    {
        Id = id;
        Name = name;
        Year = year;
        OriginalLanguage = originalLanguage;
        Author = author;
    }
    
    public static Result<Book> Create(Guid id, string name, int year, Author author, Language originalLanguage)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Book>("name must be not null or empty");
        }

        if (year < 0 || year > DateTime.Today.Year)
        {
            return Result.Failure<Book>("year invalid");
        }

        return Result.Success<Book>(new Book(id, name, year, author, originalLanguage));
    }
    
}