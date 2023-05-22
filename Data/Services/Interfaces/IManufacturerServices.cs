using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IManufacturerServices
    {
        Task<bool> CreateManufacturer(Manufacturer p);
        Task<bool> UpdateManufacturer(Manufacturer p, Guid Id);
        Task<bool> DeleteManufacturer(Guid id);
        Task<List<Manufacturer>> GetAllManufacturers();
        Task<Manufacturer> GetManufacturerById(Guid id);
        Task<bool> GetManufacturerByName(string name);
    }
}
