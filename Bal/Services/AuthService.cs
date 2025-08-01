using AutoMapper;
using RMS.Authentication.Model;
using RMS.Bal.Services.Interfaces;
using RMS.Dal;
using RMS.Models;
using System.Security.Claims;
using System.Text.Json;

namespace RMS.Bal.Services
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private UserModel _user = new UserModel();
        private readonly RmsDbContext _rmsDbContext;


        public AuthService(IHttpContextAccessor httpContextAccessor, IMapper mapper, RmsDbContext rmsDbContext)
        {
            _mapper = mapper;
            _rmsDbContext = rmsDbContext;

            if (httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated == true)
            {
                var claims = httpContextAccessor.HttpContext.User.Claims;

                _user.UserId = long.TryParse(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value, out long userId) ? userId : 0;
                _user.UserName = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                _user.Role = claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                _user.Level = claims.FirstOrDefault(c => c.Type == "level")?.Value;
                _user.Scope = claims.FirstOrDefault(c => c.Type == "scope")?.Value;

                var permissionsClaims = claims
                    .Where(c => c.Type == "permissions")
                    .SelectMany(c =>
                        JsonSerializer.Deserialize<List<string>>(c.Value) ?? new List<string>()
                    )
                    .ToList();

                if (permissionsClaims.Any())
                {
                    _user.Permissions = permissionsClaims;
                }

            }

        }

        public UserModel User
        {
            get
            {
                return _user;
            }
        }
    }
}
