using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WEBTP.Entities;

namespace WEBTP.Models
{
    public class UserModel
    {
        public User User { get; set; }
        public long? CurrentRoleId { get; set; }
        public List<long> RolesIds { get; set; }
        public List<Role> Roles { get; set; }

        public long? CurrentBookId { get; set; }

        public List<long> BookIds { get; set; }

        public List<Book> Books { get; set; }

    }
}