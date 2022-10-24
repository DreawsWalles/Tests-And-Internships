using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpClasses;
using Library;

namespace ThemeThree
{
    public class Program
    {
        static void TasksAboutThisTheme()
        {
            Console.WriteLine("Вопросы по теме:");
            Console.WriteLine("Зачем использовать ООП?");
            Console.WriteLine("Назовите основные принципы ООП");
            Console.WriteLine("Можете ли вы вызвать метод базового класса, не создавая экземпляр?");
            Console.WriteLine("Что такое полиморфизм?");
            Console.WriteLine("Что такое инкапсуляция?");
            Console.WriteLine("В чем разница между классом и структурой?");
            Console.WriteLine("Какие есть виды наследования?");
            Console.WriteLine("Какой вид наследования не поддерживается в .net?");
            HelpFunctions.Continue();
        }
        static public void Main()
        {
            Menu menu = new Menu("Выберите блок заданий:");
            menu.Add("Работа с классом \"Библиотека\"");
            menu.Add("Вопросы по данной теме");
            menu.Add("Выйти в главное меню", true);
            int choice;
            do
            {
                Console.Clear();
                menu.Print();
                choice = menu.Choice();
                Console.Clear();
                switch(choice)
                {
                    case 1:
                        Library.Program.Main();
                        break;
                    case 2:
                        TasksAboutThisTheme();
                        break;
                }
            } while (choice != 0);
        }

    }
}
