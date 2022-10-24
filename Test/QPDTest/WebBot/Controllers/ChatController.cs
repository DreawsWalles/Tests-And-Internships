using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebBot.Models;

namespace WebBot.Controllers
{
    public class Model
    {
        public IEnumerable<Message> Dialogs { get; set; }
        public Message Message { get; set; }
        public Model(IEnumerable<Message> dialogs, Message message = null)
        {
            Dialogs = dialogs;
            Message = message;
        }
    }
    public class ChatController : Controller
    {
        Chat db;
        public ChatController(Chat context)
        {
            db = context;
        }
        public ActionResult GetMessage()
        {
            IEnumerable<Message> dialogs = db.dialogs.ToList();
            return PartialView(dialogs);
        }
        public IActionResult Index()
        {
            ViewData["dialogs"] = db.dialogs.ToList();
            return View();
        }
        [HttpPost]
        public RedirectToActionResult Ask(Message model)
        {
            if(string.IsNullOrEmpty(model._Message))
                return RedirectToAction("Index");
            db.dialogs.Add(new Message { _Message = model._Message });
            db.dialogs.Add(new Message { _Message = Bot.Ask(model._Message)});
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
