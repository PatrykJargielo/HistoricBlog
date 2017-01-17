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

      


    }
}
