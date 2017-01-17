using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Categories;

namespace HistoricBlog.BLL.Posts.Categories
{
    class CategoryService : GenericService<Category>, ICategoryService
    {
        private IGenericRepository<Category> _categoryRepository;

        public CategoryService(IGenericRepository<Category> categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

    }
}
