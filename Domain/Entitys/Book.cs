using CSharpFunctionalExtensions;
using Domain.ValueObject;

namespace Domain.Entitys;

public class Book : Entity<Guid>
{
    public string Name { get; private set; }
    public int Year { get; private set; }
    public Author Writer { get; private set; }
    public Language OriginalLanguage { get; private set; }

    protected Book(Guid id, string name, int year, Author writer, Language originalLanguage)
    {
        Id = id;
        Name = name;
        Year = year;
        Writer = writer;
        OriginalLanguage = originalLanguage;
    }

    public static Result<Book> Create(Guid id, string name, int year, Author writer, Language originalLanguage)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Result.Failure<Book>("name must be not null or empty");
        }

        if (year < 0 || year > DateTime.Today.Year)
        {
            return Result.Failure<Book>("year invalid");
        }

        return Result.Success<Book>(new Book(id, name, year, writer, originalLanguage));
    }
    
}