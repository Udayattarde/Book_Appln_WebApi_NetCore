using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Models
{
    public class BookModel
    {
        public int id { get; set; }
        
        [Required]
        public string name { get; set; }
        public string description { get; set; }
    }
}
