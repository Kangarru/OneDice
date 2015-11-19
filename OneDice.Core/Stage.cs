using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core
{
    public class Stage
    {
        public long ID { get; set; }
        public CompetitionType CompetitionType { get; set; }
        public int Ingress { get; set; }
        public int Egress { get; set; }
    }
}
