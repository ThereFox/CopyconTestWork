using CSharpFunctionalExtensions;

namespace Domain.ValueObject;

public class Language : CSharpFunctionalExtensions.ValueObject
{
    public static Language Russian => new Language(nameof(Russian));
    public static Language English => new Language(nameof(English));
    public static Language French => new Language(nameof(French));

    protected static List<Language> _all = [Russian, English, French];
    
    public string Name { get; }
    
    protected Language(string name)
    {
        Name = name;
    }

    public static Result<Language> Create(string name)
    {
        if (_all.Any(ex => ex.Name == name) == false)
        {
            return Result.Failure<Language>("Invalid language name");
        }

        return Result.Success<Language>(new Language(name));
    }
    
    protected override IEnumerable<IComparable> GetEqualityComponents()
    {
        yield return Name;
    }
}