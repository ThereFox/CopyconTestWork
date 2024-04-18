using CSharpFunctionalExtensions;
using Domain.ValueObject;

namespace Domain.Entitys;

public class Author : Entity<Guid>
{
    public AuthorName Name { get; private set; }
    public int YearOfBirth { get; private set; }

    public Result ChangeYearOfBirth(int newYearOfBirth)
    {
        if (newYearOfBirth >= DateTime.Today.Year)
        {
            return Result.Failure("author old must be more 0");
        }

        YearOfBirth = newYearOfBirth;
        return Result.Success();
    }
    public Result ChangeName(AuthorName name)
    {
        if (Name == name)
        {
            return Result.Failure("nothing to change");
        }

        Name = name;
        return Result.Success();
    }


    protected Author(Guid id, AuthorName name, int yearOfBirth)
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