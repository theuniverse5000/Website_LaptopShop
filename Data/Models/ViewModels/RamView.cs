using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.ViewModels
{
    public class RamView
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string ThongSo { get; set; }
        public int SoKheCam { get; set; }
        public string MoTa { get; set; }
    }
}
