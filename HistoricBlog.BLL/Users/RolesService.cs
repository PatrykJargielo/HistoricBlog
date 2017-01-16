using HistoricBlog.BLL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HistoricBlog.DAL.Base;
using HistoricBlog.DAL.Users;
using HistoricBlog.DAL.Users.Roles;

namespace HistoricBlog.BLL.Users
{
    public class RolesService : GenericService<Role>, IRolesService
    {
        private readonly IRoleRepository _roleRepository;
        public RolesService(IRoleRepository roleRepository) : base(roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public override GenericResult<Role> Create(Role entity)
        {
            throw new NotImplementedException();
        }
        public  GenericResult<Role> GetAll(Role entity)
        {
            throw new NotImplementedException();
        }

        public override GenericResult<Role> Delete(Role entity)
        {
            throw new NotImplementedException();
        }

        public override GenericResult<Role> Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}
