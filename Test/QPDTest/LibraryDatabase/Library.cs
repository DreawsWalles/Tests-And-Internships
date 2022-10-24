using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data; 

namespace LibraryDatabase
{
    class Library
    {
        SqlConnection connection = null;
        public int CountBooks { get; private set; }
        public int CountJournals { get; private set; }
        public Library()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["libraryDB"].ConnectionString);
            connection.Open();
            CountBooks = 0;
            CountJournals = 0;
            SqlCommand command = new SqlCommand("SELECT * FROM [Books]", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
                CountBooks++;
            reader.Close();
            command = new SqlCommand("SELECT * FROM [Journals]", connection);
            reader = command.ExecuteReader();
            while (reader.Read())
                CountJournals++;
            reader.Close();
        }
        public void Add(Book book)
        {
            if (book == null)
                throw new Exception("Передан неициализированный объект");
            SqlCommand command = new SqlCommand("SELECT * FROM [Books]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (new Book(Convert.ToInt32(reader["id"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Author"]),
                                            Convert.ToString(reader["Genre"]), Convert.ToInt32(reader["Count"]), Convert.ToString(reader["Publisher"]), Convert.ToInt32(reader["Year"])).CompareTo(book))
                    {
                        command = new SqlCommand("UPDATE [Books] Set [Count] = @Count WHERE [id] = @id", connection);
                        command.Parameters.AddWithValue("id", reader["id"]);
                        command.Parameters.AddWithValue("Count", Convert.ToInt32(reader["Count"]) + book.Count);
                        command.ExecuteNonQuery();
                        return;
                    }
                }
            }
            command = new SqlCommand($"INSERT INTO [Books] (Name, Count, Publisher, Year, Author, Genre) VALUES (@Name, @Count, @Publisher, @Year, @Author, @Genre)", connection);
            command.Parameters.AddWithValue("Name", book.Name);
            command.Parameters.AddWithValue("Count", book.Count);
            command.Parameters.AddWithValue("Publisher", book.Publisher);
            command.Parameters.AddWithValue("Year", book.Year);
            command.Parameters.AddWithValue("Author", book.Author);
            command.Parameters.AddWithValue("Genre", book.Genre);
            command.ExecuteNonQuery();
        }
        public void Add(Journal journal)
        {
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            SqlCommand command = new SqlCommand("SELECT * FROM [Journals]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (new Journal(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Count"]), Convert.ToString(reader["Publisher"]),
                                               Convert.ToInt32(reader["Year"]), Convert.ToInt32(reader["Periodically"]), Convert.ToInt32(reader["Number"])).CompareTo(journal))
                    {
                        command = new SqlCommand("UPDATE [Journals] Set [Count] = @Count WHERE [Id] = @Id", connection);
                        command.Parameters.AddWithValue("Id", reader["Id"]);
                        command.Parameters.AddWithValue("Count", Convert.ToInt32(reader["Count"]) + journal.Count);
                        command.ExecuteNonQuery();
                        return;
                    }

                }
            }
            command = new SqlCommand($"INSERT INTO [Journals] (Name, Count, Publisher, Year, Periodically, Number) VALUES(@Name, @Count, @Publisher, @Year, @Periodically, @Number)", connection);
            command.Parameters.AddWithValue("Name", journal.Name);
            command.Parameters.AddWithValue("Count", journal.Count);
            command.Parameters.AddWithValue("Publisher", journal.Publisher);
            command.Parameters.AddWithValue("Year", journal.Year);
            command.Parameters.AddWithValue("Periodically", journal.Periodically);
            command.Parameters.AddWithValue("Number", journal.Number);
        }
        public bool Remove(Book book, int count)
        {
            if (CountBooks == 0)
                throw new Exception("В базе данных нет ни одной книги");
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            if (count < 0)
                throw new Exception("Количество книг не может быть отрицательным");
            SqlCommand command = null;
            if (book.Count - count <= 0)
            { 
                command = new SqlCommand("DELETE From [Books] where [id] = @id", connection);
                command.Parameters.AddWithValue("id", book.Code);
                CountBooks--;   
            }
            else
            {
                command = new SqlCommand("UPDATE [Books] Set [Count] = @Count WHERE [id] = @id", connection);
                command.Parameters.AddWithValue("id", book.Code);
                command.Parameters.AddWithValue("Count", book.Count - count);
            }
            if (command.ExecuteNonQuery() == 1)
                return true;
            return false;
        }
        public bool Remove(Journal journal, int count)
        {
            if (CountJournals == 0)
                throw new Exception("В базе данных нет ни одного журнала");
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            if (count < 0)
                throw new Exception("Количество книг не может быть отрицательным");
            SqlCommand command = null;
            if (journal.Count - count <= 0)
            {
                command = new SqlCommand("DELETE From [Journals] where [Id] = @Id", connection);
                command.Parameters.AddWithValue("Id", journal.Code);
                CountJournals--;
            }
            else
            {
                command = new SqlCommand("UPDATE [Journals] Set [Count] = @Count WHERE [Id] = @Id", connection);
                command.Parameters.AddWithValue("Id", journal.Code);
                command.Parameters.AddWithValue("Count", journal.Count - count);
            }
            if (command.ExecuteNonQuery() == 1)
                return true;
            return false;
        }
        /// <summary>
        /// Геттер для книг, где index начинается от 1
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Возвращает книгу по индексу</returns>
        public Book GetBook(int index)
        {
            if (index < 0 || index > CountBooks)
                throw new Exception($"Передано некорректное значени индекса. Индекс должен находиться в границах [0;{CountBooks}]");
            SqlCommand command = new SqlCommand("SELECT * FROM [Books]", connection);
            int count = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (count == index - 1)
                        return new Book(Convert.ToInt32(reader["id"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Author"]),
                                        Convert.ToString(reader["Genre"]), Convert.ToInt32(reader["Count"]), Convert.ToString(reader["Publisher"]), Convert.ToInt32(reader["Year"]));
                    count++;
                }
            }
            return null;
        }
        /// <summary>
        /// Геттер для журналов, где index начинается от 1
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Возвращает журнал по индексу</returns>
        public Journal GetJournal(int index)
        {
            if (index < 0 || index > CountJournals)
                throw new Exception($"Передано некорректное значени индекса. Индекс должен находиться в границах [0;{CountJournals}]");
            SqlCommand command = new SqlCommand("SELECT * FROM[Journals]", connection);
            int count = 0;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (count == index - 1)
                        return new Journal(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Count"]), Convert.ToString(reader["Publisher"]),
                                           Convert.ToInt32(reader["Year"]), Convert.ToInt32(reader["Periodically"]), Convert.ToInt32(reader["Number"]));
                    count++;
                }
            }
            return null;
        }
        private Dictionary<int, Func<string, Book, Book>> ChangeFieldBook = new Dictionary<int, Func<string, Book, Book>>
        {
            {1, (field, book) => new Book(book.Code, field, book.Author, book.Genre, book.Count, book.Publisher, book.Year) },
            {2, (field, book) => new Book(book.Code, book.Name, field, book.Genre, book.Count, book.Publisher, book.Year) },
            {3, (field, book) => new Book(book.Code, book.Name, book.Author, field, book.Count, book.Publisher, book.Year) },
            {4, (field, book) => new Book(book.Code, book.Name, book.Author, book.Genre, book.Count, field, book.Year) },
            {5, (field, book) => new Book(book.Code, book.Name, book.Author, book.Genre, book.Count, book.Publisher, Convert.ToInt32(field)) },
            {6, (field, book) => new Book(book.Code, book.Name, book.Author, book.Genre, Convert.ToInt32(field), book.Publisher, book.Year) }
        };
        private Dictionary<int, string> GetCommandBook = new Dictionary<int, string>
        {
            {1, "UPDATE [Books] Set [Name] = @Name WHERE [id] = @id" },
            {2, "UPDATE [Books] Set [Author] = @Author WHERE [id] = @id" },
            {3, "UPDATE [Books] Set [Genre] = @Genre WHERE [id] = @id" },
            {4, "UPDATE [Books] Set [Publisher] = @Publisher WHERE [id] = @id" },
            {5, "UPDATE [Books] Set [Year] = @Year WHERE [id] = @id" },
            {6, "UPDATE [Books] Set [Count] = @Count WHERE [id] = @id" }
        };
        private Dictionary<int, Func<Book, SqlParameter>> GetParametrsBook = new Dictionary<int, Func<Book, SqlParameter>>
        {
            {1, (book) => new SqlParameter("Name", book.Name) },
            {2, (book) => new SqlParameter("Author", book.Author) },
            {3, (book) => new SqlParameter("Genre", book.Genre) },
            {4, (book) => new SqlParameter("Publisher", book.Publisher) },
            {5, (book) => new SqlParameter("Year", book.Year) },
            {6, (book) => new SqlParameter("Count", book.Count) }
        };
        private Dictionary<int, Func<string, Journal, Journal>> ChangeFieldJournal = new Dictionary<int, Func<string, Journal, Journal>>
        {
            {1, (field, journal) => new Journal(journal.Code, field, journal.Count, journal.Publisher, journal.Year, journal.Periodically, journal.Number)},
            {2, (field, journal) => new Journal(journal.Code, journal.Name, journal.Count, field, journal.Year, journal.Periodically, journal.Number)},
            {3, (field, journal) => new Journal(journal.Code, journal.Name, journal.Count, journal.Publisher, Convert.ToInt32(field), journal.Periodically, journal.Number)},
            {4, (field, journal) => new Journal(journal.Code, journal.Name, Convert.ToInt32(field), journal.Publisher, journal.Year, journal.Periodically, journal.Number)},
            {5, (field, journal) => new Journal(journal.Code, journal.Name, journal.Count, journal.Publisher, journal.Year, Convert.ToInt32(field), journal.Number)},
            {6, (field, journal) => new Journal(journal.Code, journal.Name, journal.Count, journal.Publisher, journal.Year, journal.Periodically, Convert.ToInt32(field))},
        };
        private Dictionary<int, string> GetCommandJournal = new Dictionary<int, string>
        {
            {1, "UPDATE [Journals] Set [Name] = @Name WHERE [Id] = @Id" },
            {2, "UPDATE [Journals] Set [Publisher] = @Publisher WHERE [Id] = @Id" },
            {3, "UPDATE [Journals] Set [Year] = @Year WHERE [Id] = @Id" },
            {4, "UPDATE [Journals] Set [Count] = @Count WHERE [Id] = @Id"},
            {5, "UPDATE [Journals] Set [Periodically] = @Periodically WHERE [Id] = @Id" },
            {6, "UPDATE [Journals] Set [Number] = @Number WHERE [Id] = @Id" }
        };
        private Dictionary<int, Func<Journal, SqlParameter>> GetParametrsJournal = new Dictionary<int, Func<Journal, SqlParameter>>
        {
            {1, (journal) => new SqlParameter("Name", journal.Name) },
            {2, (journal) => new SqlParameter("Publisher", journal.Publisher) },
            {3, (Journal) => new SqlParameter("Year", Journal.Year) },
            {4, (journal) => new SqlParameter("Count", journal.Count) },
            {5, (journal) => new SqlParameter("Periodically", journal.Periodically) },
            {6, (journal) => new SqlParameter("Number", journal.Number) }
        };
        public void Change<T>(Book book, int numberFields, T value)
        {
            if (CountBooks == 0)
                throw new Exception("В базе данных нет ни одной книги");
            if (book == null)
                throw new Exception("Передан неинициализированный объект");
            if (numberFields < 1 || numberFields > 6)
                throw new Exception("Номер поля передан не правильно");
            book = ChangeFieldBook[numberFields](Convert.ToString(value), book);
            SqlCommand command = new SqlCommand("SELECT * FROM [Books]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (new Book(Convert.ToInt32(reader["id"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Author"]),
                                            Convert.ToString(reader["Genre"]), Convert.ToInt32(reader["Count"]), Convert.ToString(reader["Publisher"]), Convert.ToInt32(reader["Year"])).CompareTo(book))
                    {
                        command = new SqlCommand("UPDATE [Books] Set [Count] = @Count WHERE [id] = @id", connection);
                        command.Parameters.AddWithValue("id", reader["id"]);
                        command.Parameters.AddWithValue("Count", Convert.ToInt32(reader["Count"]) + book.Count);
                        command.ExecuteNonQuery();
                        command = new SqlCommand("DELETE From [Books] where [id] = @id", connection);
                        command.Parameters.AddWithValue("id", book.Code);
                        CountBooks--;
                        command.ExecuteNonQuery();
                        return;
                    }
                }
            }
            command = new SqlCommand(GetCommandBook[numberFields], connection);
            command.Parameters.AddWithValue("id", book.Code);
            command.Parameters.Add(GetParametrsBook[numberFields](book));
            command.ExecuteNonQuery();
        }
        public void Change<T>(Journal journal, int numberFields, T value)
        {
            if (CountJournals == 0)
                throw new Exception("В базе данных нет ни одного журнала");
            if (journal == null)
                throw new Exception("Передан неинициализированный объект");
            if (numberFields < 0 || numberFields > 6)
                throw new Exception("Номер поля передан не правильно");
            journal = ChangeFieldJournal[numberFields](Convert.ToString(value), journal);
            SqlCommand command = new SqlCommand("SELECT * FROM [Journals]", connection);
            using(SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (new Journal(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Count"]), Convert.ToString(reader["Publisher"]),
                                               Convert.ToInt32(reader["Year"]), Convert.ToInt32(reader["Periodically"]), Convert.ToInt32(reader["Number"])).CompareTo(journal))
                    {
                        command = new SqlCommand("UPDATE [Journals] Set [Count] = @Count WHERE [Id] = @Id", connection);
                        command.Parameters.AddWithValue("Id", reader["Id"]);
                        command.Parameters.AddWithValue("Count", Convert.ToInt32(reader["Count"]) + journal.Count);
                        command.ExecuteNonQuery();
                        command = new SqlCommand("DELETE FROM [Journals] WHERE [Id] = @Id");
                        command.Parameters.AddWithValue("Id", journal.Code);
                        CountJournals--;
                        command.ExecuteNonQuery();
                        return;
                    }
                }
            }
            command = new SqlCommand(GetCommandJournal[numberFields], connection);
            command.Parameters.AddWithValue("Id", journal.Code);
            command.Parameters.Add(GetParametrsJournal[numberFields](journal));
            command.ExecuteNonQuery();
        }
        public List<Book>SearchBooks(string name)
        {
            if (CountBooks == 0)
                throw new Exception("В базе данных нет ни одной книги");
            if (name == null)
                throw new Exception("Передан неинициализированный объект");
            List<Book> result = new List<Book>();
            SqlCommand command = new SqlCommand("SELECT * FROM [Books] WHERE [Name] = @Name", connection);
            command.Parameters.AddWithValue("Name", name);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(new Book(Convert.ToInt32(reader["id"]), Convert.ToString(reader["Name"]), Convert.ToString(reader["Author"]),
                                            Convert.ToString(reader["Genre"]), Convert.ToInt32(reader["Count"]), Convert.ToString(reader["Publisher"]), Convert.ToInt32(reader["Year"])));
            }
            return result;
        }
        public List<Journal>SearchJournals(string name)
        {
            if (CountJournals == 0)
                throw new Exception("В базе данных нет ни одной книги");
            if (name == null)
                throw new Exception("Передан неинициализированный объект");
            List<Journal> result = new List<Journal>();
            SqlCommand command = new SqlCommand("SELECT * FROM [Journals] WHERE [Name] = @Name", connection);
            command.Parameters.AddWithValue("Name", name);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                    result.Add(new Journal(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]), Convert.ToInt32(reader["Count"]), Convert.ToString(reader["Publisher"]),
                                               Convert.ToInt32(reader["Year"]), Convert.ToInt32(reader["Periodically"]), Convert.ToInt32(reader["Number"])));
            }
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
        public void PrintBooks(List<Book> list)
        {
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
                                  $"{ProcessingField(list[i].Year.ToString(), 7)}|{ProcessingField(list[i].Count.ToString(), 14)}|");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            Console.WriteLine("|     |           |                |             |            |                    |       |              |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
        }
        public void PrintJournals(List<Journal> list)
        {
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
        public void PrintBooks()
        {
            Console.WriteLine("\t\t\t\t\tСписок книг");
            for (int i = 0; i < 106; i++)
                Console.Write('_');
            Console.WriteLine();
            Console.WriteLine("|  №  |    Код    |    Название    |    Автор    |    Жанр    |    Издательство    |  Год  |  Количество  |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            SqlCommand command = new SqlCommand("SELECT * FROM [Books]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                int i = 1;
                while (reader.Read())
                {
                    Console.WriteLine($"|{ProcessingField((i).ToString(), 5)}|{ProcessingField(Convert.ToString(reader["id"]), 11)}|{ProcessingField(Convert.ToString(reader["Name"]), 16)}|" +
                                      $"{ProcessingField(Convert.ToString(reader["Author"]), 13)}|{ProcessingField(Convert.ToString(reader["Genre"]), 12)}|" +
                                      $"{ProcessingField(Convert.ToString(reader["Publisher"]), 20)}|{ProcessingField(Convert.ToString(reader["Year"]), 7)}|" +
                                      $"{ProcessingField(Convert.ToString(reader["Count"]), 14)}|");
                    i++;
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
        public void PrintJournals()
        {
            Console.WriteLine("\t\t\t\t\tСписок журналов");
            for (int i = 0; i < 106; i++)
                Console.Write('_');
            Console.WriteLine();
            Console.WriteLine("|  №  |    Код    |    Название    |    Издательство    |  Периодичность  |  Номер  |  Год  |  Количество |");
            for (int i = 0; i < 106; i++)
                Console.Write('=');
            Console.WriteLine();
            SqlCommand command = new SqlCommand("SELECT * FROM [Journals]", connection);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                int i = 1;
                while(reader.Read())
                {
                    Console.WriteLine($"|{ProcessingField((i).ToString(), 5)}|{ProcessingField(Convert.ToString(reader["Id"]), 11)}|{ProcessingField(Convert.ToString(reader["Name"]), 16)}|" +
                                  $"{ProcessingField(Convert.ToString(reader["Publisher"]), 20)}|{ProcessingField(Convert.ToString(reader["Periodically"]), 17)}|" +
                                  $"{ProcessingField(Convert.ToString(reader["Number"]), 9)}|{ProcessingField(Convert.ToString(reader["Year"]), 7)}|" +
                                  $"{ProcessingField(Convert.ToString(reader["Count"]), 13)}");
                    i++;
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
