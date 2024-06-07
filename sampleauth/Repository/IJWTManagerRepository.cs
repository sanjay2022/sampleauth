using BasicJWTauth.Controllers;
using BasicJWTauth.Models;

namespace BasicJWTauth.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
        object Authenticate(UsersController userdata);
    }
}
