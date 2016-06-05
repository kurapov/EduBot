using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduBot.Core;
using EduBot.Core.Model;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;

namespace EduBot.Dialogs
{
    [LuisModel("65ffbb8b-e261-4bbf-abb2-033b6a7b046b", "30476f7febfa41a486860c8cd9259a10")]
    [Serializable]
    public class SimpleAlarmDialog : LuisDialog<object>
    {

        //[LuisIntent("")]
        //public async Task None(IDialogContext context, LuisResult result)
        //{
        //    string message = $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));
        //    await context.PostAsync(message);
        //    context.Wait(MessageReceived);
        //}

        //[LuisIntent("познакомиться")]
        //public async Task Frendly(IDialogContext context, LuisResult result)
        //{
        //    using (var ctx = new EduBotDbContext())
        //    {
        //        var exceptedIntent = result.Intents.First().Intent;
        //        var exceptedEntity = result.Entities.First();
        //        var answers = ctx.Answers.Where(a => a.Intent.Value == exceptedIntent).ToList();
        //        //var relevantAnswer = answers.Where(a => a.Entities.Any(entity => entity.Value == exceptedEntity.Entity && entity.Key == exceptedEntity.Type)).SingleOrDefault();
        //        var relevantAnswer = answers.First();

        //        if (relevantAnswer != null)
        //            await context.PostAsync($"!!! {relevantAnswer.AnswerText} !!!");
        //    }

        //    context.Wait(MessageReceived);
        //}

        //[LuisIntent("развестись")]
        [LuisIntent("")]
        public async Task All(IDialogContext context, LuisResult result)
        {
            using (var ctx = new EduBotDbContext())
            {
                var exceptedIntent = result.Intents.First().Intent;
                var exceptedEntity = result.Entities.First();
                var answers = ctx.Answers.Where(a => a.Intent.Value == exceptedIntent).ToList();
                //var relevantAnswer = answers.Where(a => a.Entities.Any(entity => entity.Value == exceptedEntity.Entity && entity.Key == exceptedEntity.Type)).SingleOrDefault();
                Answer relevantAnswer;
                if (string.IsNullOrEmpty(exceptedEntity.Entity))
                {
                    relevantAnswer = answers.SingleOrDefault(a => a.Entities.Any(entity => entity.Key == exceptedEntity.Type));
                }
                else
                    relevantAnswer = answers.First();

                if (relevantAnswer != null)
                    await context.PostAsync($"-- {relevantAnswer.AnswerText} !!!");
            }

            context.Wait(MessageReceived);
        }
    }
}