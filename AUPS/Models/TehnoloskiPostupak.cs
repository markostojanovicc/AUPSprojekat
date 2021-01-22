using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Models
{
    public class TehnoloskiPostupak
    {
        TehnoloskiPostupak()
        {

        }

        public int IDTehPostupak {get; set; }
        public string TipTehPostupak { get; set; }
        public int VremeIzrade { get; set; }
        public int SerijaKom { get; set; }
        public int BrKomada { get; set; }


    }


}
