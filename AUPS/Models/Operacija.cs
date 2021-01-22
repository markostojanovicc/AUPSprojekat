using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Models
{
    public class Operacija
    {

        public Operacija()
        {

        }

        public int IDOperacija { get; set; } 
        public string NazivOperacije { get; set; }
        public int OsnovnoVreme { get; set; }
        public int PomocnoVreme { get; set; }
        public int DodatnoVreme { get; set; }
        public string OznakaMasine { get; set; }



    }
}
