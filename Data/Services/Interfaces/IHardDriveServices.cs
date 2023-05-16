using System;
using Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IHardDriveServices
    {
        Task<List<HardDrive>> GetAllHardDrive();
        Task<bool> Update(HardDrive harddrive, Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Add(HardDrive harddrive);
        Task<HardDrive> GetById(Guid id);
        Task<List<string>> GetByName(string name);
    }
}
