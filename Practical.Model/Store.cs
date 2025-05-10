using System.ComponentModel.DataAnnotations;

namespace Model;

public class Store //Магазин продажи
{
    [Key] public int Id { get; set; } 
    public string Name { get; set; } 
    public string Location { get; set; } 
}