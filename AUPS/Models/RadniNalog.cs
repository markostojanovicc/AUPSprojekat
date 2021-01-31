using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Models
{
    public class RadniNalog
    {

        public RadniNalog()
        {

        }

        public int IDRadniNalog { get; set; }
        public DateTime DatumUlaz { get; set; }
        public DateTime DatumIzlaz { get; set; }
        public int KolicinaProizvoda { get; set; }
        public PredmetRada PredmetRada { get; set; }

    }
}
