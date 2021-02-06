using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUPS.Models
{
    class TehnPostupakOperacija
    {
        public TehnPostupakOperacija()
        {

        }

        public int IDTehnPostupakOperacija { get; set; }

        public int IDTehPostupak { get; set; }

        public int IDOperacija { get; set; }

        public int RbrOperacije { get; set; }
    }
}
