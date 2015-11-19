using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Core
{
    public class Organisation: Entity
    {
        public string ContactPerson { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        /// <summary>
        /// concatenated string using tag input
        /// </summary>
        public string EmailAddresses { get; set; }
        /// <summary>
        /// concatenated string using tag input
        /// </summary>
        public string PhoneNumbers { get; set; }
        /// <summary>
        /// www.facebook.com/
        /// </summary>
        public string FacebookPageLink { get; set; }
        /// <summary>
        /// @
        /// </summary>
        public string TwitterAccount { get; set; }
        public string WebSite { get; set; }
    }
}
