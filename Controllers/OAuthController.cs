using Microsoft.AspNetCore.Mvc;
using SallaIntegration.Interfaces;

namespace SallaIntegration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OAuthController : ControllerBase
    {
        private readonly SallaOAuthService _oauthService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<OAuthController> _logger;
        private readonly IAccessTokenRepository _accessTokenRepository;


        public OAuthController(SallaOAuthService oauthService, IConfiguration configuration, ILogger<OAuthController> logger, IAccessTokenRepository accessTokenRepository)
        {
            _oauthService = oauthService;
            _configuration = configuration;
            _logger = logger;
            _accessTokenRepository = accessTokenRepository;

        }
        [HttpGet("authorize")]
        public async Task<IActionResult> Authorize()
        {
            _logger.LogInformation("Authorize endpoint called.");

             try
              {
                /*  // Get the latest access token
                  var latestToken = await _accessTokenRepository.GetLatestAccessTokenAsync();

                  if (latestToken != null)
                  {
                      var tokenExpirationTime = latestToken.CreatedAt.AddSeconds(latestToken.ExpiresIn);
                      if (DateTime.UtcNow < tokenExpirationTime)
                      {
                          _logger.LogInformation("Valid access token found. Using it directly.");
                          return Ok(new { AccessToken = latestToken.AccessTokenValue });
                      }
                  }*/

                  // If no valid token is found, redirect to authorization URL
                  var authorizationUrl = _oauthService.GetAuthorizationUrl();
                  _logger.LogInformation($"Redirecting to {authorizationUrl}");

                  return Redirect(authorizationUrl);
              }
              catch (Exception ex)
              {
                  _logger.LogError($"Error during authorization: {ex.Message}");
                  return BadRequest("Error during authorization.");
              }
          
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback(string code, string state)
        {
            _logger.LogInformation($"Callback endpoint called with code: {code} and state: {state}");
            try
            {
                var tokenResponse = await _oauthService.ExchangeCodeForToken(code);
                _logger.LogInformation($"Access token obtained: {tokenResponse.AccessToken}");
                _logger.LogInformation($"Refresh token obtained: {tokenResponse.RefreshToken}");
                _logger.LogInformation($"token expired in : {tokenResponse.ExpiresIn}");


                return Ok(new { AccessToken = tokenResponse.AccessToken });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during callback processing: {ex.Message}");
                return BadRequest("Error exchanging code for token.");
            }
        }
    }
}
