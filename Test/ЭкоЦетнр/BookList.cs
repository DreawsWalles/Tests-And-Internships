using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace project
{
    [Serializable]
    [XmlRoot("Book")]
    public class BookList
    {
        [XmlArray("BookList"), XmlArrayItem(typeof(Book), ElementName = "Book")]



        public List<Book> list { get; set; }

        public BookList()
        {
            list = new List<Book>();
        }
        /// <summary>
        /// метод загрузки данных из xml файла
        /// пытаемся считать данные, если получается открыть файл и структура файла подходит
        /// еслиструктура не подходит уведомляем пользователя об этом
        /// </summary>
        /// <param name="fileName"></param>
        public void LoadXML(string fileName)
        {
            try
            {
                XmlSerializer xf = new XmlSerializer(typeof(BookList));
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                BookList tmb = (BookList)xf.Deserialize(fs);
                list = tmb.list;
                fs.Close();
            }
            catch
            {
                MessageBox.Show("Данный файл имеет некорректную структуру", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// метод сохранения данных в xml файл
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveXML(string fileName)
        {
            XmlSerializer writer = new XmlSerializer(typeof(BookList));
            FileStream sw = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter file = new StreamWriter(sw);
            writer.Serialize(file, this);
            file.Close();
        }

        /// <summary>
        /// приватный метода удаления 
        /// он нужен ,потому что стандартный метод у списка не удаляет нужные нам данные, т к сравнивает он не по полям
        /// поэтому с помощью компаратора мы находим и удаляем через функция RemoveAt
        /// Метода возвращает результат удаления
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private bool remove(Book element)
        {
            int index = 0;
            while (index < list.Count)
            {
                if (list[index].CompareTo(element))
                {
                    list.RemoveAt(index);
                    return true;
                }
                index++;
            }
            return false;
        }
        /// <summary>
        /// метод удаления для поиска, где поступает не элемент а данные для этого элемента
        /// метод возвращает результат удаления
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Remove(string[] info)
        {
            Book book = new Book(info);
            return remove(book);
        }
        /// <summary>
        /// метод удаления для поиска, где поступает сам элемент
        /// метод возвращает результат удаления
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Remove(Book element)
        {
            return remove(element);
        }
        /// <summary>
        /// метод добавления элемента
        /// </summary>
        /// <param name="book"></param>
        public void Add(Book book)
        {
            list.Add(book);
        }
        /// <summary>
        /// индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Count)
                    throw new Exception("Выход за пределы списка");
                return list[index];
            }
            set
            {
                if (index < 0 || index >= list.Count)
                    throw new Exception("Выход за пределы списка");
                list[index] = value;
            }
        }
    }
}
