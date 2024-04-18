using CSharpFunctionalExtensions;

namespace Domain.ValueObject;

public class AuthorName : CSharpFunctionalExtensions.ValueObject
{
    public string FirstName { get; }
    public string LastName { get; }
    public string SecondName { get; }

    protected AuthorName(string firstName, string lastName, string secondName)
    {
        FirstName = firstName;
        LastName = lastName;
        SecondName = secondName;
    }
    private AuthorName(){}

    public static Result<AuthorName> Create(string firstName, string lastName, string secondName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result.Failure<AuthorName>("firstName must be not null or empty");
        }
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result.Failure<AuthorName>("lastName must be not null or empty");
        }

        return Result.Success<AuthorName>(new AuthorName(firstName, lastName, secondName));
    }

    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return SecondName;
    }
}