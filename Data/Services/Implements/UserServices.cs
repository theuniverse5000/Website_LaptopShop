using Data.Models;
using Data.Models.ViewModels;
using Data.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Data.Services.Implements
{
    public class UserServices : IUserServices
    {
        ApplicationDbContext _context;
        private readonly IConfiguration _config;
        public UserServices()
        {
            _context = new ApplicationDbContext();

        }

        public async Task<bool> Add(User user)
        {
            try
            {
                user.Id = Guid.NewGuid();

                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var listObj = await _context.Users.ToListAsync();
                var temp = listObj.FirstOrDefault(v => v.Id == id);

                _context.Remove(temp);
                await Task.FromResult<User>(_context.Users.Remove(temp).Entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllUser()
        {
            var listObj = await _context.Users.ToListAsync();
            if (listObj == null)
            {
                return new();
            }
            return listObj;
        }

        public async Task<User> GetById(Guid id)
        {
            var listObj = await _context.Users.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Id == id);

            if (temp == null)
            {
                return new User();
            }
            return temp;
        }

        public async Task<List<string>> GetByName(string name)
        {
            var listObj = await _context.Users.ToListAsync();
            var temp = listObj.FirstOrDefault(v => v.Equals(name));

            if (listObj == null)
            {
                return null;
            }
            return new List<string>();
        }

        public async Task<bool> IsAdministrator(string username, string password)
        {
            List<UserView> thao = new List<UserView>();
            thao = (from a in _context.Users.ToList()
                    join b in _context.Roles.ToList() on a.IdRole equals b.Id
                    select new UserView
                    {
                        Id = a.Id,
                        Username = a.Username,
                        Password = a.Password,
                        Status = a.Status,
                        RoleName = b.RoleName
                    }
                ).ToList();

            var linh = thao.FirstOrDefault(a => a.Username == username && a.Password == password && a.Status == 1 && a.RoleName == "Admin");
            if (linh != null) return true;
            return false;
        }

        public async Task<bool> IsClient(string username, string password)
        {
            var thao = GetAllUser().Result.FirstOrDefault(a => a.Username == username && a.Password == password && a.Status == 1);
            if (thao != null) return true;
            return false;
        }

        public async Task<bool> Update(User u)
        {
            try
            {
                var c = _context.Users.Find(u.Id);
                c.Username = u.Username;
                c.Password = u.Password;
                c.Status = u.Status;
                c.IdRole = u.IdRole;
                _context.Update(c);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GenerateTokenString(string username, string password)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,username),
                new Claim(ClaimTypes.Role,"Admin"),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
        }
    }
}
