namespace BookTest.Requests;

public record UpdateBookInputObject
(

    string Id,
    string Name,
    int Year,
    string AuthorId,
    int LanguageId
    
);