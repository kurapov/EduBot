using System.Data.Entity;
using EduBot.Core.Model;

namespace EduBot.Core
{
    public class EduBotDbContext : DbContext
    {
        public EduBotDbContext() : base("EduBotConnection")
        {
        }

        public DbSet<Answer> Answers { set; get; }
        public DbSet<Intent> Intents { set; get; }
        public DbSet<Entity> Entities { set; get; }
    }
}
