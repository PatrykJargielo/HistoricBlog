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
        private readonly ILoggerService _loggerService;

        public TagService(ITagRepository tagRepository, ILoggerService loggerService) : base(tagRepository)
        {
            _tagRepository = tagRepository;
            _loggerService = loggerService;
        }

        public override GenericResult<Tag> Delete(Tag tagDelete)
        {
            var genericResult = new GenericResult<Tag>();
            return Update(tagDelete, genericResult);
        }

        public override GenericResult<Tag> Create(Tag createTag)
        {
            var genericResult = new GenericResult<Tag>();            
            return Create(createTag, genericResult);
        }

        public override GenericResult<Tag> Update(Tag updateTag)
        {
            var genericResult = new GenericResult<Tag>();
            return Update(updateTag, genericResult);
        }


    }
}
