﻿using HistoricBlog.BLL.Base;
using HistoricBlog.DAL.Posts.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricBlog.BLL.Posts.Tags
{
    public interface ITagService : IGenericService<Tag>
    {
        Tag AddTag();
        IEnumerable<Tag> GetPostTags(int postId);
        IEnumerable<Tag> GetAllTags();
    }
}
