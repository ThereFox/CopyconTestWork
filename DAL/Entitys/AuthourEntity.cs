namespace DAL.Entitys;

public class AuthourEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public int YearOfBirth { get; set; }
    
    public List<BookEntity> Books { get; set; }

}