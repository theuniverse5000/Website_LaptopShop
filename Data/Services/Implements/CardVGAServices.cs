using Data.Models;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Implements
{
    internal class CardVGAServices : ICardVGAServices
    {
        ApplicationDbContext _context;
        public bool CreateCardVGA(CardVGA p)
        {
            try
            {
                _context.CardVGAs.Add(p);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCardVGA(Guid id)
        {
            try
            {
                dynamic cardVGA = _context.CardVGAs.Find(id);
                _context.CardVGAs.Remove(cardVGA);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CardVGA> GetAllCardVGAs()
        {
            return _context.CardVGAs.ToList();
        }

        public CardVGA GetCardVGAById(Guid id)
        {
            return _context.CardVGAs.FirstOrDefault(p => p.Id == id);
        }

        public List<CardVGA> GetCardVGAByName(string name)
        {
            return _context.CardVGAs.Where(p => p.Equals(name)).ToList();
        }

        public bool UpdateCardVGA(CardVGA p)
        {
            try
            {
                var cardVGA = _context.CardVGAs.Find(p.Id);
                cardVGA.Ten = p.Ten;
                cardVGA.Ma= p.Ma;
                cardVGA.ThongSo = p.ThongSo;
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
