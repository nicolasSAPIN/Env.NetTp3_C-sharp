using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBTP.Entities
{
    [Table("Role")]
    public class Role
    {
        //Attributs
        private long idRole;
        private string name;
        private List<User> users = new List<User>();

        //constructeurs
        public Role()
        {
        }
        public Role(string name)
        {
            Name = name;
        }
        public Role(long idRole, string name)
        {
            IdRole = idRole;
            Name = name;
        }

        //public Role(string name, List<User> users)
        //{
        //    Name = name;
        //    //Users = users;
        //}

        //Accesseurs
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdRole { get => idRole; set => idRole = value; }
        [Required]
        public string Name { get => name; set => name = value; }

        //J'ai un probleme sur le fait de mettre ou non une List<User>
        // Enb theorie ça serait obligatoire mais en pratique 
        //d'ou le notMapped
        [NotMapped]
        public List<User> Users { get => users; set => users = value; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}