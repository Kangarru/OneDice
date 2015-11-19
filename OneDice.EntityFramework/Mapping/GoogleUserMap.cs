using OneDice.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.EntityFramework.Mapping
{
    public class GoogleUserMap : EntityMap<GoogleUser>
    {
        public GoogleUserMap()
        {
            Property(x => x.UserName);
            Property(x => x.Password);
            Property(x => x.EmailVerified);
            Property(x => x.EMail);
            Property(x => x.ImageUrl);
            Property(x => x.GoogleID);
        }
    }
}
