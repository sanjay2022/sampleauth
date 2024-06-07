using BasicJWTauth.Models;
using BasicJWTauth.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicJWTauth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository jWTManagerRepository;

        public UsersController(JWTManagerRepository jWTManagerRepository)
        {
            this.jWTManagerRepository = jWTManagerRepository;
        }
        [HttpGet]
        [Route("userlist")]
        public List<string> Get()
        {
            var users = new List<string>
        {
            "Satinder Singh",
            "Amit Sarna",
            "Davin Jon"
        };

            return users;
        }
        
        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate([FromBody] Users users
            )
        {
            var token = jWTManagerRepository.Authenticate(users);

            if (token == null)
            {
                return Unauthorized();

            }
            return Ok(token);
        }
    }
}
