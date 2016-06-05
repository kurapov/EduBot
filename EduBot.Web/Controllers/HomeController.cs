using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using EduBot.Core;
using EduBot.Core.Model;
using EduBot.Core.Services;
using EduBot.Web.Models;

namespace EduBot.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult AddAnswers()
        {
            ViewBag.Title = "Home Page";

            using (var ctx = new EduBotDbContext())
            {
                ViewBag.Intents = ctx.Intents.ToList();
                ViewBag.entities = ctx.Entities.ToList();
            }

            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult AddAnswers(AnswerEditModel model)
        {
            using (var ctx = new EduBotDbContext())
            {
                var entities = ctx.Entities.Where(entity => model.Entities.Contains(entity.Id)).ToList();
                ctx.Answers.Add(new Answer()
                {
                    AnswerText = model.Answer,
                    IntentId = model.Intent,
                    Entities = entities
                });
                ctx.SaveChanges();
            }

            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Parse(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Read bytes from http input stream
                BinaryReader br = new BinaryReader(file.InputStream);
                byte[] binData = br.ReadBytes((int)file.InputStream.Length);
                string fileStr = System.Text.Encoding.UTF8.GetString(binData);

                IntentParser parser = new IntentParser();
                var luisModel = parser.Parse(fileStr);

                using (var ctx = new EduBotDbContext())
                {
                    var intents = luisModel.Intents.Select(token => new Intent() {Value = token}).ToList();
                    if (intents.Any())
                        ctx.Intents.AddRange(intents);

                    if (intents.Any())
                        ctx.Intents.AddRange(intents);

                    var entities = luisModel.Entities.Select(token => new Entity()
                    {
                        Key = token.Key,
                        Value = token.Value
                    }).ToList();

                    if (entities.Any())
                    {
                        ctx.Entities.AddRange(entities);
                    }

                    var changes = ctx.SaveChanges();
                    ViewBag.Title = "It Was Parsed! There are " + changes + " changes";
                }
            }
            

            return View("Index");
        }
    }
}
