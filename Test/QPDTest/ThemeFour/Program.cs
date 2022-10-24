using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using HelpClasses;

namespace ThemeFour
{
    public class Program
    {
        static void TasksAboutThisTheme()
        {

        }
        public static void Main()
        {
            Menu menu = new Menu("Выберите блок заданий");
            menu.Add("Работа калькулятора");
            menu.Add("Работа чат- бота");
            menu.Add("Вопросы по данной теме");
            menu.Add("Выйти в главное меню", true);
            int choice;
            do
            {
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
                switch(choice)
                {
                    case 1:
                        Calculator.Program.Main();
                        break;
                    case 2:
                        ChatBot.Program.Main();
                        break;
                    case 3:
                        TasksAboutThisTheme();
                        break;
                }
            } while (choice != 0);
        }
    }
}
