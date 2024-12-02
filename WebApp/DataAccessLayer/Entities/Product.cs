using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [Column(TypeName ="varchar(200)")]
        public string ProductCode { get; set; }

        public decimal ProductPrice { get; set; }

        //foreign key
        public int CategoryId { get;set; }

        //navigation property
        public Category Category { get; set; } // will create relation
    }
}
