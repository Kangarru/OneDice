using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core
{
    public class Score
    {
        public long ID { get; set; }
        public ScoringType ScoringType { get; set; }
        public bool Ranged { get; set; }
        public decimal Maximum { get; set; }
        public decimal Minimum { get; set; }
    }
}
