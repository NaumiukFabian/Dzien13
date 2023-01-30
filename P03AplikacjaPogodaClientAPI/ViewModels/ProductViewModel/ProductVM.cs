using P05Sklep.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03AplikacjaPogodaClientAPI.ViewModels.ProductViewModel
{
    public class ProductVM
    {
        private Product _product;
        public ProductVM(Product product)
        {
            _product = product;
        }

        public int Id => _product.Id;
        public string Title => _product.Title;
        public string Description => _product.Description;

    }
}
