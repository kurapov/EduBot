using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduBot.Core.Model
{
    public class Answer
    {
        public int Id { set; get; }
        public string AnswerText { set; get; }

        [ForeignKey("Intent")]
        public int IntentId { get; set; }
        public Intent Intent { get; set; }
        public virtual ICollection<Entity> Entities { set; get; }
    }
}
