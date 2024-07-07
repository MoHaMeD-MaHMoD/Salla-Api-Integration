using Microsoft.AspNetCore.Mvc;

namespace SallaIntegration.Controllers
{
    public class UserInformationController : Controller
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserInformationController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
    }
}
