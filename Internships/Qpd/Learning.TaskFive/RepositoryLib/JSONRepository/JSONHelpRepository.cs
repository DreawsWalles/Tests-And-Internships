﻿using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.JSONRepository
{
    public class JSONHelpRepository : IRepository
    {
        public JSONHelpRepository()
        {
            if (!Directory.Exists("JSONRepository"))
                Directory.CreateDirectory("JSONRepository");
            if (!File.Exists("JSONRepository/Help"))
            {
                AskModel[] parametrs = new AskModel[]
                {
                    new AskModel() {Id = 0, Ask = "Список доступных команд:\n" +
                                                    "1. Поздороваться с ботом (например \"Привет\")\n" +
                                                    "2. Попрощаться с ботом (например \"Пока\")\n" +
                                                    "3. Анекдот\n" +
                                                    "4. Спроси как меня зовут\n" +
                                                    "5. Спроси который сейчас час\n" +
                                                    "6. -help\n" +
                                                    "7. *Команда не распознана* (бот ответит вам афоризмом"}
                };
                JsonFiles.Create(parametrs.ToList(), "JSONRepository/Help");
            }
        }
        public void Add(AskModel model)
        {
            JsonFiles.Add(model, "JSONRepository/Help");
        }

        public string Get(int id)
        {
            return JsonFiles.Get(id, "JSONRepository/Help").Ask;
        }
    }
}
