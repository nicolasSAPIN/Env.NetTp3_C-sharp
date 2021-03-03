using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using WEBTP.Entities;

namespace WEBTP.Models
{
    public class BookModel
    {
        public Book Book { get; set; }
        [DisplayName("User")]
        public long IdUser { get; set; }
        public virtual User User { get; set; }
    }
}