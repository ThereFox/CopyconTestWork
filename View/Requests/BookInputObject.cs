using System.ComponentModel.DataAnnotations;

namespace BookTest.Requests;

public record BookInputObject
(
    [Required]string Name,
    [Required]int Year,
    [Required]string AuthorId,
    [Required]int LanguageId
);