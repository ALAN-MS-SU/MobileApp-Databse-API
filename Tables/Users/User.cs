using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Tables.Users
{
    [Table("Users")]
    public class User(int ID, string Name, string Email, string Password)
    {
        [Key]
        [Column("ID")]
        [Display(Name = "ID")]
        public int ID { get; set; } = ID;

        [Column("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; } = Name;

        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; } = Email;

        [Column("Password")]
        [Display(Name = "Password")]
        [AllowNull]
        public string Password { get; set; } = Password;

    }
}
