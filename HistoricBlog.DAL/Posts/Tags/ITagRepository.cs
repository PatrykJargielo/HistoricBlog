using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Entities;

namespace HistoricBlog.DAL.Repositories.Interfaces
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Tag GetSingle(int tagId);
    }
}
