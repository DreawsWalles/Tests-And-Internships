using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.JSONRepository
{
    public class JSONByeRepository : IRepository
    {
        public JSONByeRepository()
        {
            if (!Directory.Exists("JSONRepository"))
                Directory.CreateDirectory("JSONRepository");
            if (!File.Exists("JSONRepository/Bye"))
            {
                AskModel[] parametrs = new AskModel[] 
                {
                    new AskModel(){ Id = 1, Ask = "Пока"},
                    new AskModel(){ Id = 2, Ask = "До свидания"}
                };
                JsonFiles.Create(parametrs.ToList(), "JSONRepository/Bye");
            }
        }
        public void Add(AskModel model)
        {
            JsonFiles.Add(model, "JSONRepository/Bye");
        }

        public string Get(int id)
        {
            return JsonFiles.Get(id, "JSONRepository/Bye").Ask;
        }
    }
}
