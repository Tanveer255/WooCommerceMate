using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WooCommerceMate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UninstallController : ControllerBase
{
    [HttpPost]
    public IActionResult UninstallApp([FromBody] string storeUrl)
    {
        // Remove credentials from DB
        return Ok("App uninstalled.");
    }
}
