using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Final_Project.WebApi.Middelwares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthenticationMid
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthenticationMid> _logger;
        private readonly String _apiKey;

        public AuthenticationMid(RequestDelegate next, IConfiguration config, ILogger<AuthenticationMid> logger)
        {
            _next = next;
            _logger = logger;
            _apiKey = config.GetValue<string>("ApiSettings:ApiKey") ?? string.Empty;
        }            

        public async Task InvokeAsync(HttpContext context)
        {
            if (string.IsNullOrEmpty(_apiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("API key not configured.");
                return;
            }

            if (!context.Request.Headers.TryGetValue("X-Api-Key", out var extractedApiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("API Key was not provided.");
                return;
            }

            if (!string.Equals(extractedApiKey, _apiKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized client.");
                return;
            }

            // המשך הצנרת
            await _next(context);
        }
    }

    //public  verifyToken

           

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMid>();
        }

        public static IApplicationBuilder UseApiKeyAuth(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthenticationMid>();
        }
        
    }

   
}

