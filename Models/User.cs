using LibrarySystem.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class User
    {   
        [Key]
        [Column(TypeName = "char(10)")]
        public string PID { get; set; }

        [Required]
        public string Fname { get; set; }
        public string Lname { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        public Faculty Faculty { get; set; }

        public Department Department { get; set; }

        [Required]
        public DateTime Bdate { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        [Column(TypeName = "char(10)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "varchar(16)")]
        public string Username { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "varchar(896)")]
        public string Email { get; set; }

        [Required]
        public string ImgUrl { get; set; }
    }
    public class UserReturnDto
    {
        public string PID { get; set; }
        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Username { get; set; }

        public DateTime Bdate { get; set; }

        public Faculty Faculty { get; set; }

        public Department Department { get; set; }

        public string Sex { get; set; }

        public TypeEnum Type { get; set; }

        public string Token { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ImgUrl { get; set; }
    }


}
