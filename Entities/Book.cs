using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WEBTP.Entities;

namespace WEBTP.Entities
{
    public class Book
    {
        //Attributs
        private long idBook;
        private string title;
        private int nbPages;
        private float price;

        private long idUser;
        private User user;
        
        //constructeurs
        public Book() {

         
        }

        public Book(string title, int nbPages, float price, long idUser)
        {
            Title = title;
            NbPages = nbPages;
            Price = price;
            IdUser = idUser;  
        }

        public Book(long idBook, string title, int nbPages, float price, long idUser)
        {
            IdBook = idBook;
            Title = title;
            NbPages = nbPages;
            Price = price;
            IdUser = idUser;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdBook { get => this.idBook; set => this.idBook = value; }
        [Required]
        public string Title { get => this.title; set => this.title = value; }
        [Required]
        public int NbPages { get => this.nbPages; set => this.nbPages = value; }
        [Required]
        public float Price { get => this.price; set => this.price = value; }
       
        public long IdUser { get => this.idUser; set => this.idUser = value; }

        public virtual User User { get => this.user; set => this.user = value; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}