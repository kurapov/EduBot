using System.Collections.Generic;

namespace EduBot.Core.Model
{
    public class Entity
    {
        public int Id { set; get; }
        public string Key { get; set; }
        public string Value { set; get; }

        public virtual ICollection<Answer> Answers { set; get; }
    }
}
