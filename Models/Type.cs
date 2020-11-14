using LibrarySystem.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Type
    {
        [Key]
        public int TypeID { get; set; }

        
        [Column(TypeName = "char(10)")]
        public TypeEnum TypeName { get; set; }
    }
}
