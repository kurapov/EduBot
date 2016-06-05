using System.Collections.Generic;

namespace EduBot.Core.Model
{
    public class Intent
    {
        public int Id { set; get; }
        public string Value { set; get; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}