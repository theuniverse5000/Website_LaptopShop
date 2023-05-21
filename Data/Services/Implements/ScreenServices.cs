using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Services.Implements
{
    public class ScreenServices : IScreenServices
    {
        ApplicationDbContext context;
        public ScreenServices()
        {
            context = new ApplicationDbContext();
        }
        public async Task<bool> Add(Screen screen)
        {
            try
            {
                screen.Id = Guid.NewGuid();
                await context.AddAsync(screen);
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
                var listObj = await context.Screens.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                context.Remove(temp);
                await Task.FromResult<Screen>(context.Screens.Remove(temp).Entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Screen>> GetAllScreen()
        {
            var listObj = await context.Screens.ToListAsync();
            if (listObj == null)
            {
                return new();
            }
            return listObj;
        }

        public async Task<Screen> GetById(Guid id)
        {
            //var listObj = await context.Screens.ToListAsync();
            //var temp = listObj.FirstOrDefault(v => v.Id == id);

            //if (temp == null)
            //{
            //    return new Screen();
            //}
            //return temp;
            return context.Screens.FirstOrDefault(v => v.Id == id);
        }

        public async Task<List<string>> GetByName(string name)
        {
            var listObj = await context.Screens.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Equals(name));

            if (listObj == null)
            {
                return null;
            }
            return new List<string>();
        }

        public async Task<bool> Update(Screen screen, Guid id)
        {
            try
            {
                var s = context.Screens.FirstOrDefault(v => v.Id == id);
                s.Ma = screen.Ma;
                s.Ten = screen.Ten;
                s.KichCo = screen.KichCo;
                s.TanSo = screen.TanSo;
                s.ChatLieu = screen.ChatLieu;
                context.Update(s);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
