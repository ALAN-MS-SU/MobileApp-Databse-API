using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Microsoft.EntityFrameworkCore;
using JWT.Models;
namespace Procedures_and_Functions.Funcs
{
    public class UserList
    {
        private Context DB { get; }

        private string JWTKey { get; }

        public UserList(Context db, string key)
        {
            this.DB = db;
            this.JWTKey = key;
        }
        public async Task<Token> Get_User(string Email, string Passsword)
        {
            Token? user = await DB.Users.FromSqlRaw("SELECT * FROM get_user({0},{1})", Email, Passsword).AsNoTracking().Select(user => new Token(user.ID, user.Name, user.Email)).FirstOrDefaultAsync();
            if(user != null)
            {
                return user;
            }
            throw new Exception("User not found");
        }
    }
}

