using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBTP.Entities
{
    public class UserRole
    {

        private long idUser;
        private long idRole;

        public UserRole() {   }
        public UserRole(long idUser, long idRole)
        {
            this.idUser = idUser;
            this.idRole = idRole;
        }

        public long User_IdUser { get => idUser; set => idUser = value; }
        public long Role_IdRole { get => idRole; set => idRole = value; }
    }
}