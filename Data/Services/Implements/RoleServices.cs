using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Data.Services.Implements
{
    public class RoleServices:IRoleServices
    {
        private readonly ApplicationDbContext context;
        public RoleServices()
        {
            context = new ApplicationDbContext();
        }

        public async Task<bool> Add(Role role)
        {
            try
            {
                role.Id = Guid.NewGuid();
                await context.AddAsync(role);
                await context.SaveChangesAsync();
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
                var listObj = await context.Roles.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                context.Remove(temp);
                await Task.FromResult<Role>(context.Roles.Remove(temp).Entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Role>> GetAllRoles()
        {
            var listObj = await context.Roles.ToListAsync();
            if (listObj == null)
            {
                return new();
            }
            return listObj;
        }

        public async Task<Role> GetById(Guid id)
        {
            return await context.Roles.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<bool> GetByName(string name)
        {
            var temp = await context.Roles.ToListAsync();
            var obj = temp.FirstOrDefault(v=> v.RoleName == name);
            if (obj == null)
            {
                return false;
            }return true;
        }

        public async Task<bool> Update(Role role, Guid id)
        {
            try
            {
                var listObj = await context.Roles.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);
                temp.RoleName = role.RoleName;
                temp.Status = role.Status;
                temp.Description = role.Description;
                context.Remove(temp);
                await Task.FromResult<Role>(context.Roles.Update(temp).Entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //async Task<List<string>> IRoleServices.GetByName(string name)
        //{
        //    var listObj = await context.Roles.ToListAsync();
        //    var temp = listObj.FirstOrDefault(v => v.Equals(name));

        //    if (listObj == null)
        //    {
        //        return null;
        //    }
        //    return new List<string>();
        //}
    }
}
