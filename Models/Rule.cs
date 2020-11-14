using LibrarySystem.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Rule
    {
        [Key]
        [Column(TypeName = "char(10)")]
        public TypeEnum Type { get; set; }

        public int BookAmount { get; set; }

        public int LimitDay { get; set; }
    }
}
