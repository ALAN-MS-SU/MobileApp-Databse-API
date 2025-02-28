using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Microsoft.EntityFrameworkCore;
using Procedures_and_Functions.Models;
namespace Procedures_and_Functions.Funcs
{
    public class UserList
    {
        private Context DB { get; }

        public UserList(Context db)
        {
            this.DB = db;
        }
        public async Task<Token> Get_User(string Email, string Passsword)
        {
            Token users = await DB.Users.FromSqlRaw("SELECT * FROM get_user({0},{1})", Email, Passsword).AsNoTracking().Select(user => new Token(user.ID, user.Name, user.Email)).FirstOrDefaultAsync();
            return users;
        }
    }
}

