namespace JWT.Models
{
    public class Token(int id, string name, string email)
    {
        public int ID { get; set; } = id;

        public string Name { get; set; } = name;

        public string Email { get; set; } = email;

    }

}
