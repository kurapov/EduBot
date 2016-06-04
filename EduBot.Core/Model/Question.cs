using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBot.Core.Model
{
    public class Question
    {
        public int Id { set; get; }
        public string QuestionText { set; get; }
        public string AnswerText { set; get; }
        public ICollection<Tag> Tags { set; get; }
        public Question()
        {
            Tags = new List<Tag>();
        }
    }
}
