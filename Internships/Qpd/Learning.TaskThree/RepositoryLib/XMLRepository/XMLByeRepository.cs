using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.XMLRepository
{
    public class XMLByeRepository : IRepository
    {
        public XMLByeRepository()
        {
            if (!Directory.Exists("XMLRepository"))
                Directory.CreateDirectory("XMLRepository");
            if (!File.Exists("XMLRepository/Bye"))
            {
                string[] parametrs = new string[] { "Пока", "До свидания" };
                XmlFiles.Create(parametrs, "XMLRepository/Bye");
            }
        }

        public void Add(AskModel model)
        {
            XmlFiles.Add(model, "XMLRepository/Bye");
        }

        public string Get(int id)
        {
            return XmlFiles.Get(id, "XMLRepository/Bye");
        }
        ~XMLByeRepository()
        {
            File.Delete("XMLRepository/Bye");
        }
    }
}
