using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface ICpuServices
    {
        public bool CreateCpu(Cpu c);
        public bool UpdateCpu(Cpu c, Guid id);
        public bool DeleteCpu(Guid id);
        public List<Cpu> GetAllCpus();
        public Cpu GetCpuById(Guid id);
        public List<string> GetCpuByMa(string ma);
    }
}
