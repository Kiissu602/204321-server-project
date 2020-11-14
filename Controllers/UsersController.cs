using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibrarySystem.Models;
using LibrarySystem.Models.Dto;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using LibrarySystem.Setting;
using LibrarySystem.Services;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly ImageService _imageService;
        private readonly IUserSettings _userSettings;


        public UsersController(DatabaseContext context, IUserSettings userSettings,ImageService imageService)
        {
            _userSettings = userSettings;
            _context = context;
            _imageService = imageService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromForm] AddUserDto user)
        {
            var dep = new Department() { Dnum = user.Dep };
            _context.Attach(dep);

            var fac = new Faculty() { Fnum = user.Fac };
            _context.Attach(fac);

            var type = new Models.Type() { TypeID = user.Type };
            _context.Attach(type);

            string Img = _imageService.SaveImg(user.Image);
            var newUser = new User()
            {
                PID = user.PID,
                Fname = user.Fname,
                Lname = user.Lname,
                Type = type,
                Faculty = fac,
                Department = dep,
                Bdate = user.Bdate,
                Sex = user.Sex,
                Phone = user.Phone,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                ImgUrl = Img,
            };
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.PID }, newUser);
        }

        [HttpPost("login")]
        public ActionResult<UserReturnDto> Authenticate(LoginDto login)
        {
            User user = _context.User.Include(u => u.Faculty).Include(u => u.Department).Include(u => u.Type).FirstOrDefault(user => user.Username == login.Username && user.Password == login.Password);

            // return null if user not found
            if (user == null)
            {
                return NotFound();
            }

            // authentication successful so generate jwt token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_userSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.PID),
                    new Claim("Type", user.Type.TypeName.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            UserReturnDto userReturn = new UserReturnDto()
            {
                PID = user.PID,
                Fname = user.Fname,
                Lname = user.Lname,
                Bdate = user.Bdate,
                Username = user.Username,
                Faculty = user.Faculty,
                Department = user.Department,
                Sex = user.Sex,
                Type = user.Type.TypeName,
                Phone = user.Phone,
                Email = user.Email,
                ImgUrl = user.ImgUrl,
                Token = tokenHandler.WriteToken(token)
        };
            return userReturn;
        }
        [HttpPut]
        public async Task<ActionResult<User>> PutUser([FromForm] AddUserDto uUser)
        {
            var user = User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
            if (user == null) return Unauthorized();
            var dep = new Department() { Dnum = uUser.Dep };
            _context.Attach(dep);

            var fac = new Faculty() { Fnum = uUser.Fac };
            _context.Attach(fac);

            var type = new Models.Type() { TypeID = uUser.Type };
            _context.Attach(type);

            string Img = _imageService.SaveImg(uUser.Image);
            var newUser = new User()
            {
                PID = uUser.PID,
                Fname = uUser.Fname,
                Lname = uUser.Lname,
                Type = type,
                Faculty = fac,
                Department = dep,
                Bdate = uUser.Bdate,
                Sex = uUser.Sex,
                Phone = uUser.Phone,
                Username = uUser.Username,
                Password = uUser.Password,
                Email = uUser.Email,
                ImgUrl = Img,
            };
            _context.Entry(newUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }


}
