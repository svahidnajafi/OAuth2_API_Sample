using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OAuth2.API.Identity;
using OAuth2.API.Models;

namespace OAuth2.API.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthController(IIdentityServerInteractionService interactionService,
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _interactionService = interactionService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
    }
}