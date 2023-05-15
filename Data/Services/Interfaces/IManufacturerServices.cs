using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    internal interface IManufacturerServices
    {
        public bool CreateManufacturer(Manufacturer p);
        public bool UpdateManufacturer(Manufacturer p);
        public bool DeleteManufacturer(Guid id);
        public List<Manufacturer> GetAllManufacturers();
        public Manufacturer GetManufacturerById(Guid id);
        public List<Manufacturer> GetManufacturerByName(string name);
    }
}
