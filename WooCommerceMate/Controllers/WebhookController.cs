using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WooCommerceMate.Controllers.InstallController;
using WooCommerceMate.Service;

namespace WooCommerceMate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WebhookController : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterWebhook([FromBody] WooStoreCredentials creds)
    {
        var service = new WooCommerceService(creds.StoreUrl, creds.ConsumerKey, creds.ConsumerSecret);

        var response = await service.RegisterWebhookAsync(
            topic: "order.created",
            deliveryUrl: "https://yourapp.com/api/webhook/order"
        );

        return Ok(response);
    }
}
