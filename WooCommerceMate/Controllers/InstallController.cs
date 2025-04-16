using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WooCommerceMate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstallController : ControllerBase
{
    [HttpPost]
    public IActionResult InstallApp([FromBody] WooStoreCredentials creds)
    {
        // Save to database or file
        // Maybe trigger webhooks or test the connection
        return Ok("App installed successfully!");
    }
    public class WooStoreCredentials
    {
        public string StoreUrl { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
    }
}
