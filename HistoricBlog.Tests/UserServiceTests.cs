using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.BLL.Users;
using HistoricBlog.DAL;
using HistoricBlog.DAL.Posts.Comments;
using HistoricBlog.DAL.Posts.Ratings;
using HistoricBlog.DAL.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ploeh.AutoFixture;

namespace HistoricBlog.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void GetUsers()
        {
            var fixture = new Fixture();
            var login = fixture.Create<string>();
            var password = "kotel123";
            var name = fixture.Create<string>();
            var surname = fixture.Create<string>();
            var email = "test@test.test";
            IList<Comment> comments = new List<Comment>();
            IList<Role> roles = new List<Role>();
            IList<Rating> ratings = new List<Rating>();

            var users = new List<User>
            {
                new User()
                { Login = login,Password = password,Name = name,Surname = surname,Email = email,Comments = null,Roles =null,Ratings = null}
            }.AsQueryable();

            var userMock = UserMock(users);

            var historicalBlogDbContextMock = new Mock<HistoricBlogDbContext>();

            historicalBlogDbContextMock.Setup(x => x.Users).Returns(userMock.Object);
            historicalBlogDbContextMock.Setup(x => x.Set<User>()).Returns(userMock.Object);

            var userRepository = new UserRepository(historicalBlogDbContextMock.Object);
            var userService = new UserService(userRepository);

            var userFromService = userService.GetAll().Result.FirstOrDefault();
    

             Assert.AreEqual(users.FirstOrDefault()?.Login, userFromService?.Login);
        }

        private static Mock<DbSet<User>> UserMock(IQueryable<User> users) 
        {
            var userMock = new Mock<DbSet<User>>();
            userMock.As<IQueryable<User>>().Setup(x => x.Provider).Returns(users.Provider);
            userMock.As<IQueryable<User>>().Setup(x => x.Expression).Returns(users.Expression);
            userMock.As<IQueryable<User>>().Setup(x => x.ElementType).Returns(users.ElementType);
            userMock.As<IQueryable<User>>().Setup(x => x.GetEnumerator()).Returns(users.GetEnumerator());
            return userMock;
        }
    }
}
