using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace WEBTP.Entities
{
    public class User
    {
        public User()
        {            
            this.Roles = new List<Role>();
            this.Books = new List<Book>();
        }

        public User(long idUser, string firstname, string lastname, string mail, string passWord, Role currentRole, List<Role> roles, List<Book> books)
        {
            IdUser = idUser;
            Firstname = firstname;
            Lastname = lastname;
            Mail = mail;
            PassWord = passWord;
            CurrentRole = currentRole;
            Roles = roles;
            Books = books;
        }

        public User(string firstname, string lastname, string mail, string passWord)
        {
            Firstname = firstname;
            Lastname = lastname;
            Mail = mail;
            PassWord = passWord;
        }

       
        //Attributs

        private long idUser;
       
        private string firstname;
    
        private string lastname;
       
        private string mail;
       
        private string passWord;

        //user-book(one to many): un user peut avoir plusieurs livres mais un livre n'appartient qu'a un user.
        private Book currentBook;
        private List<Book> books = new List<Book>();

        //user - role (many to many avec navigation unidirectionnelle definie sur user), gestion de la relation dans les deux direction uniquement avec user.        
        private Role currentRole;
        private List<Role> roles = new List<Role>();

        //ou  user-role en one to many: pour un user, il lui est attribué un seul rôle mais un role peut étre attribué à plusieurs users? 
        //( à partir du moment ou il est vendreur on considére qu'il peut aussi acheter)

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdUser { get => idUser; set => idUser = value; }
        [DisplayName("Prénom")]
        public string Firstname { get => firstname; set => firstname = value; }
        [Required]
        public string Lastname { get => lastname; set => lastname = value; }
        [Required]
        public string Mail { get => mail; set => mail = value; }
        [Required]
        public string PassWord { get => passWord; set => passWord = value; }

        public virtual Role CurrentRole { get => this.currentRole; set => this.currentRole = value; }
        public virtual List<Role> Roles { get => roles; set => roles = value; }
        public Book CurrentBook { get => this.currentBook; set => this.currentBook = value; }
        public virtual List<Book> Books { get => books; set => books = value; }
        

        public override string ToString()

        {
            return JsonConvert.SerializeObject(this);
        }
    }

}