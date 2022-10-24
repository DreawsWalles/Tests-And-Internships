using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeOne_ThemeTwo;
using TasksFromTheBook;
using HelpClasses;

namespace TestTask
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Test.Start();
            Menu mainMenu = new Menu("Выберите тему: ");
            mainMenu.Add("Тема 1. Основы CLR.");
            mainMenu.Add("Тема 2. Основы С#.");
            mainMenu.Add("Тема 3. Основы ООП");
            mainMenu.Add("Тема 4. ООП – продолжение");
            mainMenu.Add("Тема 5. Хранение данных");
            mainMenu.Add("Тема 6. Многопоточность");
            mainMenu.Add("Тема 7. EF");
            mainMenu.Add("Тема 8. Основы web");
            mainMenu.Add("Тема 9. MVC Core");
            mainMenu.Add("Завершить работу программы", true);
            int choice;
            do
            {
                Console.Clear();
                mainMenu.Print();
                choice = mainMenu.Choice();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        ThemeOne themeOne = new ThemeOne();
                        break;
                    case 2:
                        ThemeTwo themeTwo = new ThemeTwo();
                        break;
                    case 3:
                        ThemeThree.Program.Main();
                        break;
                    case 4:
                        ThemeFour.Program.Main();
                        break;
                    case 5:
                        ThemeFive.Program.Main();
                        break;
                    case 6:
                        ThemeSix.Program.Main();
                        break;
                    case 7:
                        LibraryDatabase.Program.Main();
                        break;

                }
            } while (choice != 0);
        }
    }
}
