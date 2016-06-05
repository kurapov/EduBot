using System.Collections.Generic;

namespace EduBot.Web.Models
{
    public class AnswerEditModel
    {
        public int Intent { get; set; }
        public List<int> Entities { get; set; }
        public string Answer { get; set; }
    }
}