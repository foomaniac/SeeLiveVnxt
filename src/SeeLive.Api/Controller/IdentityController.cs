using Microsoft.AspNetCore.Authorization;

[Route("identity")]
[Authorize]
public class IdentityController : ControllerBase
{

    public IdentityController()
    {
 
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}