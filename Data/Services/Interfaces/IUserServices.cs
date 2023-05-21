using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Services.Interfaces
{
    public interface IUserServices
    {
        Task<List<User>> GetAllUser();
        Task<bool> Update(User u);
        Task<bool> Delete(Guid id);
        Task<bool> Add(User user);
        Task<User> GetById(Guid id);
        Task<List<string>> GetByName(string name);

    }
}
