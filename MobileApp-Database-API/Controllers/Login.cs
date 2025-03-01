using Microsoft.AspNetCore.Mvc;
using DB;
using Procedures_and_Functions.Models;
using Procedures_and_Functions.Funcs;
using JWT.Models;
namespace MobileApp_Database_API.Controllers;

[ApiController]
[Route("[controller]")]
public class Login : ControllerBase
{
    private readonly Context DB;

    private readonly IConfiguration Configuration;

    private readonly ILogger<Login> _logger;

    public Login(ILogger<Login> logger, Context db, IConfiguration configuration)
    {
        this.DB = db;
        _logger = logger;
        Configuration = configuration;
    }

    [HttpPost(Name = "Login")]
    public async Task<string> Post([FromBody] Login_User body)
    {

        string key = Configuration["JWTKey"] ?? "";
        if (String.IsNullOrEmpty(key))
        {
            throw new Exception("JWTKey not found");
        }
        Token user = await new UserList(DB, key).Get_User(body.Email, body.Password);
        string JWT = JWTGenerator.CreateJWT(user, key);
        return JWT;

    }
}
