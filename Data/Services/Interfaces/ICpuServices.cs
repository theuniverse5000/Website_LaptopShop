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
        Task<bool> CreateCpu(Cpu c);
        Task<bool> UpdateCpu(Cpu c, Guid id);
        Task<bool> DeleteCpu(Guid id);
        Task<List<Cpu>> GetAllCpus();
        Task<Cpu> GetCpuById(Guid id);
        Task<bool> GetCpuByMa(string ma);
    }
}
