using HistoricBlog.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.DAL
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public Tag GetSingle(int tabId)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == tabId);
            return query;
        }
    }
}
