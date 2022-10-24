using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;

namespace ThemeFive
{
    public class Program
    {
        static void TasksAboutThisTheme()
        {

        }
        static public void Main()
        {
            Menu menu = new Menu("Выберите блок заданий");
            menu.Add("Работа \"Библиотеки\" с использованием бинарных файлов");
            menu.Add("Работа \"чат- бота\" с использованием xml- файлов");
            menu.Add("Вопросы по данной теме");
            menu.Add("Выйти в главное меню", true);
            int choice;
            do
            {
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        LibraryBinary.Program.Main();
                        break;
                    case 2:
                        ChatBotXML.Program.Main();
                        break;
                    case 3:
                        TasksAboutThisTheme();
                        break;
                }
            } while (choice != 0);
        }
    }
}
