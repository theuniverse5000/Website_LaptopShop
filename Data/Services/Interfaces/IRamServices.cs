using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IRamServices
    {
        public bool CreateRam(Ram r);
        public bool UpdateRam(Ram r, Guid id);
        public bool DeleteRam(Guid id);
        public List<Ram> GetAllRams();
        public Ram GetRamById(Guid id);
        public List<string> GetRamByMa(string ma);
    }
}
