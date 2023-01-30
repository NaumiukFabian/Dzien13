using Bogus;
using P05Sklep.Shared;

namespace P06Sklep.DataSeeder
{
    public class ProductSeeder
    {
        public static Product[] GenerateProductData()
        {
            int productId = 1;

            var productFaker = new Faker<Product>()
                .RuleFor(o => o.Title, f => f.Commerce.ProductName())
                .RuleFor(o => o.Description, f => f.Commerce.ProductDescription())
                .RuleFor(o => o.Id, f => productId++);

            return productFaker.Generate(10).ToArray();
                
        }
    }
}