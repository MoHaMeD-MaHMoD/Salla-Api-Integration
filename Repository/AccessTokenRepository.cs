using Microsoft.EntityFrameworkCore;
using SallaIntegration.Interfaces;
using SallaIntegration.Repository.Models;

namespace SallaIntegration.Repository
{
    public class AccessTokenRepository : IAccessTokenRepository
    {
        private readonly TokenDbContext _dbContext;

        public AccessTokenRepository(TokenDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAccessTokenAsync(AccessToken accessToken)
        {
            _dbContext.AccessTokens.Add(accessToken);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AccessToken> GetLatestAccessTokenAsync()
        {
            return await _dbContext.AccessTokens
                .OrderByDescending(a => a.CreatedAt)
                .FirstOrDefaultAsync();
        }


    }
}
