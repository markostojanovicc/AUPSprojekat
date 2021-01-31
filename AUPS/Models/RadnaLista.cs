using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Models
{
    public class RadnaLista
    {

        public RadnaLista()
        {

        }

        public int IDRadnaLista { get; set; }
        public DateTime Datum { get; set; }
        public int Kolicina { get; set; }
        public RadnikProizvodnja Radnik { get; set; }
        public RadniNalog RadniNalog { get; set; }
        public Operacija Operacija { get; set; }

    }
}
