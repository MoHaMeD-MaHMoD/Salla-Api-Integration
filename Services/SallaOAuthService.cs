using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SallaIntegration.Repository;
using Microsoft.EntityFrameworkCore;
using SallaIntegration.Repository.Models;
using SallaIntegration.Interfaces;
using SallaIntegration.Models.Tokens;

public class SallaOAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IAccessTokenRepository _accessTokenRepository;    // Inject TokenDbContext


    public SallaOAuthService(IConfiguration configuration, IAccessTokenRepository accessTokenRepository)
    {
        _configuration = configuration;
        _accessTokenRepository = accessTokenRepository;

    }

    public string GetAuthorizationUrl()
    {
        var clientId = _configuration["SallaApi:ClientId"];
        var redirectUri = _configuration["SallaApi:RedirectUri"];
        var state = Guid.NewGuid().ToString();
        var authorizationUrl = $"https://accounts.salla.sa/oauth2/auth?client_id={clientId}&response_type=code&redirect_uri={redirectUri}&scope=offline_access&state={state}";
        return authorizationUrl;
    }


    public async Task<TokenResponse> ExchangeCodeForToken(string code)
    {
        var client = new RestClient("https://accounts.salla.sa/oauth2/token");
        var request = new RestRequest(Method.POST);
        request.AddParameter("client_id", _configuration["SallaApi:ClientId"], ParameterType.GetOrPost);
        request.AddParameter("client_secret", _configuration["SallaApi:ClientSecret"], ParameterType.GetOrPost);
        request.AddParameter("code", code, ParameterType.GetOrPost);
        request.AddParameter("grant_type", "authorization_code", ParameterType.GetOrPost);
        request.AddParameter("redirect_uri", _configuration["SallaApi:RedirectUri"], ParameterType.GetOrPost);

        var response = await client.ExecuteAsync(request);

        if (response.IsSuccessful)
        {
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content);

            // Store tokens in database
            await _accessTokenRepository.AddAccessTokenAsync(new AccessToken
            {
                AccessTokenValue = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken,
                ExpiresIn = tokenResponse.ExpiresIn,
                CreatedAt = DateTime.UtcNow
            });

            return tokenResponse;
        }
        else
        {
            throw new Exception($"Error exchanging code for token: {response.ErrorMessage}");
        }
    }


    public async Task<TokenResponse> RefreshAccessToken(string refreshToken)
    {
        var client = new RestClient("https://accounts.salla.sa/oauth2/token");
        var request = new RestRequest(Method.POST);
        request.AddParameter("client_id", _configuration["SallaApi:ClientId"], ParameterType.GetOrPost);
        request.AddParameter("client_secret", _configuration["SallaApi:ClientSecret"], ParameterType.GetOrPost);
        request.AddParameter("refresh_token", refreshToken, ParameterType.GetOrPost);
        request.AddParameter("grant_type", "refresh_token", ParameterType.GetOrPost);

        var response = await client.ExecuteAsync(request);
        if (response.IsSuccessful)
        {
            return JsonConvert.DeserializeObject<TokenResponse>(response.Content);
        }
        else
        {
            throw new Exception($"Error refreshing access token: {response.ErrorMessage}");
        }
    }

    public async Task<string> GetLastAccessToken()
    {
        var latestToken = await _accessTokenRepository.GetLatestAccessTokenAsync();

        if (latestToken != null)
        {
            var tokenExpirationTime = latestToken.CreatedAt.AddSeconds(latestToken.ExpiresIn);
            if (DateTime.UtcNow < tokenExpirationTime)
            {
                return latestToken.AccessTokenValue;
            }
            else
            {
                var newTokenResponse = await RefreshAccessToken(latestToken.RefreshToken);
                return newTokenResponse.AccessToken;
            }
        }
        else
        {
            throw new Exception("No access token found in the database.");
        }
    }

}

