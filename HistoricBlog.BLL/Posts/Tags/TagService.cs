using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Posts.Tags;
using HistoricBlog.BLL.Logger;

namespace HistoricBlog.BLL.Posts.Tags
{
    public class TagService : GenericService<Tag>, ITagService
    {
        private readonly ITagRepository _tagRepository;


        public TagService(ITagRepository tagRepository) : base(tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public GenericResult<Tag> GetTagByName(string name)
        {
            var result = new GenericResult<Tag>();
            result.Result = _tagRepository.FindBy(tag => tag.Name == name).Result.FirstOrDefault();
            return result;
        }
    }
}
