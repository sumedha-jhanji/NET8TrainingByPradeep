using DataAccessLayer;
using DataAccessLayer.Entities;
using Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implemenation
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly TrainingDbContext _context;
        public CategoryRepository()
        {
            _context = new TrainingDbContext();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.Where(c => c.CategoryId > 0).ToList();
        }
    }
}
