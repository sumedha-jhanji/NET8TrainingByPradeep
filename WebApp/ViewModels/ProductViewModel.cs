using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ProductViewModel
    {
        [ScaffoldColumn(false)]
        [DisplayName("Product ID")]
        [Required(ErrorMessage = "Product ID is mandatory")]
        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product Name is mandatory")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Product Name can contain alphabets, digits and space")]
        public string ProductName { get; set; }

        [DisplayName("Product Code")]
        [Required(ErrorMessage = "Product Code is mandatory")]
        public string ProductCode { get; set; }

        [DisplayName("Product Price")]
        [Range(0, double.MaxValue)]
        [Required(ErrorMessage = "Product Price is mandatory")]
        public decimal ProductPrice { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Select Category")]
        public int CategoryId { get; set; }
    }
}
