using Microsoft.EntityFrameworkCore;
using Model.Domain.Entities;
using Model.Infra.Data.Config;

namespace Model.Infra.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserConfig().Configure);
        }
    }
}
