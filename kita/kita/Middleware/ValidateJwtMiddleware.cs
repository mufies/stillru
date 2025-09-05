using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace kita.Middleware
{
    public sealed class ValidateJwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string? _issuer;
        private readonly string? _audience;
        private readonly string? _secret;

        public ValidateJwtMiddleware(RequestDelegate next, IConfiguration cfg)
        {
            _next     = next;
            _issuer   = cfg["Jwt:Issuer"];
            _audience = cfg["Jwt:Audience"];
            _secret   = cfg["Jwt:Secret"];
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string? auth = context.Request.Headers["Authorization"];

            if (auth is not null && auth.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                string token = auth["Bearer ".Length..].Trim();

                if (!TryValidate(token, out ClaimsPrincipal? user))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Invalid or expired token");
                    return;
                }

                context.User = user;           
            }

            await _next(context);
        }

        private bool TryValidate(string jwt, out ClaimsPrincipal? principal)
        {
            principal = null;
            if (string.IsNullOrEmpty(_secret))
            {
                return false;
            }
            var handler = new JwtSecurityTokenHandler();
            var key     = Encoding.UTF8.GetBytes(_secret);

            var param = new TokenValidationParameters
            {
                ValidIssuer           = _issuer,
                ValidAudience         = _audience,
                IssuerSigningKey      = new SymmetricSecurityKey(key),
                ValidateIssuer        = true,
                ValidateAudience      = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime      = true,
                ClockSkew             = TimeSpan.Zero          
            };

            try
            {
                principal = handler.ValidateToken(jwt, param, out _);
                return true;
            }
            catch
            {
                return false; 
            }
        }
    }
}
