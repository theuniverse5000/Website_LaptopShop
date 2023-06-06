using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class ProductView
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid IDManufacturer { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public string? NameManufacturer { get; set; }
    }
}
