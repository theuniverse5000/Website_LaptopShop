using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Services.Interfaces;
using Data.Models;
using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Data.Services.Implements
{
    public class UserServices : IUserServices
    {
        ApplicationDbContext _context;
        public UserServices()
        {
            _context = new ApplicationDbContext();
        }
        public async Task<bool> Add(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var listObj = await _context.Users.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                _context.Remove(temp);
                await Task.FromResult<User>(_context.Users.Remove(temp).Entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            var listObj = await _context.Users.ToListAsync();
            if (listObj == null)
            {
                return new();
            }
            return listObj;
        }

        public async Task<User> GetById(Guid id)
        {
            var listObj = await _context.Users.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Id == id);

            if (temp == null)
            {
                return new User();
            }
            return temp;
        }

        public async Task<List<string>> GetByName(string name)
        {
            var listObj = await _context.Users.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Equals(name));

            if (listObj == null)
            {
                return null;
            }
            return new List<string>();
        }

        public async Task<bool> Update(User u)
        {
            try
            {
               var c = _context.Users.Find(u.Id);
                c.Username = u.Username;
                c.Password = u.Password;
                c.Status = u.Status;
                c.IdRole = u.IdRole;
               

                _context.Update(c);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
