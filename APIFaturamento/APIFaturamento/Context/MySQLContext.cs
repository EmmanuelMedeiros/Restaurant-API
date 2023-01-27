using APIFaturamento.Models;
using Microsoft.EntityFrameworkCore;

namespace APIFaturamento.Context {
    public class MySQLContext : DbContext{

        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<Billing> Billings { get; set; }

    }
}
