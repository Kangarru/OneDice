using OneDice.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core
{
    public class User : Entity, IUser
    {
        public string UserName { get; set; }

        [StringLength(50)]
        [Index(IsUnique = true)]
        public string EMail { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public bool EmailVerified { get; set; }
    }
}
