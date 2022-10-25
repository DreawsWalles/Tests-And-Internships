﻿using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.XMLRepository
{
    public class XMLHelpRepository : IRepository
    {
        public XMLHelpRepository()
        {
            if (!Directory.Exists("XMLRepository"))
                Directory.CreateDirectory("XMLRepository");
            if (!File.Exists("XMLRepository/Help"))
            {
                string[] parametrs = new string[] { "Список доступных команд:\n" +
                                                    "1. Поздороваться с ботом (например \"Привет\")\n" +
                                                    "2. Попрощаться с ботом (например \"Пока\")\n" +
                                                    "3. Анекдот\n" +
                                                    "4. Спроси как меня зовут\n" +
                                                    "5. Спроси который сейчас час\n" +
                                                    "6. -help\n" +
                                                    "7. *Команда не распознана* (бот ответит вам афоризмом" };
                XmlFiles.Create(parametrs, "XMLRepository/Help");
            }
        }
        public void Add(AskModel model)
        {
            XmlFiles.Add(model, "XMLRepository/Help");
        }

        public string Get(int id)
        {
            return XmlFiles.Get(id, "XMLRepository/Help");
        }
    }
}
