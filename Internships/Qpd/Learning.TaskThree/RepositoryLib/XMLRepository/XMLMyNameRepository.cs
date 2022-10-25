using Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.XMLRepository
{
    public class XMLMyNameRepository : IRepository
    {
        public XMLMyNameRepository()
        {
            if(!Directory.Exists("XMLRepository"))
                Directory.CreateDirectory("XMLRepository");
            if (!File.Exists("XMLRepository/MyName"))
                XmlFiles.Create(new string[] { "Шарпик" }, "XMLRepository/MyName");
        }

        public void Add(AskModel model)
        {
            XmlFiles.Add(model, "XMLRepository/MyName");
        }

        public string Get(int id)
        {
            return XmlFiles.Get(id, "XMLRepository/MyName");
        }
        ~XMLMyNameRepository()
        {
            File.Delete("XMLRepository/MyName");
        }
    }
}
