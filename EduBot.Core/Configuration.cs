using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduBot.Core.Model;

namespace EduBot.Core
{
    class Configuration : DropCreateDatabaseAlways<EduBotDbContext>
    {
        protected override void Seed(EduBotDbContext context)
        {
            //var intents = new List<Intent>()
            //{
            //    new Intent() { Id = 1, Value = "познакомиться"},
            //    new Intent() { Id = 2, Value = "развестись"}
            //};



            base.Seed(context);
        }
    }
}
