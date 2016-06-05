using System.Collections.Generic;

namespace EduBot.Core
{
    public class LuisModel
    {
        public IEnumerable<string> Intents { get; set; }
        public List<KeyValuePair<string, string>> Entities { get; set; }
    }
}
