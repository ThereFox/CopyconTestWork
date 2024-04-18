using System.ComponentModel.DataAnnotations;
using Domain.ValueObject;

namespace BookTest.Requests;

public record UpdateAuthourRequest
(
    string Id,
    string FirstName,
    string LastName,
    string? SecondName,
    int yearOfBirth
);