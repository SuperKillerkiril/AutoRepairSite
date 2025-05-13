using Model;

namespace Practical.Services;

public class StatisticsService
{
    readonly List<Product> products;
    readonly List<Purchase> purchases;
    public class ProductSales
    {
        public int ProductId { get; set; } 
        public string ProductName { get; set; }
        public int TotalQuantitySold { get; set; }
    }
    
    public IEnumerable<ProductSales> GetTopSellingProduct(IList<Purchase> getPurchases, List<Product> getProducts, DateTime startDate, DateTime endDate)
    {
        var salesData = getPurchases.Where(p => p.PurchaseDate >= startDate && p.PurchaseDate <= endDate)
            .GroupBy(p => p.ProductId)
            .Select(g => new { ProductId = g.Key, QuantitySold = g.Sum(p => p.Quantity) })
            .Join(getProducts, g => g.ProductId, p => p.Id, (g, p) => new ProductSales
                {
                    ProductId = p.Id,
                    ProductName = p.ProductName,
                    TotalQuantitySold = g.QuantitySold
                }
            );
        return salesData.OrderByDescending(s => s.TotalQuantitySold).Take(10);
    }

    public int GetTotalQuantityInStock(List<Product> getProducts)
    {
        return getProducts.Sum(p => p.QuantityInStock);
    }
    
}