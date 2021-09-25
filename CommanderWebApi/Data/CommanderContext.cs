using CommanderWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderWebApi.Data
{
    public class CommanderContext : DbContext
    {
        public DbSet<Command> Commands { get; set; }

        public CommanderContext(DbContextOptions<CommanderContext> options) : base(options)
        {

        }
    }
}
