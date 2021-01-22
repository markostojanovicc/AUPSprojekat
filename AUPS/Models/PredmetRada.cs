using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Models
{
    public class PredmetRada
    {
        public PredmetRada()
        {

        }

        public int IDPredmetRada { get; set; }
        public string TipPredmetRada { get; set; }
        public string NazivPR { get; set; }
        public string JedMerePR { get; set; }
        public int Cena { get; set; }


    }
}
