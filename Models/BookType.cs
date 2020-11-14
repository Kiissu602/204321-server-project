using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class BookType
    {
        [Key]
        [Column(TypeName = "char(10)")]
        public string TypeID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(70)")]
        public string TypeBook { get; set;}
        public ICollection<Book> Booklist { get; set; }

    }
}
