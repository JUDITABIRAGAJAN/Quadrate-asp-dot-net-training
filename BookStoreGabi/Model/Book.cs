using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreGabi.Model
{
    public class Book
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string Name { set; get;}
        public string Author { set; get; }
        public int NoofCopy { set; get;}
        public string Edition { set; get; }
        public string ISBN { get; set; }
    }
}
