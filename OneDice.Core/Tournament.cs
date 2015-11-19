using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core
{
    public class Tournament : Entity
    {
        //multi games -> teams -> users(upload random or fixed, enroll page first come first serve (option for invite) -> site multimedia and socials 
        public string FaceBookPageUrl { get; set; }
        public string TwitterAccount { get; set; }
        public TournamentStatus MyProperty { get; set; }
        public List<Game> Games { get; set; }
        public string SiteName { get; set; }
        public string UserId { get; set; }
    }
}
