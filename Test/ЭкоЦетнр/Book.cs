using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    [Serializable]
    public class Book
    {
        public string Title { get; set; }
        public string[] Author { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }

        //констурктор по умолчанию
        public Book()
        {

        }
        //конструктор, где входной параметр это массив данных
        public Book(string[] info)
        {
            //пытаемся все присвоить
            //если не получается, значит данные, которые были поданы некорректны
            try
            {
                Title = info[0];
                Author = info[1].Split(';');
                Category = info[2];
                Year = Convert.ToInt32(info[3]);
                Price = float.Parse(info[4]);
            }
            catch
            {
                throw new Exception("Переданы не правильные данные");
            }
        }
        //констурктор, где подаются параметры через запятую
        public Book(string title, string author, string category, int year, string price)
        {
            //пытаемся все присвоить
            //если не получается, значит данные, которые были поданы некорректны
            try
            {
                Title = title;
                Author = author.Split(';');
                Category = category;
                Year = year;
                Price = float.Parse(price);
            }
            catch
            {
                throw new Exception("Переданы не правильные данные");
            }
        }
        //преобразование данных в массив строк, для вывода в DataGridView
        public string[] ToArrayString()
        {
            string author = "";
            if (Author.Count() != 1)
                foreach (string element in Author)
                    author += element + ";";
            else
                author = Author[0];
            string[] result = { Title, author, Category,Year.ToString(), Price.ToString() };
            return result;
        }
        //компаратор
        //возвращает true, если две записи равны... в инном случае возвращает false
        public bool CompareTo(Book a)
        {
            return (a.Author == Author && a.Category == Category && a.Title == Title && a.Price == Price && a.Year == Year);
        }
       
    }
}
