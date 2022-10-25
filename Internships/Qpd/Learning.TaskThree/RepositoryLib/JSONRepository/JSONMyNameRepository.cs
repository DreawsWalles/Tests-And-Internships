using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.JSONRepository
{
    public class JSONMyNameRepository : IRepository
    {
        public JSONMyNameRepository()
        {
            if (!Directory.Exists("JSONRepository"))
                Directory.CreateDirectory("JSONRepository");
            if (!File.Exists("JSONRepository/MyName"))
            {
                AskModel[] parametrs = new AskModel[]
                {
                    new AskModel(){ Id = 0, Ask = "Шарпик" }
                };
                JsonFiles.Create(parametrs.ToList(), "JSONRepository/MyName");
            }
        }
        public void Add(AskModel model)
        {
            JsonFiles.Add(model, "JSONRepository/MyName");
        }

        public string Get(int id)
        {
            return JsonFiles.Get(id, "JSONRepository/MyName").Ask;
        }
    }
}
