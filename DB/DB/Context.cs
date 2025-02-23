using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tables.Users;
namespace DB
{
    public class Context : DbContext
    {
        private IConfiguration Config;

        public DbSet<User> Users { get; set; }

        public Context(IConfiguration config, DbContextOptions options) : base(options)
        {
            this.Config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Type = this.Config["TypeConnectionDB"]??"";
            var ConnectionString = this.Config.GetConnectionString(Type);

            optionsBuilder.UseNpgsql(ConnectionString);
        }
    }
}
