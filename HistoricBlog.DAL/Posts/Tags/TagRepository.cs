using System.Linq;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Entities;
using HistoricBlog.DAL.Repositories.Interfaces;

namespace HistoricBlog.DAL.Repositories
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
