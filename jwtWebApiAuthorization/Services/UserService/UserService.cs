using System.Security.Claims;

namespace jwtWebApiAuthorization.Services.UserService
{
    public class UserService : IUserService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public object GetMyName()
        {
            //var userName = User?.Identity?.Name;
            //var userName2 = User.FindFirstValue(ClaimTypes.Name);
            //var role = User.FindFirstValue(ClaimTypes.Role);

            //return Ok(new { userName,userName2,role});


            var userName = string.Empty;
            var role = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {
                userName = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
                role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);

            }

            return new { userName, role };
        }
    }
}
