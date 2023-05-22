using Data.Models;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Implements
{
    public class ManufacturerServices : IManufacturerServices
    {
        private readonly ApplicationDbContext _dbcontext;
        public ManufacturerServices()
        {
            _dbcontext= new ApplicationDbContext();
        }
        public async Task<bool> CreateManufacturer(Manufacturer p)
        {
            try
            {
                if (p == null)
                {
                    return false;
                }
                else
                {
                    await _dbcontext.Manufacturers.AddAsync(p);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteManufacturer(Guid id)
        {
            try
            {
                var mf = await _dbcontext.Manufacturers.FindAsync(id);
                if (mf == null) return false;
                else
                {
                    _dbcontext.Manufacturers.Remove(mf);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
            return await _dbcontext.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer> GetManufacturerById(Guid id)
        {
            return await _dbcontext.Manufacturers.FindAsync(id);
        }

        public async Task<bool> GetManufacturerByName(string name)
        {
            var mf = await _dbcontext.Manufacturers.ToListAsync();
            var mfer = mf.FirstOrDefault(x => x.Name == name);
            if (mfer == null) return false;
            else
            {
                return true;
            }
        }

        public async Task<bool> UpdateManufacturer(Manufacturer p, Guid id)
        {
            try
            {
                if (p == null) return false;
                else
                {
                    var mf = _dbcontext.Manufacturers.Find(p.Id);
                    mf.Name = p.Name;
                    _dbcontext.Manufacturers.Update(mf);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
