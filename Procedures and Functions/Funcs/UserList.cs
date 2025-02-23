using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Microsoft.EntityFrameworkCore;
namespace Procedures_and_Functions.Funcs
{
    public class UserList
    {
        private Context DB { get; }

        public UserList(Context db)
        {
            this.DB = db;
        }
        public object Get_User(string Email, string Passsword)
        {
            object users = DB.Users.FromSqlRaw("SELECT * FROM get_user({0},{1})", Email, Passsword).AsNoTracking().Select(u => new {u.ID,u.Name,u.Email});
            return users;
        }
    }
}

