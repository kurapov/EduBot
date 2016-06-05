using System.Threading.Tasks;
using System.Web.Http;
using EduBot.Dialogs;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace EduBot.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>

        //public async Task<Message> Post([FromBody]Message message)
        //{
        //    //using (var ctx = new EduBotDbContext())
        //    //{
        //    //    ctx.Questions.Add(new Question()
        //    //    {
        //    //        AnswerText = "answer 1",
        //    //        QuestionText = "question 1"
        //    //    });
        //    //    ctx.SaveChanges();
        //    //}

        //    if (message.Type == "Message")
        //    {
        //        // calculate something for us to return
        //        int length = (message.Text ?? string.Empty).Length;

        //        // return our reply to the user
        //        return message.CreateReplyMessage($"You sent {length} characters");
        //    }
        //    else
        //    {
        //        return HandleSystemMessage(message);
        //    }
        //}

        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                // return our reply to the user
                return await Conversation.SendAsync(message, () => new SimpleAlarmDialog());
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}