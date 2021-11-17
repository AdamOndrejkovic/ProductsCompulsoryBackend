using Compulsory.Security.Authenticator;
using Compulsory.WebApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Compulsory.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController: ControllerBase
    {
        private readonly IAuthenticator _authenticator;

        public LoginController(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult Login([FromBody] LoginInputDto login)
        {
            string userToken;
            if (_authenticator.Login(login.Username,login.Password, out userToken))
            {
                return Ok(
                    new
                    {
                        token = userToken
                    });
            }
            return Unauthorized("Unknown username and password combination");
        }
        
        [AllowAnonymous]
        [HttpPost(nameof(Register))]
        public ActionResult Register([FromBody] LoginInputDto login)
        {
            var registered = _authenticator.Register(login.Username, login.Password);
            if (registered)
            {
                return Ok();
            }

            return Unauthorized("Error occurred while registering");
        }
        
        
    }
}