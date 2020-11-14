using LibrarySystem.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models.Dto
{
    public class AddUserDto
    {
        public IFormFile Image { get; set; }
        public string PID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int Type { get; set; }
        public int Fac { get; set; }
        public int Dep { get; set; }
        public DateTime Bdate { get; set; }
        public string Sex { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
