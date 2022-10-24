using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryBinary
{
    class ClassLibrary
    {
        string fileNameBooks = "System/Books.bin";
        string fileNameJournals = "System/Journal.bin";
        string fileHelp = "system/Help.bin";
        public string fileSearch { get; private set; }
        public int CountBooks { get; private set; }
        public int CountJournals { get; private set; }
        public ClassLibrary()
        {
            Directory.CreateDirectory("System");
            var file = File.Create(fileNameBooks);
            file.Close();
            file = File.Create(fileNameJournals);
            file.Close();            
        }
        ~ClassLibrary()
        {
            foreach (string directoryName in Directory.EnumerateDirectories("System"))
                Directory.Delete(directoryName);
            foreach (string fileName in Directory.EnumerateFiles("system"))
                File.Delete(fileName);
            Directory.Delete("System");
        }
        public void Add(BookBinary book)
        {
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            BinaryWriter fileWriter = new BinaryWriter(File.Open(fileHelp, FileMode.OpenOrCreate));
            BinaryReader fileReader = new BinaryReader(File.Open(fileNameBooks, FileMode.Open));
            BookBinary current = new BookBinary();
            CountBooks = 0;
            while(fileReader.PeekChar() > -1)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При считывании из файла произошла ошибка");
                if (current.CompareTo(book))
                {
                    book.Count += current.Count;
                    continue;
                }
                CountBooks++;
                if (!current.Write(fileWriter))
                    throw new Exception("При записи в файл произошла ошибка");
            }
            if (!book.Write(fileWriter))
                throw new Exception("При записи в файл произошла ошибка");
            CountBooks++;
            fileWriter.Close();
            fileReader.Close();
            File.Delete(fileNameBooks);
            File.Move(fileHelp, fileNameBooks);
        }
        public void Add(JournalBinary journal)
        {
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            BinaryWriter fileWriter = new BinaryWriter(File.Open(fileHelp, FileMode.OpenOrCreate));
            BinaryReader fileReader = new BinaryReader(File.Open(fileNameJournals, FileMode.Open));
            BookBinary current = new BookBinary();
            CountJournals = 0;
            while (fileReader.PeekChar() > -1)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При считывании из файла произошла ошибка");
                if (current.CompareTo(journal))
                {
                    journal.Count += current.Count;
                    continue;
                }
                CountJournals++;
                if (!current.Write(fileWriter))
                    throw new Exception("При записи в файл произошла ошибка");
            }
            if (!journal.Write(fileWriter))
                throw new Exception("При записи в файл произошла ошибка");
            CountJournals++;
            fileWriter.Close();
            fileReader.Close();
            File.Delete(fileNameJournals);
            File.Move(fileHelp, fileNameJournals);
        }
        public bool Remove(BookBinary book, int count = 0)
        {
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            if (count < 0)
                throw new Exception("Количество книг не может быть отрицательным");
            BinaryWriter fileWriter = new BinaryWriter(File.Open(fileHelp, FileMode.OpenOrCreate));
            BinaryReader fileReader = new BinaryReader(File.Open(fileNameBooks, FileMode.Open));
            BookBinary current = new BookBinary();
            bool isDelete = false;
            while (fileReader.PeekChar() > -1)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При считывании из файла произошла ошибка");
                if (current.CompareTo(book))
                {
                    if ((current.Count - count) <= 0 || count == current.Count)
                    {
                        isDelete = true;
                        CountBooks--;
                        continue;
                    }
                    current.DecCount(count);
                }
                if (!current.Write(fileWriter))
                    throw new Exception("При записи в файл произошла ошибка");
            }
            fileWriter.Close();
            fileReader.Close();
            File.Delete(fileNameJournals);
            File.Move(fileHelp, fileNameJournals);
            return isDelete;
        }
        public bool Remove(JournalBinary journal, int count = 0)
        {
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            if (count < 0)
                throw new Exception("Количество книг не может быть отрицательным");
            BinaryWriter fileWriter = new BinaryWriter(File.Open(fileHelp, FileMode.OpenOrCreate));
            BinaryReader fileReader = new BinaryReader(File.Open(fileNameJournals, FileMode.Open));
            JournalBinary current = new JournalBinary();
            bool isDelete = false;
            while (fileReader.PeekChar() > -1)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При считывании из файла произошла ошибка");
                if (current.CompareTo(journal))
                {
                    if ((current.Count - count) <= 0 || count == current.Count)
                    {
                        isDelete = true;
                        CountJournals--;
                        continue;
                    }
                    current.DecCount(count);
                }
                if (!current.Write(fileWriter))
                    throw new Exception("При записи в файл произошла ошибка");
            }
            fileWriter.Close();
            fileReader.Close();
            File.Delete(fileNameJournals);
            File.Move(fileHelp, fileNameJournals);
            return isDelete;
        }
        public BookBinary GetBook(int index)
        {
            if (index < 0 || index > CountBooks)
                throw new Exception($"Передано некорректное значени индекса. Индекс должен находиться в границах [0;{CountBooks}]");
            BinaryReader file = new BinaryReader(File.Open(fileNameBooks, FileMode.Open));
            int position = 0;
            BookBinary result = new BookBinary();
            while (position < index)
            {
                if (!result.Read(file))
                    throw new Exception("При чтении из файла произошла ошибка");
                position++;
            }
            file.Close();
            return result;
        }
        public JournalBinary GetJournal(int index)
        {
            if (index < 0 || index > CountJournals)
                throw new Exception($"Передано некорректное значени индекса. Индекс должен находиться в границах [0;{CountBooks}]");
            BinaryReader file = new BinaryReader(File.Open(fileNameJournals, FileMode.Open));
            int position = 0;
            JournalBinary result = new JournalBinary();
            while (position < index)
            {
                if (!result.Read(file))
                    throw new Exception("При чтении из файла произошла ошибка");
                position++;
            }
            file.Close();
            return result;
        }

        private Dictionary<int, Func<string, BookBinary, BookBinary>> ChangeFieldBook = new Dictionary<int, Func<string, BookBinary, BookBinary>>
        {
            {1, (field, book) => new BookBinary(Convert.ToInt32(field), book.Name, book.Author, book.Genre, book.Count, book.Publisher, book.Year) },
            {2, (field, book) => new BookBinary(book.Code, field, book.Author, book.Genre, book.Count, book.Publisher, book.Year) },
            {3, (field, book) => new BookBinary(book.Code, book.Name, field, book.Genre, book.Count, book.Publisher, book.Year) },
            {4, (field, book) => new BookBinary(book.Code, book.Name, book.Author, field, book.Count, book.Publisher, book.Year) },
            {5, (field, book) => new BookBinary(book.Code, book.Name, book.Author, book.Genre, book.Count, field, book.Year) },
            {6, (field, book) => new BookBinary(book.Code, book.Name, book.Author, book.Genre, book.Count, book.Publisher, Convert.ToInt32(field)) },
            {7, (field, book) => new BookBinary(book.Code, book.Name, book.Author, book.Genre, Convert.ToInt32(field), book.Publisher, book.Year) }
        };
        
        private Dictionary<int, Func<string, JournalBinary, JournalBinary>> ChangeFieldJournal = new Dictionary<int, Func<string, JournalBinary, JournalBinary>>
        {
            {1, (field, journal) => new JournalBinary(Convert.ToInt32(field), journal.Name, journal.Count, journal.Publisher, journal.Year, journal.Periodically, journal.Number)},
            {2, (field, journal) => new JournalBinary(journal.Code, field, journal.Count, journal.Publisher, journal.Year, journal.Periodically, journal.Number)},
            {3, (field, journal) => new JournalBinary(journal.Code, journal.Name, journal.Count, field, journal.Year, journal.Periodically, journal.Number)},
            {4, (field, journal) => new JournalBinary(journal.Code, journal.Name, journal.Count, journal.Publisher, Convert.ToInt32(field), journal.Periodically, journal.Number)},
            {5, (field, journal) => new JournalBinary(journal.Code, journal.Name, Convert.ToInt32(field), journal.Publisher, journal.Year, journal.Periodically, journal.Number)},
            {6, (field, journal) => new JournalBinary(journal.Code, journal.Name, journal.Count, journal.Publisher, journal.Year, Convert.ToInt32(field), journal.Number)},
            {7, (field, journal) => new JournalBinary(journal.Code, journal.Name, journal.Count, journal.Publisher, journal.Year, journal.Periodically, Convert.ToInt32(field))},
        };
        public void Change<T>(BookBinary book, int numberFields, T field)
        {
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            if (numberFields < 0 || numberFields > 6)
                throw new Exception("Номер поля передан не правильно");
            BookBinary bookChange = ChangeFieldBook[numberFields](field.ToString(), book);
            BinaryReader fileReader = new BinaryReader(File.Open(fileNameBooks, FileMode.Open));
            BinaryWriter fileWriter = new BinaryWriter(File.Open(fileHelp, FileMode.Create));
            BookBinary current = new BookBinary();
            int index = 0;
            int cnt = 1;
            for(int i = 0; fileReader.PeekChar() > -1 && cnt < 2; i++)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При чтении произошла ошибка");
                if (current.CompareTo(book))
                    index = i;
                if (current.CompareTo(bookChange))
                {
                    cnt++;
                    current.Count += bookChange.Count;
                }
            }
            fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; fileReader.PeekChar() > -1; i++)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При чтении произошла ошибка");
                if (i == index)
                {
                    if (cnt == 2)
                    {
                        CountBooks--;
                        continue;
                    }
                    bookChange.Write(fileWriter);
                    continue;
                }
                current.Write(fileWriter);
            }
            fileWriter.Close();
            fileReader.Close();
            File.Delete(fileNameBooks);
            File.Move(fileHelp, fileNameBooks);
        }
        public void Change<T>(JournalBinary journal, int numberFields, T field)
        {
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            if (numberFields < 0 || numberFields > 6)
                throw new Exception("Номер поля передан не правильно");
            JournalBinary journalChange = ChangeFieldJournal[numberFields](field.ToString(), journal);
            BinaryReader fileReader = new BinaryReader(File.Open(fileNameJournals, FileMode.Open));
            BinaryWriter fileWriter = new BinaryWriter(File.Open(fileHelp, FileMode.Create));
            JournalBinary current = new JournalBinary();
            int index = 0;
            int cnt = 1;
            for (int i = 0; fileReader.PeekChar() > -1 && cnt < 2; i++)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При чтении произошла ошибка");
                if (current.CompareTo(journal))
                    index = i;
                if (current.CompareTo(journalChange))
                {
                    cnt++;
                    current.Count += journalChange.Count;
                }
            }
            fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
            for (int i = 0; fileReader.PeekChar() > -1; i++)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При чтении произошла ошибка");
                if (i == index)
                {
                    if (cnt == 2)
                    {
                        CountBooks--;
                        continue;
                    }
                    journalChange.Write(fileWriter);
                    continue;
                }
                current.Write(fileWriter);
            }
            fileWriter.Close();
            fileReader.Close();
            File.Delete(fileNameJournals);
            File.Move(fileHelp, fileNameJournals);
        }
        public void SearchBooks(string name, string fileName = null)
        {
            if (name == null)
                throw new Exception("Переданный объект неинициализирован");
            fileSearch = fileName == null ? "System/Search" : fileName;
            BinaryReader fileReader = new BinaryReader(File.Open(fileNameBooks, FileMode.Open));
            BinaryWriter fileWriter = new BinaryWriter(File.Open(fileSearch, FileMode.Create));
            BookBinary current = new BookBinary();
            while (fileReader.PeekChar() > -1)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При считывании из файла произошла ошибка");
                if (current.CompareTo(new Product(0, name, 0, "", 0)))
                    current.Write(fileWriter);
            }
            fileWriter.Close();
            fileReader.Close();
        }
        public void SearchJournals(string name, string fileName = null)
        {
            if (name == null)
                throw new Exception("Переданный объект неинициализирован");
            fileSearch = fileName == null ? "System/Search" : fileName;
            BinaryReader fileReader = new BinaryReader(File.Open(fileNameJournals, FileMode.Open));
            BinaryWriter fileWriter = new BinaryWriter(File.Open(fileSearch, FileMode.Create));
            JournalBinary current = new JournalBinary();
            while (fileReader.PeekChar() > -1)
            {
                if (!current.Read(fileReader))
                    throw new Exception("При считывании из файла произошла ошибка");
                if (current.CompareTo(new Product(0, name, 0, "", 0)))
                    current.Write(fileWriter);
            }
            fileWriter.Close();
            fileReader.Close();
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
        public void PrintBooks(string fileName = null)
        {
            if (fileName == null)
                fileName = fileNameBooks;
            Console.WriteLine("\t\t\t\t\tСписок книг");
            for (int i = 0; i < 106; i++)
                Console.Write('_');
            Console.WriteLine();
            Console.WriteLine("|  №  |    Код    |    Название    |    Автор    |    Жанр    |    Издательство    |  Год  |  Количество  |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            using (BinaryReader file = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                BookBinary current = new BookBinary();
                for (int i = 1; file.PeekChar() > -1; i++)
                {
                    if (!current.Read(file))
                        throw new Exception("При считывании из файла произошла ошибка");
                    Console.WriteLine($"|{ProcessingField(i.ToString(), 5)}|{ProcessingField(current.Code.ToString(), 11)}|{ProcessingField(current.Name, 16)}|" +
                                      $"{ProcessingField(current.Author, 13)}|{ProcessingField(current.Genre, 12)}|{ProcessingField(current.Publisher, 20)}|" +
                                      $"{ProcessingField(current.Year.ToString(), 7)}|{ProcessingField(current.Count.ToString(), 14)}|");
                }
            }
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            Console.WriteLine("|     |           |                |             |            |                    |       |              |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
        }
        public void PrintJournals(string fileName = null)
        {
            if (fileName == null)
                fileName = fileNameJournals;
            Console.WriteLine("\t\t\t\t\tСписок журналов");
            for (int i = 0; i < 106; i++)
                Console.Write('_');
            Console.WriteLine();
            Console.WriteLine("|  №  |    Код    |    Название    |    Издательство    |  Периодичность  |  Номер  |  Год  |  Количество |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            using (BinaryReader file = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                JournalBinary current = new JournalBinary();
                for (int i = 1; file.PeekChar() > -1; i++)
                {
                    if (!current.Read(file))
                        throw new Exception("При считывании из файла произошла ошибка");
                    Console.WriteLine($"|{ProcessingField(i.ToString(), 5)}|{ProcessingField(current.Code.ToString(), 11)}|{ProcessingField(current.Name, 16)}|" +
                                      $"{ProcessingField(current.Publisher, 20)}|{ProcessingField(current.Periodically.ToString(), 17)}|{ProcessingField(current.Number.ToString(), 9)}|" +
                                      $"{ProcessingField(current.Year.ToString(), 7)}|{ProcessingField(current.Count.ToString(), 13)}");
                }
            }
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
