using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Faculty
    {
        [Key]
        public int Fnum { get; set; }

        public string Fname { get; set; }

        public ICollection<Department> Departmentlist { get; set; }
    }
}
