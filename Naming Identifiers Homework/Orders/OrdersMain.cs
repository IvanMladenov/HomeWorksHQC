namespace Orders
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    internal class OrdersMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var dataMapper = new DataMapper();
            var allCategories = dataMapper.GetAllCategories();
            var allProducts = dataMapper.GetAllProducts();
            var allOrders = dataMapper.GetAllOrders();

            var fiveMostExpensiveProductsNames =
                allProducts.OrderByDescending(p => p.UnitPrice).Take(5).Select(p => p.Name);

            Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiveProductsNames));

            Console.WriteLine(new string('-', 10));

            var numberOfProductsInCategory =
                allProducts.GroupBy(p => p.CategoryId)
                    .Select(
                        group =>
                        new
                            {
                                Category = allCategories.First(c => c.Id == group.Key).Name, 
                                Count = group.Count()
                            })
                    .ToList();
            foreach (var item in numberOfProductsInCategory)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }

            Console.WriteLine(new string('-', 10));

            var topFiveProductsOrderedByQuantity =
                allOrders.GroupBy(order => order.ProductId)
                    .Select(
                        group =>
                        new
                            {
                                Product = allProducts.FirstOrDefault(p => p.Id == group.Key).Name, 
                                Quantities = group.Sum(order => order.Quantity)
                            })
                    .OrderByDescending(q => q.Quantities)
                    .Take(5);
            foreach (var item in topFiveProductsOrderedByQuantity)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }

            Console.WriteLine(new string('-', 10));

            var mostProfitableCategory =
                allOrders.GroupBy(o => o.ProductId)
                    .Select(
                        grouping =>
                        new
                            {
                                ProductCategoryId = allProducts.First(p => p.Id == grouping.Key).CategoryId, 
                                Price = allProducts.First(p => p.Id == grouping.Key).UnitPrice, 
                                Quantity = grouping.Sum(p => p.Quantity)
                            })
                    .GroupBy(product => product.ProductCategoryId)
                    .Select(
                        productGroup =>
                        new
                            {
                                CategoryName = allCategories.First(c => c.Id == productGroup.Key).Name, 
                                TotalQuantity = productGroup.Sum(g => g.Quantity * g.Price)
                            })
                    .OrderByDescending(productGroup => productGroup.TotalQuantity)
                    .First();

            Console.WriteLine("{0}: {1}", mostProfitableCategory.CategoryName, mostProfitableCategory.TotalQuantity);
        }
    }
}