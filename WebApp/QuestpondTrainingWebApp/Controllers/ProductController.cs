using Microsoft.AspNetCore.Mvc;
using QuestpondTrainingWebApp.Models;

namespace QuestpondTrainingWebApp.Controllers
{
    public class ProductController : Controller
    {
        static List<ProductViewModel> products = new List<ProductViewModel> { new ProductViewModel() { ProductId = 001, ProductCode = "P001", ProductName = "Laptop", ProductPrice = 50000 } };
        public IActionResult GetProductInfo()
        {
            ProductViewModel productViewModel = new ProductViewModel
            {
                ProductPrice = 123,
                ProductCode = "P001", 
                ProductId = 1,
                ProductName = "Product 1"
            };

          //  ViewData["product"] = productViewModel;
            return View("Index", productViewModel);

        }

        [Route("product/create")]
        //[HttpPost]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [Route("product/addproduct")]
        public IActionResult SaveProduct(ProductViewModel productViewModel, int view = 0)
        {
            //check duplicate product validation
           if(!string.IsNullOrEmpty(productViewModel.ProductName) && DuplicateProduct(productViewModel.ProductName)) {
                ModelState.AddModelError("DuplicateCheck", "Product Name already exists");
            }

            if (ModelState.IsValid)
            {
               // if (productViewModel != null && productViewModel.ProductId != 0)
               // {
                    products.Add(productViewModel);
                return RedirectToAction("Summary", "Product");
               // }
               
            }
            return View("CreateProduct");
        }

        [HttpGet]
        [Route("product/product-list")]
        public IActionResult Summary(int view = 0)
        {
            if (view == 0)
            {
                return View("SaveProduct", products);
            }
            else
            {
                return View("productcards", products);
            }

        }

        private bool DuplicateProduct(string productName)
        {
            return products.Where(p => p.ProductName.ToLower() == productName.ToLower()).Any();
        }
    }
}
