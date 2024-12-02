using BusinessLogic.Abstraction;
using BusinessLogic.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestpondTrainingWebApp.Models;
using ViewModels;

namespace QuestpondTrainingWebApp.Controllers
{
    public class ProductController : Controller
    {
        static List<ProductViewModel> products = new List<ProductViewModel> { new ProductViewModel() { ProductId = 001, ProductCode = "P001", ProductName = "Laptop", ProductPrice = 50000 } };
        private readonly IProductBL _productBL;
        private readonly ICategoryBL _categoryBL;

        public ProductController()
        {
            _productBL = new ProductBL();
            _categoryBL = new CategoryBL();
        }

        public IActionResult GetProductInfo(int productId)
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
            var categories = new SelectList(_categoryBL.GetActiveCategories(), "CategoryId", "CategoryName");
            ViewBag.Categories = categories;
            return View();
        }

        [Route("product/addproduct")]
        public IActionResult SaveProduct(ProductViewModel productViewModel, int view = 0)
        {
            //check duplicate product validation
           if(!string.IsNullOrEmpty(productViewModel.ProductName) && DuplicateProduct(productViewModel.ProductName, productViewModel.ProductId)) {
                ModelState.AddModelError("DuplicateCheck", "Product Name already exists");
            }

            if (ModelState.IsValid)
            {
                _productBL.AddProduct(productViewModel);
                return RedirectToAction("Summary", "Product");
               
            }

            var categories = new SelectList(_categoryBL.GetActiveCategories(), "CategoryId", "CategoryName");
            ViewBag.Categories = categories;
            return View("CreateProduct");
        }

        [HttpGet]
        [Route("product/product-list")]
        public IActionResult Summary(int view = 0)
        {
            var products = _productBL.GetAllProducts();
            if (view == 0)
            {
                return View("SaveProduct", products);
            }
            else
            {
                return View("productcards", products);
            }

        }

        private bool DuplicateProduct(string productName, int productId)
        {
            return _productBL.DuplicateCheck(productName, productId);
        }
    }
}
