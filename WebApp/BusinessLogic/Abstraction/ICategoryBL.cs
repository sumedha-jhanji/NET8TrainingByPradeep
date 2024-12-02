using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace BusinessLogic.Abstraction
{
    public interface ICategoryBL
    {
        IEnumerable<CategoryViewModel> GetActiveCategories();
    }
}
