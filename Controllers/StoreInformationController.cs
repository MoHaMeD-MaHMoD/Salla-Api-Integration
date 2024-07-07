using Microsoft.AspNetCore.Mvc;

namespace SallaIntegration.Controllers
{
    public class StoreInformationController : Controller
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public StoreInformationController(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
    }
}
