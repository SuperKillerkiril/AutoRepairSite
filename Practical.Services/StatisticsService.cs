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
    
    public IEnumerable<ProductSales> GetTopSellingProduct(IList<Purchase> _purchases, List<Product> _products, DateTime _startDate, DateTime _endDate)
    {
        var salesData = _purchases.Where(p => p.PurchaseDate >= _startDate && p.PurchaseDate <= _endDate)
            .GroupBy(p => p.ProductId)
            .Select(g => new { ProductId = g.Key, QuantitySold = g.Sum(p => p.Quantity) })
            .Join(_products, g => g.ProductId, p => p.Id, (g, p) => new ProductSales
                {
                    ProductId = p.Id,
                    ProductName = p.ProductName,
                    TotalQuantitySold = g.QuantitySold
                }
            );
        return salesData.OrderByDescending(s => s.TotalQuantitySold).Take(10);
    }

    public int GetTotalQuantityInStock(List<Product> _products)
    {
        return _products.Sum(p => p.QuantityInStock);
    }
    
}