using System.ComponentModel.DataAnnotations;

namespace Model;

public class Purchase // Закупка, заказ автозапчастей
{
    [Key] public int Id { get; set; } 
    public int ProductId { get; set; } 
    public int ClientId { get; set; }
    public int Quantity { get; set; } 
    public decimal TotalPrice { get; set; } //Сумма Quantity и доставки
    public DateTime PurchaseDate { get; set; } 
    public int StoreId { get; set; } 
}