using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Security;
using WEBTP.Entities;

namespace WEBTP.Data
{
    public class WEBTPContext : DbContext
    {
        public WEBTPContext() : base("name=WEBTPContext") { }
       

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Book> Books { get; set; }

   



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasMany<Role>(r => r.Roles)
                .WithMany();


            modelBuilder.Entity<User>()
                         .HasMany(c => c.Books);
                        

            modelBuilder.Entity<Book>()
                .HasRequired<User>(b => b.User)
                .WithMany(g => g.Books)
                .HasForeignKey<long>(b => b.IdUser)
                .WillCascadeOnDelete(true);

      


        }


    }
}