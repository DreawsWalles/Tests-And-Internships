using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Help
{
    /// <summary>
    /// Класс для работы с XML файлами, предназначенными для работы с классом CharBot
    /// </summary>
    public class XmlFiles
    {
        public static void Create(string[] parametrs, string filePath)
        {
            XDocument xdoc = new XDocument();
            XElement answers = new XElement("answers");
            for (int i = 0; i < parametrs.Length; i++)
            {
                XElement answerElem = new XElement("answer");
                XElement idElem = new XElement("id", Convert.ToString(i + 1));
                XElement textElem = new XElement("text", parametrs[i]);
                answerElem.Add(idElem);
                answerElem.Add(textElem);
                answers.Add(answerElem);
            }

            xdoc.Add(answers);
            xdoc.Save(filePath);
        }
        public static void Add(AskModel model, string filePath)
        {
            XmlDocument xDoc = new XmlDocument();   
            xDoc.Load(filePath);
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot == null)
                Create(new string[] { model.Ask }, filePath);
            foreach (XmlElement xnode in xRoot)
                if (xnode.ChildNodes[0].InnerText == Convert.ToString(model.Id))
                    throw new Exception("Елемент с таким id уже добавлен");
            XmlElement answerElem = xDoc.CreateElement("answer");
            XmlElement idElem = xDoc.CreateElement("id");
            XmlElement textElem = xDoc.CreateElement("text");
            XmlText idText = xDoc.CreateTextNode(Convert.ToString(model.Id));
            XmlText txt = xDoc.CreateTextNode(model.Ask);

            idElem.AppendChild(idText);
            textElem.AppendChild(txt);
            answerElem.AppendChild(idElem);
            answerElem.AppendChild(textElem);
            xRoot.AppendChild(answerElem);

            xDoc.Save(filePath);
        }
        public static string Get(int id, string filePath)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
            XmlElement xRoot = xDoc.DocumentElement;
            if (xRoot == null)
                throw new Exception("Данный файл пуст");
            foreach (XmlElement xnode in xRoot)
                if (xnode.ChildNodes[0].InnerText == Convert.ToString(id))
                    return xnode.ChildNodes[1].InnerText;
            return null;
        }
    }
}
