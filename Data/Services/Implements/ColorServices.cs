using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Data.Services.Implements
{
    public class ColorServices:IColorServices
    {
        private readonly ApplicationDbContext context;
        public ColorServices()
        {
            context = new ApplicationDbContext();
        }

        public async Task<bool> Add(Color Color)
        {

            try
            {
                Color.Id = Guid.NewGuid();
                await context.AddAsync(Color);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CheckMa(string ma)
        {
            var temp= await context.Colors.ToListAsync();  var list=temp.FirstOrDefault(v=>v.Ma==ma);
            if (list==null) { 
                return false;
            }return true;
            
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var listObj = await context.Colors.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                context.Attach(temp);
                await Task.FromResult<Color>(context.Colors.Remove(temp).Entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Color>> GetAllColor()
        {
            var listObj = await context.Colors.ToListAsync();
            if (listObj == null)
            {
                return new();
            }
            return listObj;
        }

        public async Task<Color> GetById(Guid id)
        {
            return await context.Colors.FirstOrDefaultAsync(v => v.Id == id);
        }



        public async Task<bool> Update(Color Color, Guid id)
        {
            try
            {
                var listObj = await context.Colors.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                temp.Name = Color.Name;

                context.Attach(temp);
                await Task.FromResult<Color>(context.Colors.Update(temp).Entity);
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
