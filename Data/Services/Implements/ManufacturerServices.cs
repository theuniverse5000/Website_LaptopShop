using Data.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Implements
{
    internal class ManufacturerServices : IManufacturerServices
    {
        ApplicationDbContext _context;
        public ManufacturerServices()
        {
            _context= new ApplicationDbContext();
        }
        public bool CreateManufacturer(Manufacturer p)
        {
            try
            {
                _context.Manufacturers.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteManufacturer(Guid id)
        {
            try
            {
                dynamic manufacturer = _context.Manufacturers.Find(id);
                _context.Manufacturers.Remove(manufacturer);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Manufacturer> GetAllManufacturers()
        {
            return _context.Manufacturers.ToList();
        }

        public Manufacturer GetManufacturerById(Guid id)
        {
            return _context.Manufacturers.FirstOrDefault(p => p.Id == id);
        }

        public List<Manufacturer> GetManufacturerByName(string name)
        {
            return _context.Manufacturers.Where(p => p.Equals(name)).ToList();
        }

        public bool UpdateManufacturer(Manufacturer p)
        {
            try
            {
                var manufacturer = _context.Manufacturers.Find(p.Id);
                manufacturer.Name = p.Name;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
