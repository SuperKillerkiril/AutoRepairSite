using System.ComponentModel.DataAnnotations;

namespace Model;

public class Product 
{
    [Key] public int Id { get; set; }
    public string Image { get; set; }
    public string ProductName { get; set; }
    public string PartNumber { get; set; }
    public string ProductDescription { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public int QuantityInStock { get; set; }
    public int MinimumStockLevel { get; set; } 
    public int SupplierId { get; set; } 
    public DateTime DateAdded { get; set; } 
}