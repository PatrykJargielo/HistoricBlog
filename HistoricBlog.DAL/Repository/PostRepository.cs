using HistoricBlog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.DAL
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public Post GetSingle(int postId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == postId);
            return query;
        }
    }
}
