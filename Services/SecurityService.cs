using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Services
{
    
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();

        public bool IsValid(UserModel user)
        {
            //knownUsers.Any(x => x.UserName == user.UserName && x.Password == user.Password)
            return securityDAO.FindUserByNameAndPassword(user);
        }

    }
}
