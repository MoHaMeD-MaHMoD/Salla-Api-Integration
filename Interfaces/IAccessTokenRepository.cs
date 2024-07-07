using SallaIntegration.Repository.Models;

namespace SallaIntegration.Interfaces
{
    public interface IAccessTokenRepository
    {
        Task AddAccessTokenAsync(AccessToken accessToken);
        Task <AccessToken> GetLatestAccessTokenAsync();

    }
}
