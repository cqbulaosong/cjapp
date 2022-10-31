using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CjApp.IService;
using CjApp.Jwt.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CjApp.Jwt.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly ISystemUserService _iSystemUserService;

        private readonly IConfiguration _configuration;

        public AuthorizeController(ISystemUserService iSystemUserService, IConfiguration configuration)
        {
            _iSystemUserService = iSystemUserService;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<ApiResult> Login(string loginName, string password)
        {
            var md5Pwd = Md5Helper.Md5Encrypt32(password);
            //数据校验
            var user = await _iSystemUserService.FindAsync(c =>
                (c.Phone == loginName) && c.Password == md5Pwd);

            if (user == null) return ApiResultHelper.Error("账号或密码错误");
            var claims = new Claim[]
            {
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.NameIdentifier, user.SystemUserId),
                new("Phone", user.Phone),
                new("Email", user.Email)
            };
            
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetConnectionString("IssuerSigningKey")));
            var token = new JwtSecurityToken(
                issuer: _configuration.GetConnectionString("Issuer"),
                audience: _configuration.GetConnectionString("Audience"),
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
            var writeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return ApiResultHelper.Success(writeToken);
        }
    }
}