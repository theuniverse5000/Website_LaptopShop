using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    internal interface ICardVGAServices
    {
        public bool CreateCardVGA(CardVGA p);
        public bool UpdateCardVGA(CardVGA p);
        public bool DeleteCardVGA(Guid id);
        public List<CardVGA> GetAllCardVGAs();
        public CardVGA GetCardVGAById(Guid id);
        public List<CardVGA> GetCardVGAByName(string name);
    }
}
