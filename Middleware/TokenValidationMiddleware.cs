using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SallaIntegration.Interfaces;
using SallaIntegration.Repository.Models;
using SallaIntegration.Services;
using System;
using System.Threading.Tasks;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public TokenValidationMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            var oauthService = serviceProvider.GetRequiredService<SallaOAuthService>();
            var accessTokenRepository = serviceProvider.GetRequiredService<IAccessTokenRepository>();

            var latestToken = await accessTokenRepository.GetLatestAccessTokenAsync();
            if (latestToken != null)
            {
                var tokenExpirationTime = latestToken.CreatedAt.AddSeconds(latestToken.ExpiresIn);
                if (DateTime.UtcNow >= tokenExpirationTime)
                {
                    var refreshedTokenResponse = await oauthService.RefreshAccessToken(latestToken.RefreshToken);
                    await accessTokenRepository.AddAccessTokenAsync(new AccessToken
                    {
                        AccessTokenValue = refreshedTokenResponse.AccessToken,
                        RefreshToken = refreshedTokenResponse.RefreshToken,
                        ExpiresIn = refreshedTokenResponse.ExpiresIn,
                        CreatedAt = DateTime.UtcNow
                    });
                    context.Items["AccessToken"] = refreshedTokenResponse.AccessToken;
                }
                else
                {
                    context.Items["AccessToken"] = latestToken.AccessTokenValue;
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
        }

        await _next(context);
    }
}
