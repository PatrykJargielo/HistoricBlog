using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace HistoricBlog.DAL.Users.Identity
{
    public class UserStore : IUserStore<User,int>, IUserPasswordStore<User,int>
    {
        private readonly HistoricBlogDbContext _historicBlogDbContext;
        public void Dispose()
        {
            _historicBlogDbContext.Dispose();
        }

        public UserStore()
        {
            _historicBlogDbContext = new HistoricBlogDbContext();
        }

        public Task CreateAsync(User user)
        {
            _historicBlogDbContext.Users.Add(user);
            Task task = _historicBlogDbContext.SaveChangesAsync();
            return task;
        }

        public Task UpdateAsync(User user)
        {
            _historicBlogDbContext.Users.Attach(user);
            Task task = _historicBlogDbContext.SaveChangesAsync();
            return task;
        }

        public Task DeleteAsync(User user)
        {
            _historicBlogDbContext.Users.Remove(user);
            Task task = _historicBlogDbContext.SaveChangesAsync();
            return task;
        }

        public Task<User> FindByIdAsync(int userId)
        {
            Task<User> task = _historicBlogDbContext.Users.Where(
                             apu => apu.Id == userId)
                             .FirstOrDefaultAsync();

            return task;
        }

        public Task<User> FindByNameAsync(string userName)
        {
            Task<User> task =
                _historicBlogDbContext.Users.Where(user => user.UserName == userName).FirstOrDefaultAsync();
            return task;
        }

        public Task SetPasswordHashAsync(User user, string passwordHash)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.Password = passwordHash);
        }

        public Task<string> GetPasswordHashAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(User user)
        {
            return Task.FromResult(user.Password != null);
        }
    }
}
