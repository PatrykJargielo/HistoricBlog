using System.Data.SqlClient;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users.Roles;

namespace HistoricBlog.DAL.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HistoricBlogDbContext historicBlogDbContext) : base(historicBlogDbContext)
        {
        }

        /// TOMEK MANAGER~~~~~~~~~
        /// 
        //public GenericRepository<User> CreateAdminUser(User user, Role role)
        //{
        //   SqlTransaction tran = conn.BeginTransaction()
            
                
        //        // create
        //   tran.Commit();
        //        // add role to user
        //   tran.Dispose();

            

        //}


    }
}
