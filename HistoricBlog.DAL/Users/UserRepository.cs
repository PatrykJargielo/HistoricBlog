﻿using System.Data.SqlClient;
using HistoricBlog.DAL.Base;

namespace HistoricBlog.DAL.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }


    }
}
