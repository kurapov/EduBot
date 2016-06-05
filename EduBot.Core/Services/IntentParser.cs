using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace EduBot.Core.Services
{
    public class IntentParser
    {
        public LuisModel Parse(string jsonText)
        {
            var luisModel = new LuisModel();

            var deserialized = JObject.Parse(jsonText);

            luisModel.Intents = deserialized["intents"].ToList().Select(token => token["Name"].ToString());
            var entities = deserialized["entities"].ToList();//.Select(token => token["Name"]);
            entities.ForEach(token =>
            {
                luisModel.Entities = new List<KeyValuePair<string, string>>();
                var entityName = token["Name"];
                var entityChindren = token["Children"];
                luisModel.Entities.Add(new KeyValuePair<string, string>(entityName.ToString(), ""));
                entityChindren.ToList().ForEach(value =>
                {
                    luisModel.Entities.Add(new KeyValuePair<string, string>(entityName.ToString(), value.ToString()));
                });
            });

            return luisModel;
        }
    }
}
