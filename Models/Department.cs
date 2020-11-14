using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Department
    {
        [Key]
        public int Dnum { get; set; }

        public string Dname { get; set; }

        public Faculty Faculty { get; set; }

        public ICollection<User> Userlist { get; set; }
    }
}
