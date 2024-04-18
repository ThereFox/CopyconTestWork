using System.Net;

namespace DAL.Entitys;

public class BookEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int LanguageId { get; set; }
    
    public Guid AuthourId { get; set; }
    
    public AuthourEntity Authour { get; set; }
    
}