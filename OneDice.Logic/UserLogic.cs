using OneDice.Core.Contracts;
using OneDice.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneDice.Logic
{
    public class UserLogic
    {
        public static IUser VerifyUser(string userId)
        {
            if(userId.StartsWith("google-"))
            {
                return new GoogleUserDAO().GetByGoogleID(userId);
            }
            else
            {
                return new UserDAO().GetById(Convert.ToInt32(userId));
            }
        }

        public static bool VerifyLoginDetails(string email, string encryptedPassword)
        {
            if(new UserDAO().Table.Any(x => x.EMail == email && x.Password == encryptedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsRegisteredGoogleUser(string concatGoogleId)//"google-" + google id
        {
            if(new GoogleUserDAO().Table.Any(x => x.GoogleID == concatGoogleId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
