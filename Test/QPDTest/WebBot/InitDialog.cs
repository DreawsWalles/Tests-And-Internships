using WebBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebBot
{
    public static class InitDialog
    {
        public static void Initialize(Chat context)
        {
            if (context.dialogs.Any())
            {
                foreach (var el in context.dialogs)
                    context.dialogs.Remove(el);
            }
            context.dialogs.AddRange(new Message { _Message = Bot.Ask("Привет") });
            context.SaveChanges();
        }
    }
}
