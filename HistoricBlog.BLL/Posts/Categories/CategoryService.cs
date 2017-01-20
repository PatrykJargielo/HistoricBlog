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
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public GenericResult<Category> GetCategoryByName(string name)
        {
            var result = new GenericResult<Category>();
            result.Result = _categoryRepository.FindBy(category => category.Name == name).Result.FirstOrDefault();
            result.IsVaild = true;
            return result;
        }
    }
}
