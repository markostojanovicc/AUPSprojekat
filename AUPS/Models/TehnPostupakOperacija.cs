using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Models
{
    public class TehnPostupakOperacija
    {
        public TehnPostupakOperacija()
        {

        }

        public int IDTehnPostupakOperacija { get; set; }

        public TehnoloskiPostupak TehnoloskiPostupak { get; set; }

        public Operacija Operacija { get; set; }

        public int RBrOperacije { get; set; }
    }
}
