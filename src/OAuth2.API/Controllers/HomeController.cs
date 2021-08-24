using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OAuth2.API.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("home")]
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => Ok("Api one here, hello !"));
        }
        
        [HttpGet("/secret")]
        [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
        public async Task<IActionResult> Secret()
        {
            var user = User.Identity;
            return await Task.Run(() => Ok("Wow ! How do you know api one secret ?"));
        }
    }
}