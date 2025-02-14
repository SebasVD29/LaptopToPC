using BetisWebAPIPortalApis.Services;
using BtisEntities.EUsers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Text;

namespace BetisWebAPIPortalApis.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly EITokenSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<EITokenSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }


        public async Task Invoke(HttpContext context, IUserService userService)
        {
            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (token != null)
                    attachUserToContext(context, userService, token);

                await _next(context);
            }
            catch (Exception ex)
            {
                // Manejar la excepción (registrar, notificar, etc.)
                Console.Error.WriteLine($"Error en el middleware: {ex.Message}");

                // Puedes cerrar la conexión WebSocket aquí si es apropiado para tu aplicación
                if (context.WebSockets.IsWebSocketRequest)
                {
                    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                    await webSocket.CloseAsync(WebSocketCloseStatus.InternalServerError, "Error en el servidor", CancellationToken.None);
                }
            }
        }


        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.JWT_Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userCorreo = (jwtToken.Claims.First(x => x.Type == "CorreoElectronico")).ToString();

                // attach user to context on successful jwt validation
                context.Items["EIUsers"] = userService.GetUserChecked(userCorreo);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
