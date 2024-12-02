using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic.Abstraction
{
    public interface IProductBL
    {
        // it will not directly dealed with Database objects. so it will return viewmodel (BL object
        IEnumerable<ProductViewModel> GetAllProducts();
        bool AddProduct(ProductViewModel productVM);
        bool UpdateProduct(ProductViewModel productVM);
        bool DeleteProduct(int productId);
        ProductViewModel GetProductById(int productId);

        bool DuplicateCheck(string productName, int productId);

    }
}
