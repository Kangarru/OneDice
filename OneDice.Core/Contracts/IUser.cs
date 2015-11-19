using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core.Contracts
{
    public interface IUser
    {
        string UserName { get; set; }
        string EMail { get; set; }
        string ImageUrl { get; set; }
        bool EmailVerified { get; set; }
    }
}
