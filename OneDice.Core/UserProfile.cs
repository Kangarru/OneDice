using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core
{
    public class UserProfile : Entity
    {
        public int UserID { get; set; }
        public string TownOrCity { get; set; }
        public string InterestedTournaments { get; set; }
    }
}
