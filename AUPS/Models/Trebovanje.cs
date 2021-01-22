using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Models
{
    public class Trebovanje
    {
        public Trebovanje()
        {

        }

        public int IDTrebovanje { get; set; }
        public string TipTrebovanja { get; set; }
        public string JedMere { get; set; }
        public  int KolicinaRobe { get; set; }
        public int IDRadniNalog { get; set; }
        

    }
}
