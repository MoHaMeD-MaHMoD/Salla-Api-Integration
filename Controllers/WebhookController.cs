using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SallaIntegration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        private readonly ILogger<WebhookController> _logger;

        public WebhookController(ILogger<WebhookController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult ReceiveWebhook([FromBody] dynamic payload)
        {
            _logger.LogInformation($"Webhook received with payload: {payload}");

            // Process the webhook payload as needed

            return Ok();
        }
    }
}
