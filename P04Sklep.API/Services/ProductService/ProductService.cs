using P05Sklep.Shared;

namespace P04Sklep.API.Services.ProductService
{
    public class ProductService : IProductService
    {
        public async Task<ServiceResponse<Product[]>> GetProductAsync()
        {
            // odwołanie się do DataContext (baza danych)
            var data = new Product[2]
            {
                new Product()
                {
                    Id = 1,
                    Title = "Product 1",
                    Description = "Desc 1"

                }, new Product()
                {
                    Id = 2,
                    Title = "Product 2",
                    Description = "Desc 2"
                }
            };

            var response = new ServiceResponse<Product[]>()
            {
                Data = data
            };

            return response;
        }
    }
}
