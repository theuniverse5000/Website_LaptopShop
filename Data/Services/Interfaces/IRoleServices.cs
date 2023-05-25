using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IRoleServices
    {
        Task<List<Role>> GetAllRoles();
        Task<bool> Update(Role role,Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Add(Role role);
        Task<Role> GetById(Guid id);
        Task<bool> GetByName(string name);
    }
}
