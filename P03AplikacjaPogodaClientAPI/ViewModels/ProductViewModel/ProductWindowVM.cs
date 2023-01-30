using P03AplikacjaPogodaClientAPI.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.ViewModels.ProductViewModel
{
    public class ProductWindowVM : ViewModelBase
    {
        ProductsApiTool tool;
        public ObservableCollection<ProductVM> Products { get; set; }

        public ProductWindowVM()
        {
            Products = new ObservableCollection<ProductVM>();
            tool = new ProductsApiTool();
            GetProducts();          
        }

        public async void GetProducts()
        {
            var products = await tool.GetProducts();

            foreach (var product in products)
            {
                Products.Add(new ProductVM(product));
            }
        }
    }
}
