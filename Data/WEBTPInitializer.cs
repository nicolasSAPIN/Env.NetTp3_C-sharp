using System.Collections.Generic;
using WEBTP.Data;
using WEBTP.Entities;

namespace WEBTP.Data
{
    public class WEBTPContextInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WEBTPContext>
    {

        protected override void Seed(WEBTPContext context)
        {
            var Roles = new List<Role>
            {
                new Role{ Name="Simple User"},
                new Role{ Name="Seller"},
                new Role{ Name="Buyer"},

            };

            Roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var Users = new List<User>
            {
                new User{ Firstname="Nicolas",Lastname = "Sapin", Mail = "nicosapin@gmail.com", PassWord = "aaa"},
                new User{ Firstname="Anthoine",Lastname = "Cronier", Mail = "acronier@test.fr", PassWord = "aaa"},
                new User{ Firstname="pere",Lastname = "Noel", Mail = "perenoel@test.fr", PassWord = "aaa"},
                new User{ Firstname="mere",Lastname = "Noel", Mail = "merenoel@test.fr", PassWord = "aaa"},
                new User{ Firstname="François",Lastname = "Mitterand", Mail = "fmitterand@test.fr", PassWord = "aaa"},
                new User{ Firstname="test",Lastname = "simpleutilisateur", Mail = "tsimpleutilisateur@test.fr", PassWord = "aaa"},
                new User{ Firstname="test",Lastname = "Seller", Mail = "tseller@test.fr", PassWord = "aaa"},
                new User{ Firstname="test",Lastname = "Buyer", Mail = "tbuyer@test.fr", PassWord = "aaa"},

            };

            Users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();




        }
    }
}