using System.ComponentModel.DataAnnotations;

namespace Model;

public class Supplier //Поставщик 
{
    [Key] public int Id { get; set; }
    public string Name { get; set; }
    public string ContactNumber { get; set; } 
    public string Email { get; set; } 
    public string Address { get; set; } 
}