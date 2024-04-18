using CSharpFunctionalExtensions;

namespace Domain.ValueObject;

public class Language : CSharpFunctionalExtensions.ValueObject
{
    public static Language Russian => new Language(1);
    public static Language English => new Language(2);
    public static Language French => new Language(3);

    protected static List<Language> _all = [Russian, English, French];
    
    public int Id { get; }
    
    protected Language(int id)
    {
        Id = id;
    }
    private Language(){}

    public static Result<Language> Create(int id)
    {
        if (_all.Any(ex => ex.Id == id) == false)
        {
            return Result.Failure<Language>("Invalid language id");
        }

        return Result.Success<Language>(new Language(id));
    }
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Id;
    }
}