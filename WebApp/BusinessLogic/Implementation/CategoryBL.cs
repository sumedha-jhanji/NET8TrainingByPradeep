﻿using BusinessLogic.Abstraction;
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
    public class CategoryBL : ICategoryBL
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBL()
        {
            _categoryRepository = new CategoryRepository();
        }

        public IEnumerable<CategoryViewModel> GetActiveCategories()
        {
            var categories = _categoryRepository.GetAll();
            List<CategoryViewModel> result = new();
            foreach (var category in categories) {
                result.Add(new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                });
            }

            return result;
        }
    }
}
