using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface ICardVGAServices
    {
        Task<bool> CreateCardVGA(CardVGA p);
        Task<bool> UpdateCardVGA(CardVGA p, Guid id);
        Task<bool> DeleteCardVGA(Guid id);
        Task<List<CardVGA>> GetAllCardVGAs();
        Task<CardVGA> GetCardVGAById(Guid id);
        Task<bool> GetCardVGAByMa(string ma);
    }
}
