namespace Model.InternalModels;

public class SupplierStatistic
{
    public int SupplierId { get; set; } 
    public string? SupplierName { get; set; }
    public int TotalQuantityPurchased { get; set; }
    public decimal TotalSpent { get; set; }
}