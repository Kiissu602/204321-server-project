using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book
    {
        [Key]
        [Column(TypeName = "char(10)")]
        public string BookID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(70)")]
        public string BookName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(70)")]
        public string Writer { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Publisher { get; set; }
        public DateTime YearPublic { get; set; }
        [Required]
        public int NumPage { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int PrintEdit { get; set; }
        public BookType BookType { get; set; }
        [Required]
        public string BookImg { get; set; }
     
    }
}
