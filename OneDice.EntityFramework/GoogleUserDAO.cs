using OneDice.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.EntityFramework
{
    public class GoogleUserDAO : EntityDAO<GoogleUser>
    {
        public GoogleUserDAO()
            : base()
        {

        }
        public GoogleUser GetByGoogleID(string googleId)
        {
            return Table.Where(x => x.GoogleID == googleId).FirstOrDefault();
        }
    }
}
