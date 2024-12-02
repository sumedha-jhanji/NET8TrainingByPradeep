using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implemenation
{
    public class ProductRepository : IProductRepository
    {
        private readonly TrainingDbContext _context;
        public ProductRepository()
        {
            _context = new TrainingDbContext();
        }

        public bool Add(Product productToAdd)
        {
            try
            {
                _context.Database.BeginTransaction();
                _context.Products.Add(productToAdd);
                var rowsAffected = _context.SaveChanges(); //open connection, generate insert script, execute script, fetch latest id, close connection
                _context.Database.CommitTransaction();
                return (rowsAffected > 0);
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                return false;
            }
        }

        public bool Delete(int productId)
        {
            //ef doesn't have any method to delete. it has for remove but not delete.
            // executeDelete - select the record and delete it
            _context.Products.Where(d => d.ProductId == productId).ExecuteDelete(); // if no product id, it will return 0
            var rowsAffected = _context.SaveChanges();
            return (rowsAffected > 0);


            // or we can get the product, then check if we have product and then call .Remove()
        }

        public bool DuplicateCheck(string productName, int productId)
        {
            return _context.Products.Where(p => p.ProductId != productId && p.ProductName.ToLower() == productName.ToLower()).Any();
        }

        public IEnumerable<Product> GetAll()
        {
            var products = (from prod in _context.Products
                            where prod.ProductId > 0
                            select prod).ToList(); // toList will actually execute the query //.AsNoLocking() - will not lock table
            return products;
        }

        public Product GetProductById(int productId)
        {
            var product = _context.Products.Where(p => p.ProductId == productId).FirstOrDefault();
            if(product != null)
                return product;

            return new Product();
               
        }

        public bool Update(Product productToAUpdate)
        {
            //one way
            //_context.Products.Where(condition).ExecuteUpdate(s=> {s.SetProperty(p => p.productCode, productToAUpdate.ProductCode)}); // if we want to update specific properpty

            _context.Entry<Product>(productToAUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }
    }
}
