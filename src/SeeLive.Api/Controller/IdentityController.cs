using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeeLive.Infrastructure;

[Route("identity")]
[Authorize]
public class IdentityController : ControllerBase
{
    private SeeLiveContext _context;

    public IdentityController(SeeLiveContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}