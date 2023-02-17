using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ButlyaAdminAPI.Models;
using Microsoft.AspNetCore.Authorization;

namespace ButlyaAdminAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(AccountModel model)
        {
            if (!string.IsNullOrEmpty(model.Username) 
                && !string.IsNullOrEmpty(model.Password))
            {
                User newUser = new User() { UserName = model.Username };
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, false);
                    return Ok(result);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return BadRequest();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(AccountModel model)
        {
            if (!string.IsNullOrEmpty(model.Username) 
                && !string.IsNullOrEmpty(model.Password))
            { 
                var result =
                    await _signInManager.
                        PasswordSignInAsync(model.Username, model.Password, model.isRemberMe, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    ModelState.AddModelError("", "Неправильний логін або пароль");
                }

            }
            return BadRequest(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
