using LibrarySystem.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Borrow
    {
        [Key]
        public int BorrowId { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }

        [Column(TypeName = "char(10)")]
        public TypeEnum Status { get; set; }

        [Required]
        public int Fines { get; set; }

    }
}
