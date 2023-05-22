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
    public class CardVGAServices : ICardVGAServices
    {
        private readonly ApplicationDbContext _dbcontext;
        public CardVGAServices()
        {
            _dbcontext= new ApplicationDbContext();
        }
        public async Task<bool> CreateCardVGA(CardVGA p)
        {
            try
            {
                if (p == null)
                {
                    return false;
                }
                else
                {
                    await _dbcontext.CardVGAs.AddAsync(p);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCardVGA(Guid id)
        {
            try
            {
                var cvga = await _dbcontext.CardVGAs.FindAsync(id);
                if (cvga == null) return false;
                else
                {
                    _dbcontext.CardVGAs.Remove(cvga);
                    await _dbcontext.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<CardVGA>> GetAllCardVGAs()
        {
            return await _dbcontext.CardVGAs.ToListAsync();
        }

        public async Task<CardVGA> GetCardVGAById(Guid id)
        {
            return await _dbcontext.CardVGAs.FindAsync(id);
        }

        public async Task<bool> GetCardVGAByMa(string ma)
        {
            var cvga = await _dbcontext.CardVGAs.ToListAsync();
            var card = cvga.FirstOrDefault(x => x.Ma == ma);
            if (card == null) return false;
            else
            {
                return true;
            }
        }

        public async Task<bool> UpdateCardVGA(CardVGA p, Guid id)
        {
            try
            {
                if (p == null)
                {
                    return false;
                }
                else
                {
                    var cvga = _dbcontext.CardVGAs.Find(p.Id);
                    cvga.Ma= p.Ma;
                    cvga.Ten= p.Ten;
                    cvga.ThongSo= p.ThongSo;
                    _dbcontext.CardVGAs.Update(cvga);
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
