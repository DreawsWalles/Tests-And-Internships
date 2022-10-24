using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;
using System.IO;

namespace LibraryBinary
{
    public class Program
    {
        static string[] commands = { "-help", "-back", "-end", "-add", "-remove", "-search", "-change", "-print", "-inputFromFile" };
        static void WorkWithCommands(string command, ref ClassLibrary library)
        {
            Console.Clear();
            switch (command)
            {
                case "-help":
                    Console.WriteLine("Список команд:");
                    Console.WriteLine("\"-help\"- вывести список команд");
                    Console.WriteLine("\"-back\"- завершить выполнение метода");
                    Console.WriteLine("\"-end\"- завершить работу \"Библиотеки\"");
                    Console.WriteLine("\"-add\"- добавление книги или журнала");
                    Console.WriteLine("\"-remove\"- удаление книги или журнала");
                    Console.WriteLine("\"-search\"- поиск элемнта(-ов) по названию");
                    Console.WriteLine("\"-change\"- изменение параметров уже введенных позиций");
                    Console.WriteLine("\"-print\"- печать списков");
                    Console.WriteLine("\"-inputFromFile\"- добавление файлов из бинарного файла");
                    break;
                case "-back":
                    return;
                case "-end":
                    Environment.Exit(0);
                    break;
                case "-add":
                    AddNode(ref library);
                    break;
                case "-remove":
                    RemoveNode(ref library);
                    break;
                case "-search":
                    Search(ref library);
                    break;
                case "-change":
                    ChangeNode(ref library);
                    break;
                case "-print":
                    Print(ref library);
                    break;
            }
            HelpFunctions.Continue();
            Console.Clear();
        }
        static bool InputJournal(ref JournalBinary journal, ref ClassLibrary library)
        {
            Console.Clear();
            string fieldString = null;
            int fieldInt = 0;
            if (!InputField("Введите код журнала:", ref fieldInt, ref library))
                return false;
            journal.Code = fieldInt;
            if (!InputField("Введите название журнала:", ref fieldString, ref library))
                return false;
            journal.Name = fieldString;
            if (!InputField("Введите издательство:", ref fieldString, ref library))
                return false;
            journal.Publisher = fieldString;
            if (!InputField("Введите год: ", ref fieldInt, ref library))
                return false;
            journal.Year = fieldInt;
            if (!InputField("Введите количество:", ref fieldInt, ref library))
                return false;
            journal.Count = fieldInt;
            if (!InputField("Введите периодичность:", ref fieldInt, ref library))
                return false;
            journal.Periodically = fieldInt;
            if (!InputField("Введите номер:", ref fieldInt, ref library))
                return false;
            journal.Number = fieldInt;
            return true;
        }
        static bool InputField(string message, ref int field, ref ClassLibrary library)
        {
            Console.Clear();
            int check;
            char unCorrectSymbol = ' ';
            string s;
            Menu menu = new Menu("Выберите действие", commands);
            menu.Add("Повторить ввод поля");
            menu.Add("Вернуться в меню", true);
            do
            {
                Console.WriteLine(message);
                Console.Write("-> ");
                s = Console.ReadLine();
                if (HelpFunctions.isCommand(s, commands))
                {
                    WorkWithCommands(s, ref library);
                    return false;
                }
                check = HelpFunctions.ChechNumber(s, ref unCorrectSymbol, 0);
                if (check < 0)
                {
                    switch (check)
                    {
                        case -1:
                            Console.WriteLine("Введена пустая строка");
                            break;
                        case -2:
                            Console.WriteLine($"Введен некорректный символ: {unCorrectSymbol}");
                            break;
                        case -3:
                            Console.WriteLine("Введенное значение должно быть больше 0");
                            break;
                    }
                    menu.Print();
                    if (menu.Choice() == 0)
                        return false;
                    Console.Clear();
                }
            } while (check < 0);
            field = Convert.ToInt32(s);
            return true;
        }
        static bool InputField(string message, ref string field, ref ClassLibrary library)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.Write("-> ");
            field = Console.ReadLine();
            if (HelpFunctions.isCommand(field, commands))
            {
                WorkWithCommands(field, ref library);
                return false;
            }
            return true;
        }
        static bool InputBook(ref BookBinary book, ref ClassLibrary library)
        {
            Console.Clear();
            string fieldString = null;
            int fieldInt = 0;
            if (!InputField("Введите код книги:", ref fieldInt, ref library))
                return false;
            book.Code = fieldInt;
            if (!InputField("Введите название книги:", ref fieldString, ref library))
                return false;
            book.Name = fieldString;
            if (!InputField("Введите автора:", ref fieldString, ref library))
                return false;
            book.Author = fieldString;
            if (!InputField("Введите жанр:", ref fieldString, ref library))
                return false;
            book.Genre = fieldString;
            if (!InputField("Введите количество:", ref fieldInt, ref library))
                return false;
            book.Count = fieldInt;
            if (!InputField("Введите издательство:", ref fieldString, ref library))
                return false;
            book.Publisher = fieldString;
            if (!InputField("Введите год: ", ref fieldInt, ref library))
                return false;
            book.Year = fieldInt;
            return true;
        }
        static void AddNode(ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Что вы хотите добавить?", commands);
            menu.Add("Журнал");
            menu.Add("Книга");
            menu.Add("Выйти в меню", true);
            int choice;
            string command;
            menu.Print();
            choice = menu.Choice(out command);
            Console.Clear();
            switch (choice)
            {
                case -1:
                    WorkWithCommands(command, ref library);
                    return;
                case 1:
                    {
                        JournalBinary journal = new JournalBinary();
                        try
                        {
                            if (InputJournal(ref journal, ref library))
                                library.Add(journal);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                    }
                    break;
                case 2:
                    {
                        BookBinary book = new BookBinary();
                        try
                        {
                            if (InputBook(ref book, ref library))
                                library.Add(book);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                    }
                    break;
            }
            Console.Clear();
        }
        static JournalBinary ChoiceJournal(ref ClassLibrary library)
        {
            Console.Clear();
            if (library.CountBooks < 0)
            {
                Console.WriteLine("Ни одного журнала нет в библиотеке");
                HelpFunctions.Continue();
                return null;
            }
            Menu menu = new Menu("Выберите действие:", commands);
            menu.Add("Повторить ввод");
            menu.Add("Вернуться в меню", true);
            string index;
            int check;
            char unCorrectSymbol = ' ';
            do
            {
                library.PrintJournals();
                Console.Write("Введите номер: ");
                index = Console.ReadLine();
                if (HelpFunctions.isCommand(index, commands))
                {
                    WorkWithCommands(index, ref library);
                    return null;
                }
                check = HelpFunctions.ChechNumber(index, ref unCorrectSymbol, 1, library.CountJournals);
                if (check < 0)
                {
                    switch (check)
                    {
                        case -1:
                            Console.WriteLine("Введена пустая строка");
                            break;
                        case -2:
                            Console.WriteLine($"Введен некорректный символ: {unCorrectSymbol}");
                            break;
                        case -3:
                            Console.WriteLine("Введенное значение должно быть больше 0");
                            break;
                    }
                    menu.Print();
                    if (menu.Choice() == 0)
                        return null;
                    Console.Clear();
                }
            } while (check < 0);
            return library.GetJournal(Convert.ToInt32(index));
        }
        static BookBinary ChoiceBook(ref ClassLibrary library)
        {
            Console.Clear();
            if (library.CountBooks < 0)
            {
                Console.WriteLine("Ни одной книги нет в библиотеке");
                HelpFunctions.Continue();
                return null;
            }
            Menu menu = new Menu("Выберите действие:", commands);
            menu.Add("Повторить ввод");
            menu.Add("Вернуться в меню", true);
            string index;
            int check;
            char unCorrectSymbol = ' ';
            do
            {
                library.PrintBooks();
                Console.Write("Введите номер: ");
                index = Console.ReadLine();
                if (HelpFunctions.isCommand(index, commands))
                {
                    WorkWithCommands(index, ref library);
                    return null;
                }
                check = HelpFunctions.ChechNumber(index, ref unCorrectSymbol, 1, library.CountBooks);
                if (check < 0)
                {
                    switch (check)
                    {
                        case -1:
                            Console.WriteLine("Введена пустая строка");
                            break;
                        case -2:
                            Console.WriteLine($"Введен некорректный символ: {unCorrectSymbol}");
                            break;
                        case -3:
                            Console.WriteLine("Введенное значение должно быть больше 0");
                            break;
                    }
                    menu.Print();
                    if (menu.Choice() == 0)
                        return null;
                    Console.Clear();
                }
            } while (check < 0);
            return library.GetBook(Convert.ToInt32(index));
        }
        static int ChoiceCount(BookBinary book, ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Выберите действие:", commands);
            menu.Add("Повторить ввод");
            menu.Add("Выбрать другую книгу");
            menu.Add("Вернуться в меню", true);
            int check;
            char unCorrectSymbol = ' ';
            string cnt;
            do
            {
                Console.WriteLine(book.ToString());
                Console.Write("Введите количество книг: ");
                cnt = Console.ReadLine();
                if (HelpFunctions.isCommand(cnt, commands))
                {
                    WorkWithCommands(cnt, ref library);
                    return -1;
                }
                check = HelpFunctions.ChechNumber(cnt, ref unCorrectSymbol, 0, book.Count);
                if (check < 0)
                {
                    switch (check)
                    {
                        case -1:
                            Console.WriteLine("Введена пустая строка");
                            break;
                        case -2:
                            Console.WriteLine($"Введен некорректный символ: {unCorrectSymbol}");
                            break;
                        case -3:
                            Console.WriteLine("Введенное значение должно быть больше 0");
                            break;
                    }
                    menu.Print();
                    switch (menu.Choice())
                    {
                        case 0:
                            return -1;
                        case 2:
                            return -2;
                    }
                    Console.Clear();
                }
            } while (check < 0);
            return Convert.ToInt32(cnt);
        }
        static int ChoiceCount(JournalBinary journal, ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Выберите действие:", commands);
            menu.Add("Повторить ввод");
            menu.Add("Выбрать другую книгу");
            menu.Add("Вернуться в меню", true);
            int check;
            char unCorrectSymbol = ' ';
            string cnt;
            do
            {
                Console.WriteLine(journal.ToString());
                Console.Write("Введите количество книг: ");
                cnt = Console.ReadLine();
                if (HelpFunctions.isCommand(cnt, commands))
                {
                    WorkWithCommands(cnt, ref library);
                    return -1;
                }
                check = HelpFunctions.ChechNumber(cnt, ref unCorrectSymbol, 0, journal.Count);
                if (check < 0)
                {
                    switch (check)
                    {
                        case -1:
                            Console.WriteLine("Введена пустая строка");
                            break;
                        case -2:
                            Console.WriteLine($"Введен некорректный символ: {unCorrectSymbol}");
                            break;
                        case -3:
                            Console.WriteLine("Введенное значение должно быть больше 0");
                            break;
                    }
                    menu.Print();
                    switch (menu.Choice())
                    {
                        case 0:
                            return -1;
                        case 2:
                            return -2;
                    }
                    Console.Clear();
                }
            } while (check < 0);
            return Convert.ToInt32(cnt);
        }
        static void RemoveNode(ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Что вы хотите удалить?", commands);
            menu.Add("Журнал");
            menu.Add("Книга");
            menu.Add("Выйти в меню", true);
            int choice;
            string command;
            menu.Print();
            choice = menu.Choice(out command);
            Console.Clear();
            switch (choice)
            {
                case -1:
                    WorkWithCommands(command, ref library);
                    return;
                case 1:
                    {
                        if (library.CountJournals == 0)
                        {
                            Console.WriteLine("В бибилиотеке нет ни одного журнала");
                            HelpFunctions.Continue();
                            return;
                        }
                        int count = 0;
                        JournalBinary journal;
                        try
                        {
                            do
                            {
                                if ((journal = ChoiceJournal(ref library)) != null && (count = ChoiceCount(journal, ref library)) > 0)
                                    library.Remove(journal, count);
                                if (count == -1)
                                    return;
                            } while (count < 0);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                    }
                    break;
                case 2:
                    {
                        if(library.CountJournals == 0)
                        {
                            Console.WriteLine("В бибилотеке нет ни одной книги");
                            HelpFunctions.Continue();
                            return;
                        }
                        int count = -1;
                        BookBinary book;
                        try
                        {
                            do
                            {
                                if ((book = ChoiceBook(ref library)) != null && (count = ChoiceCount(book, ref library)) > 0)
                                    library.Remove(book, count);
                                if (count == -1)
                                    return;
                            } while (count < 0);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                    }
                    break;
            }
            Console.Clear();
        }
        static bool Change(BookBinary book, ref int indexField, ref int fieldInt, ref string fieldString, ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Выберите параметр для изменения", commands);
            menu.Add($"Код: {book.Code}");
            menu.Add($"Название книги: {book.Name}");
            menu.Add($"Автор: {book.Author}");
            menu.Add($"Жанр: {book.Genre}");
            menu.Add($"Издательство: {book.Publisher}");
            menu.Add($"Год: {book.Year}");
            menu.Add($"Количество: {book.Count}");
            menu.Add("Выйти в меню", true);
            int choice;
            string command;
            menu.Print();
            choice = menu.Choice(out command);
            Console.Clear();
            switch (choice)
            {
                case -1:
                    WorkWithCommands(command, ref library);
                    return false;
                case 0:
                    return false;
                case 1:
                    if (!InputField("Введите новый код книги:", ref fieldInt, ref library))
                        return false;
                    break;
                case 2:
                    if (!InputField("Введите новое название книги:", ref fieldString, ref library))
                        return false;
                    break;
                case 3:
                    if (!InputField("Введите нового автора:", ref fieldString, ref library))
                        return false;
                    break;
                case 4:
                    if (!InputField("Введите новый жанр:", ref fieldString, ref library))
                        return false;
                    break;
                case 5:
                    if (!InputField("Введите издательство:", ref fieldString, ref library))
                        return false;
                    break;
                case 6:
                    if (!InputField("Введите год: ", ref fieldInt, ref library))
                        return false;
                    break;
                case 7:
                    if (!InputField("Введите количество:", ref fieldInt, ref library))
                        return false;
                    break;
            }
            indexField = choice;
            return true;
        }
        static bool Change(JournalBinary journal, ref int indexField, ref int fieldInt, ref string fieldString, ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Выберите параметр для изменения", commands);
            menu.Add($"Код: {journal.Code}");
            menu.Add($"Название книги: {journal.Name}");
            menu.Add($"Издательство: {journal.Publisher}");
            menu.Add($"Год: {journal.Year}");
            menu.Add($"Количество: {journal.Count}");
            menu.Add($"Периодичность: {journal.Periodically}");
            menu.Add($"Номер: {journal.Number}");
            menu.Add("Выйти в меню", true);
            int choice;
            string command;
            menu.Print();
            choice = menu.Choice(out command);
            Console.Clear();
            switch (choice)
            {
                case -1:
                    WorkWithCommands(command, ref library);
                    return false;
                case 0:
                    return false;
                case 1:
                    if (!InputField("Введите новый код книги:", ref fieldInt, ref library))
                        return false;
                    break;
                case 2:
                    if (!InputField("Введите новое название книги:", ref fieldString, ref library))
                        return false;
                    break;
                case 3:
                    if (!InputField("Введите издательство:", ref fieldString, ref library))
                        return false;
                    break;
                case 4:
                    if (!InputField("Введите год: ", ref fieldInt, ref library))
                        return false;
                    break;
                case 5:
                    if (!InputField("Введите количество:", ref fieldInt, ref library))
                        return false;
                    break;
                case 6:
                    if (!InputField("Введите периодичность:", ref fieldInt, ref library))
                        return false;
                    break;
                case 7:
                    if (!InputField("Введите номер:", ref fieldInt, ref library))
                        return false;
                    break;
            }
            indexField = choice;
            return true;
        }
        static void ChangeNode(ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Что вы хотите изменить?", commands);
            menu.Add("Журнал");
            menu.Add("Книга");
            menu.Add("Выйти в меню", true);
            int choice;
            string command;
            menu.Print();
            choice = menu.Choice(out command);
            Console.Clear();
            switch (choice)
            {
                case -1:
                    WorkWithCommands(command, ref library);
                    return;
                case 1:
                    {
                        if(library.CountJournals == 0)
                        {
                            Console.WriteLine("Ни одного журнала нет в бибилиотеке");
                            HelpFunctions.Continue();
                            return;
                        }
                        int index = 0;
                        int fieldInt = 0;
                        string fieldString = null;
                        JournalBinary journal;
                        try
                        {
                            if ((journal = ChoiceJournal(ref library)) != null && Change(journal, ref index, ref fieldInt, ref fieldString, ref library))
                            {
                                if (fieldString == null)
                                    library.Change(journal, index, fieldInt);
                                else
                                    library.Change(journal, index, fieldString);
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                    }
                    break;
                case 2:
                    {
                        if(library.CountBooks == 0)
                        {
                            Console.WriteLine("Ни одной книги нет в библиотеке");
                            HelpFunctions.Continue();
                            return;
                        }
                        int index = 0;
                        int fieldInt = 0;
                        string fieldString = null;
                        BookBinary book;
                        try
                        {
                            if ((book = ChoiceBook(ref library)) != null && Change(book, ref index, ref fieldInt, ref fieldString, ref library))
                            {
                                if (fieldString == null)
                                    library.Change(book, index, fieldInt);
                                else
                                    library.Change(book, index, fieldString);
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                    }
                    break;
            }
            Console.Clear();
        }
        static string CheckFileName(string fileName)
        {
            foreach (char symbol in fileName)
                if ((symbol == '/') || (symbol == '\\') || (symbol == ':') || (symbol == '*') || (symbol == '?') || (symbol == '«') || (symbol == '<') || (symbol == '>') || (symbol == '|'))
                    return $"Введен некорректный символ: {symbol}";
            return null;
        }
        static string ChoiceFile(string message, ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Повторить?", commands);
            menu.Add("Да");
            menu.Add("Нет, использовать стандартный файл \"Search.bin\"", true);
            int choice;
            while(true)
            {
                Console.WriteLine(message);
                Console.Write("->");
                string s = Console.ReadLine();
                if(HelpFunctions.isCommand(s, commands))
                {
                    WorkWithCommands(s, ref library);
                    return "";
                }
                string errorMessage;
                if ((errorMessage = CheckFileName(s)) == null)
                    return s;
                Console.WriteLine(errorMessage);
                menu.Print();
                choice = menu.Choice();
                switch(choice)
                {
                    case -1:
                        WorkWithCommands(s, ref library);
                        return "";
                    case 0:
                        return null;

                }
                Console.Clear();
            }
        }
        static void Search(ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Выберите источник поиска", commands);
            menu.Add("Журналы");
            menu.Add("Книги");
            menu.Add("Выйти в главное меню", true);
            menu.Print();
            string command;
            switch (menu.Choice(out command))
            {
                case -1:
                    WorkWithCommands(command, ref library);
                    return;
                case 1:
                    {
                        Console.Clear();
                        if (library.CountJournals == 0)
                        {
                            Console.WriteLine("Ни одного журнала нет в библиотеке");
                            HelpFunctions.Continue();
                            return;
                        }
                        Console.WriteLine("Введите название журнала:");
                        Console.Write("->");
                        string name = Console.ReadLine();
                        Console.Clear();
                        string fileName = null;
                        Menu inputFile = new Menu("Выберите:", commands);
                        inputFile.Add("Ввести имя файла");
                        inputFile.Add("Использовать стандартный файл \"Search.bin\"");
                        inputFile.Print();
                        if (inputFile.Choice() == 0)
                            if ((fileName = ChoiceFile("Введите путь для файла, где будет храниться результат поиска:", ref library)) == "")
                                return;
                        Console.Clear();
                        try
                        {
                            library.SearchJournals(name, fileName);
                            library.PrintJournals(fileName);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Clear();
                        if(library.CountBooks == 0)
                        {
                            Console.WriteLine("Ни одной книги нет в библиотеке");
                            HelpFunctions.Continue();
                            return;
                        }
                        Console.WriteLine("Введите название книги:");
                        Console.Write("->");
                        string name = Console.ReadLine();
                        Console.Clear();
                        string fileName = null;
                        Menu inputFile = new Menu("Выберите:", commands);
                        inputFile.Add("Ввести имя файла");
                        inputFile.Add("Использовать стандартный файл \"Search.bin\"");
                        inputFile.Print();
                        if (inputFile.Choice() == 0)
                            if ((fileName = ChoiceFile("Введите путь для файла, где будет храниться результат поиска:", ref library)) == "")
                                return;
                        Console.Clear();
                        try
                        {
                            library.SearchBooks(name, fileName);
                            library.PrintBooks(fileName);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                        break;
                        }
            }
            HelpFunctions.Continue();
            Console.Clear();
        }
        static void Print(ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Выберите список, который необходимо напечаать", commands);
            menu.Add("Список журналов");
            menu.Add("Список книг");
            menu.Add("Напечатать оба списка");
            menu.Add("выйти в меню", true);
            menu.Print();
            string command;
            switch (menu.Choice(out command))
            {
                
                case -1:
                    WorkWithCommands(command, ref library);
                    return;
                case 1:
                    Console.Clear();
                    if (library.CountJournals == 0)
                    {
                        Console.WriteLine("В библиотеке нет ни одного журнала");
                        HelpFunctions.Continue();
                        return;
                    }
                    try
                    {
                        library.PrintJournals();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        HelpFunctions.Continue();
                        return;
                    }
                    break;
                case 2:
                    Console.Clear();
                    if(library.CountBooks == 0)
                    {
                        Console.WriteLine("В библиотеке нет ни одной книги");
                        HelpFunctions.Continue();
                        return;
                    }
                    try
                    {
                        library.PrintBooks();
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        HelpFunctions.Continue();
                        return;
                    }
                    break;
                case 3:
                    Console.Clear();
                    if (library.CountBooks == 0 && library.CountJournals == 0)
                    {
                        Console.WriteLine("Библиотека пуста");
                    }
                    if (library.CountJournals > 0)
                        try
                        {
                            library.PrintJournals();
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            HelpFunctions.Continue();
                            return;
                        }
                    if (library.CountBooks > 0)
                        try
                        {
                            library.PrintBooks();
                        }
                        catch (Exception e) 
                        { 
                            Console.WriteLine(e.Message); 
                            HelpFunctions.Continue(); 
                            return; 
                        }
                    break;
            }
            HelpFunctions.Continue();
            Console.Clear();
        }
        static BinaryReader InputBinaryFile(ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Повторить?", commands);
            menu.Add("Да");
            menu.Add("Выйти в меню", true);
            int choice;
            do
            {
                Console.WriteLine("Введите имя файла:");
                Console.Write("->");
                string command = Console.ReadLine();
                if(HelpFunctions.isCommand(command, commands))
                {
                    WorkWithCommands(command, ref library);
                    return null;
                }
                string errorMessage;
                if ((errorMessage = CheckFileName(command)) == null && File.Exists(command))
                    return new BinaryReader(File.Open(command, FileMode.Open));
                Console.WriteLine(errorMessage == null ? "Введенный вами файл не найден" : errorMessage);
                menu.Print();
                choice = menu.Choice();
            } while (choice != 0);
            return null;

        }
        static void InputFromFile(ref ClassLibrary library)
        {
            Console.Clear();
            Menu menu = new Menu("Выберите список, который необходимо напечаать", commands);
            menu.Add("Добавить список журналов");
            menu.Add("Добавить список книг");
            menu.Add("Выйти в меню", true);
            menu.Print();
            string command;
            BinaryReader file;
            if ((file = InputBinaryFile(ref library)) == null)
                return;
            switch (menu.Choice(out command))
            {

                case -1:
                    WorkWithCommands(command, ref library);
                    break;
                case 1:
                    Console.Clear();
                    JournalBinary journal = new JournalBinary();
                    try
                    {
                        while (file.PeekChar() > -1)
                        {
                            journal.Read(file);
                            library.Add(journal);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        HelpFunctions.Continue();
                    }

                    break;
                case 2:
                    Console.Clear();
                    BookBinary book = new BookBinary();
                    try
                    {
                        while(file.PeekChar() > -1)
                        {
                            book.Read(file);
                            library.Add(book);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        HelpFunctions.Continue();
                    }
                    break;
            }
            file.Close();
        }
        static public void Main()
        {
            Menu menu = new Menu("Выберите дейтсвие:", commands);
            menu.Add("Добавить запись");
            menu.Add("Удалить запись");
            menu.Add("Изменение параметров для уже введенных позиций");
            menu.Add("Поиск элеметов по названию");
            menu.Add("Напечатать список");
            menu.Add("Добавить данные из файла");
            menu.Add("Выйти в главное меню", true);
            ClassLibrary library = new ClassLibrary();
            int choice;
            string command;
            do
            {
                menu.Print();
                choice = menu.Choice(out command);
                Console.Clear();
                switch (choice)
                {
                    case -1:
                        WorkWithCommands(command, ref library);
                        break;
                    case 1:
                        AddNode(ref library);
                        break;
                    case 2:
                        RemoveNode(ref library);
                        break;
                    case 3:
                        ChangeNode(ref library);
                        break;
                    case 4:
                        Search(ref library);
                        break;
                    case 5:
                        Print(ref library);
                        break;
                    case 6:
                        InputFromFile(ref library);
                        break;
                }
                Console.Clear();
            } while (choice != 0);
        }
    }
}
