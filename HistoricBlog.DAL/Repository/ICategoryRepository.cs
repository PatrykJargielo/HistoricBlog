using HistoricBlog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.DAL
{
    public interface ICategoryRepository : IRepositories<Category>
    {
        Category GetSingle(int categoryId);
    }
}
