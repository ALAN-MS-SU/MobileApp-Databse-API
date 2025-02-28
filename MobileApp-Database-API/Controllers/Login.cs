using Microsoft.AspNetCore.Mvc;
using Tables.Users;
using DB;
using Procedures_and_Functions.Models;
using Procedures_and_Functions.Funcs;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MobileApp_Database_API.Controllers;

[ApiController]
[Route("[controller]")]
public class Login : ControllerBase
{
    private Context DB;

    private readonly ILogger<Login> _logger;

    public Login(ILogger<Login> logger, Context db)
    {
        this.DB = db;
        _logger = logger;
    }

    [HttpPost(Name = "Login")]
    public async Task<Token> Post([FromBody] Login_User body)
    {

        Token user = await new UserList(DB).Get_User(body.Email, body.Password);
        return user;

    }
}
