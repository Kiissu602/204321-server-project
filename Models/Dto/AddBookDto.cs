using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Models.Dto
{
    public class AddBookDto
    {
        public IFormFile ImgBook { get; set; }
        public string BookName { get; set; }
        public string BookID { get; set; }
        public string Writer { get; set; }
        public string Publisher { get; set; }
        public DateTime YearPublic { get; set; }
        public int NumPage { get; set; }
        public int Price { get; set; }
        public int PrintEdit { get; set; }
        public string Type { get; set; }

    }
}
