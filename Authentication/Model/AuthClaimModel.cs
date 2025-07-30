using System.Security.Claims;

namespace RMS.Authentication.Model
{
    public class AuthClaimModel
    {
        public List<Claim> Claims { get; set; }
        public string RefreshedAccessToken { get; set; }
    }
}
