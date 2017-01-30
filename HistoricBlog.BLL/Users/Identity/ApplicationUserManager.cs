using HistoricBlog.BLL.PasswordHasher.Hasher;
using HistoricBlog.DAL.Users;
using HistoricBlog.DAL.Users.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace HistoricBlog.BLL.Users.Identity
{
    public class ApplicationUserManager : UserManager<User,int>
    {
        private readonly IUserStore<User, int> _userStore;

        public ApplicationUserManager(IUserStore<User, int> userStore)
            : base(userStore)
        {
            _userStore = userStore;
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStoreService());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            
            manager.PasswordHasher = new HashService();
            return manager;
        }
    }
}
