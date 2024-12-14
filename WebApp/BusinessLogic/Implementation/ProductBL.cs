using BusinessLogic.Abstraction;
using DataAccessLayer.Entities;
using Repositories.Abstraction;
using Repositories.Implemenation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic.Implementation
{
    public class ProductBL : IProductBL
    {
        private readonly IProductRepository _productRepo;

        public ProductBL(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }

        public bool AddProduct(ProductViewModel productVM)
        {
            var isAdded = _productRepo.Add(new DataAccessLayer.Entities.Product
            {
                ProductName = productVM.ProductName,
                ProductCode = productVM.ProductCode,
                ProductPrice = productVM.ProductPrice,
                CategoryId = 1
            });

            return isAdded;
        }

        public bool DeleteProduct(int productId)
        {
            return _productRepo.Delete(productId);
        }

        public bool DuplicateCheck(string productName, int productId)
        {
            return _productRepo.DuplicateCheck(productName, productId);
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            var products = _productRepo.GetAll(); 
            List<ProductViewModel> result = new List<ProductViewModel>();
            foreach (var product in products) {
                result.Add(new ProductViewModel
                {
                    ProductName = product.ProductName,
                    ProductCode = product.ProductCode,
                    ProductPrice = product.ProductPrice,
                    ProductId = product.ProductId,
                    CategoryId = product.CategoryId
                });
            }
            return result;
        }

        public ProductViewModel GetProductById(int productId)
        {
            var product = _productRepo.GetProductById(productId);
            if (product != null) {
                return new ProductViewModel
                {
                    ProductName = product.ProductName,
                    ProductCode = product.ProductCode,
                    ProductPrice = product.ProductPrice,
                    ProductId = product.ProductId,
                    CategoryId  = product.CategoryId
                };
            }
            return null;
        }

        public bool UpdateProduct(ProductViewModel productVM)
        {
            var isUpdated = _productRepo.Update(new DataAccessLayer.Entities.Product
            {
                ProductId = productVM.ProductId,
                ProductName = productVM.ProductName,
                ProductCode = productVM.ProductCode,
                ProductPrice = productVM.ProductPrice,
                CategoryId = productVM.CategoryId

            });

            return isUpdated;
        }
    }
}
