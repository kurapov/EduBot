using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduBot.Core.Model
{
    public class Tag
    {
        public int Id { set; get; }
        public string TagName { set; get; }
        public ICollection<Question> Questions { set; get; }
        public Tag()
        {
            Questions = new List<Question>();
        }
    }
}
