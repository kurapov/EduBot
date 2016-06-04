using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EduBot.Core.Model;

namespace EduBot.Core
{
    public class EduBotDbContext : DbContext
    {
        public EduBotDbContext()
            : base("EduBotConnection")
        { }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<Question> Questions { set; get; }
    }
}
