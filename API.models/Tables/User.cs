using System.ComponentModel.DataAnnotations;

namespace MobileApp_Database_API.Model
{
    public class User(string name, string email,string password,int id = 1)
    {
        [Key]
        public int ID { get; } = id;
        public string Name { get; } = name;
        public string Email { get; } = email;
        public string Password { get; } = password;
    }
}
