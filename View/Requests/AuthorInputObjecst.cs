using Domain.ValueObject;

namespace BookTest.Requests;

public record AuthorInputObjecst(
    string FirstName,
    string LastName,
    string? SecondName,
    int YearOfBirth
    );