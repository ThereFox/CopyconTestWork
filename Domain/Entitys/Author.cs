using CSharpFunctionalExtensions;
using Domain.ValueObject;

namespace Domain.Entitys;

public class Author : Entity<Guid>
{
    private List<Book> _writedBooks; 
    
    public AuthorName Name { get; private set; }
    public int YearOfBirth { get; private set; }

    public IReadOnlyCollection<Book> WritedBooks => _writedBooks;

    public Author(Guid id, AuthorName name, int yearOfBirth)
    {
        Id = id;
        Name = name;
        YearOfBirth = yearOfBirth;
    }

    public static Result<Author> Create(Guid id, AuthorName name, int yearOfBirth)
    {
        if (yearOfBirth >= DateTime.Today.Year)
        {
            return Result.Failure<Author>("author old must be more 0");
        }

        return Result.Success<Author>(new Author(id, name, yearOfBirth));
    }
    
}