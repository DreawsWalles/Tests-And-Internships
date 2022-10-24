using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ClassLibrary
    {
        List<Book> listOfBooks;
        List<Journal> listOfJournals;
        public ClassLibrary()
        {
            listOfBooks = new List<Book>();
            listOfJournals = new List<Journal>();
        }
        
        public void Add(Book book)
        {
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            foreach(Book element in listOfBooks)
                if (element.CompareTo(book))
                {
                    element.IncCount(book.Count);
                    return;
                }
            listOfBooks.Add(book);
        }
        public void Add(Journal journal)
        {
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            foreach(Journal element in listOfJournals)
                if (element.CompareTo(journal))
                {
                    element.IncCount(journal.Count);
                    return;
                }
            listOfJournals.Add(journal);
        }
        public bool Remove(Book book, int count = 0)
        {
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            if (count < 0)
                throw new Exception("Количество книг не может быть отрицательным");
            foreach (Book element in listOfBooks)
                if (element.CompareTo(book))
                {
                    if (count == 0 || element.Count - count < 0 || count == element.Count)
                        listOfBooks.Remove(element);
                    else
                        element.DecCount(count);
                    return true;
                }
            return false;
        }
        public bool Remove(Journal journal, int count = 0)
        {
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            if (count < 0)
                throw new Exception("Количество журналов не может быть отрицательным");
            foreach (Journal element in listOfJournals)
                if (element.CompareTo(journal))
                { 
                    if (count == 0 || element.Count - count < 0 || count == element.Count)
                        listOfJournals.Remove(element);
                    else
                        element.DecCount(count);
                    return true;
                }
            return false;
        }
        public int IndexOf(Book book)
        {
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            for (int i = 0; i < listOfBooks.Count; i++)
                if (listOfBooks[i].CompareTo(book))
                    return i;
            return -1;
        }
        public int IndexOf(Journal journal)
        {
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            for (int i = 0; i < listOfJournals.Count; i++)
                if (listOfJournals[i].CompareTo(journal))
                    return i;
            return -1;
        }
        public Book GetBook(int index)
        {
            if (index < 0 || index > listOfBooks.Count)
                throw new Exception($"Передано некорректное значени индекса. Индекс должен находиться в границах [0;{listOfBooks.Count}]");
            return listOfBooks[index];
        }
        public Journal GetJournal(int index)
        {
            if (index < 0 || index > listOfJournals.Count)
                throw new Exception($"Передано некорректное значени индекса. Индекс должен находиться в границах [0;{listOfJournals.Count}]");
            return listOfJournals[index];
        }
        public int CountBooks { get { return listOfBooks.Count; } private set { } }
        public int CountJournals { get { return listOfJournals.Count; } private set { } }
        public void Change<T>(Book book, int numberFields, T value)
        {
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            if (numberFields < 0 || numberFields > 6)
                throw new Exception("Номер поля передан не правильно");
            int index = 0;
            while (!listOfBooks[index].CompareTo(book))
                index++;
            switch(numberFields)
            {
                case 1:
                    listOfBooks[index].Code = Convert.ToInt32(value);
                    break;
                case 2:
                    listOfBooks[index].Name = value.ToString();
                    break;
                case 3:
                    listOfBooks[index].Author = value.ToString();
                    break;
                case 4:
                    listOfBooks[index].Genre = value.ToString();
                    break;
                case 5:
                    listOfBooks[index].Publisher = value.ToString();
                    break;
                case 6:
                    listOfBooks[index].Year = Convert.ToInt32(value);
                    break;
                case 7:
                    listOfBooks[index].Count = Convert.ToInt32(value);
                    break;
            }
            int cnt = 0;
            int i;
            for (i = 0; i < listOfBooks.Count && cnt < 2 ; i++)
                if (listOfBooks[i].CompareTo(listOfBooks[index]))
                    cnt++;
            if (cnt == 2)
            {
                listOfBooks[i].IncCount(listOfBooks[index].Count);
                listOfBooks.RemoveAt(index);
            }
        }
        public void Change<T>(Journal journal, int numberFields, T value)
        {
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            if (numberFields < 0 || numberFields > 6)
                throw new Exception("Номер поля передан не правильно");
            int index = 0;
            while (!listOfJournals[index].CompareTo(journal))
                index++;
            switch (numberFields)
            {
                case 1:
                    listOfJournals[index].Code = Convert.ToInt32(value);
                    break;
                case 2:
                    listOfJournals[index].Name = value.ToString();
                    break;
                case 3:
                    listOfJournals[index].Publisher = value.ToString();
                    break;
                case 4:
                    listOfJournals[index].Year = Convert.ToInt32(value);
                    break;
                case 5:
                    listOfJournals[index].Count = Convert.ToInt32(value);
                    break;
                case 6:
                    listOfJournals[index].Periodically = Convert.ToInt32(value);
                    break;
                case 7:
                    listOfJournals[index].Number = Convert.ToInt32(value);
                    break;
            }
            int cnt = 0;
            int i;
            for (i = 0; i < listOfJournals.Count && cnt < 2; i++)
                if (listOfJournals[i].CompareTo(listOfJournals[index]))
                    cnt++;
            if (cnt == 2)
            {
                listOfJournals[i].IncCount(listOfJournals[index].Count);
                listOfJournals.RemoveAt(index);
            }
        }
        public List<Book> SearchBooks(string name)
        {
            if (name == null)
                throw new Exception("Передан неинициализированный объект");
            List<Book> result = new List<Book>();
            foreach (Book element in listOfBooks)
                if (element.CompareTo(new Product(0, name, 0, "", 0)))
                    result.Add(element);
            return result;
        }
        public List<Journal> SearchJournals(string name)
        {
            if (name == null)
                throw new Exception("Передан неинициализированный объект");
            List<Journal> result = new List<Journal>();
            foreach (Journal element in listOfJournals)
                if (element.CompareTo(new Product(0, name, 0, "", 0)))
                    result.Add(element);
            return result; 
        }
        private string ProcessingField(string field, int longField)
        {
            if (field.Length <= longField)
            {
                string spaces = "";
                while ((field.Length + spaces.Length) < longField)
                    spaces += " ";
                return field.Insert(field.Length, spaces);
            }
            return field.Insert(longField - 3, "...").Substring(0, longField);
        }
        public void PrintBooks(List<Book> list = null)
        {
            if (list == null)
                list = listOfBooks;
            Console.WriteLine("\t\t\t\t\tСписок книг");
            for (int i = 0; i < 106; i++)
                Console.Write('_');
            Console.WriteLine();
            Console.WriteLine("|  №  |    Код    |    Название    |    Автор    |    Жанр    |    Издательство    |  Год  |  Количество  |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"|{ProcessingField((i + 1).ToString(), 5)}|{ProcessingField(list[i].Code.ToString(), 11)}|{ProcessingField(list[i].Name, 16)}|" +
                                  $"{ProcessingField(list[i].Author, 13)}|{ProcessingField(list[i].Genre, 12)}|{ProcessingField(list[i].Publisher, 20)}|" +
                                  $"{ProcessingField(list[i].Year.ToString(), 7)}|{ProcessingField(list[i].Count.ToString(), 14)}|") ;
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            Console.WriteLine("|     |           |                |             |            |                    |       |              |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
        }
        public void PrintJournals(List<Journal>list = null)
        {
            if (list == null)
                list = listOfJournals;
            Console.WriteLine("\t\t\t\t\tСписок журналов");
            for (int i = 0; i < 106; i++)
                Console.Write('_');
            Console.WriteLine();
            Console.WriteLine("|  №  |    Код    |    Название    |    Издательство    |  Периодичность  |  Номер  |  Год  |  Количество |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"|{ProcessingField((i + 1).ToString(), 5)}|{ProcessingField(list[i].Code.ToString(), 11)}|{ProcessingField(list[i].Name, 16)}|" +
                                  $"{ProcessingField(list[i].Publisher, 20)}|{ProcessingField(list[i].Periodically.ToString(), 17)}|{ProcessingField(list[i].Number.ToString(), 9)}|" +
                                  $"{ProcessingField(list[i].Year.ToString(), 7)}|{ProcessingField(list[i].Count.ToString(), 13)}");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            Console.WriteLine("|     |           |                |                    |                 |         |       |             |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
        }
    }
}
