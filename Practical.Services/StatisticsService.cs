using Model;
using Model.InternalModels;
using Practical.DataBase;


namespace Practical.Services;

public class StatisticsService
{
    private readonly ModelContext _context;
    
    public List<ProductSales> GetTopSellingProduct(DateTime startDate, DateTime endDate)
    {
        List<Product> getProducts = _context.Products.ToList();
        List<Purchase> getPurchases = _context.Purchases.ToList();
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
        return salesData.OrderByDescending(s => s.TotalQuantitySold).ToList();
    }

    public int GetTotalQuantityInStock() //общее кол-во на складе 
    {
        List<Product> getProducts = _context.Products.ToList();
        return getProducts.Sum(p => p.QuantityInStock);
    }

    public List<SupplierStatistic> GetSupplierStatistics(DateTime timeStart, DateTime timeEnd) //стата по поставщикам тоже в виде отдельного класса, но операторами
    {
        List<Purchase> purchases = _context.Purchases.ToList();
        List<Supplier> suppliers = _context.Suppliers.ToList();
        List<Product> products = _context.Products.ToList();
        var query = from p in purchases
            join prod in products on p.ProductId equals prod.Id
            join sup in suppliers on prod.SupplierId equals sup.Id
            where p.PurchaseDate >= timeStart && p.PurchaseDate <= timeEnd
            group p by new { sup.Id, sup.Name }
            into g
            select new SupplierStatistic
            {
                SupplierId = g.Key.Id,
                SupplierName = g.Key.Name,
                TotalQuantityPurchased = g.Sum(p => p.Quantity), //общее количество приобретенных товаров
                TotalSpent = g.Sum(p => p.TotalPrice) //общее количество потраченных 
            };
        return query.OrderByDescending(s => s.TotalQuantityPurchased).ToList();
    }
}
