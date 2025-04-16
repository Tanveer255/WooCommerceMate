using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WooCommerceMate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderWebhookController : ControllerBase
{
    private const string SecretKey = "MY_SECRET_KEY";

    [HttpPost]
    public async Task<IActionResult> ReceiveOrder([FromBody] object payload)
    {
        var receivedSecret = HttpContext.Request.Query["secret"].ToString();
        if (receivedSecret != SecretKey)
        {
            return Unauthorized("Invalid secret");
        }

        // Process the payload
        return Ok();
    }
}
